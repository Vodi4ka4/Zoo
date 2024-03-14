using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo
{
    
    public partial class Order : Form
    {   
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Zoo";
        public Order()
        {
            InitializeComponent();
        }
        public List<string> idProduct { get; set; }
        public void SetSelectedArticle(List<string> stringArray)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                // Создаем копию списка stringArray
                List<string> idProductCopy = new List<string>(stringArray);
                foreach (string id in idProductCopy)
                {
                    string sql = "SELECT id, title, cost, image, description ,manufacturer FROM product WHERE id = '" + id + "'";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListItem listItem = new ListItem();
                                listItem.Description = Convert.ToString(reader.GetString(4));
                                listItem.Name_product = reader.GetString(1);
                                listItem.Coust = Convert.ToString(reader.GetDecimal(2)) + "₽";
                                listItem.Manufacturer = reader.GetString(5);
                                listItem.Id = Convert.ToString(reader.GetInt32(0));
                                if (!reader.IsDBNull(3))
                                {
                                    string path = reader.GetString(3);
                                    listItem.Icon = Image.FromFile(path);
                                }

                                // Создаем и добавляем элементы управления для выбора количества
                                AddQuantityControls(listItem);

                                flowLayoutPanel_Product.Controls.Add(listItem);
                            }
                        }
                    }
                    // Удаляем обработанный элемент из оригинальной коллекции
                    stringArray.Remove(id);
                    label_total.Text = Convert.ToString(CalculateTotalPrice());
                }
            }
        }
        private void AddQuantityControls(ListItem listItem)
        {
            // Определяем размер и расположение элементов управления
            int textBoxWidth = 50;
            int buttonWidth = 30;
            int buttonHeight = 20;
            int spacing = 5;
            int shiftLeft = 10; // сдвигаем на 10 пикселей влево

            // Создаем элементы управления для выбора количества
            TextBox quantityTextBox = new TextBox();
            quantityTextBox.Text = "1";
            quantityTextBox.Name = "quantityTextBox"; // Даем имя элементу управления
            quantityTextBox.Location = new Point(listItem.Width - textBoxWidth - spacing - shiftLeft, listItem.Height - buttonHeight - spacing);
            quantityTextBox.Size = new Size(textBoxWidth, buttonHeight);

            Button plusButton = new Button();
            plusButton.Text = "+";
            plusButton.Location = new Point(quantityTextBox.Location.X - buttonWidth - spacing - shiftLeft, quantityTextBox.Location.Y);
            plusButton.Size = new Size(buttonWidth, buttonHeight);

            Button minusButton = new Button();
            minusButton.Text = "-";
            minusButton.Location = new Point(plusButton.Location.X - buttonWidth - spacing, plusButton.Location.Y);
            minusButton.Size = new Size(buttonWidth, buttonHeight);

            Button deleteButton = new Button();
            deleteButton.Text = "Удалить";
            deleteButton.Location = new Point(minusButton.Location.X - buttonWidth - spacing - shiftLeft - 10, minusButton.Location.Y);
            deleteButton.Size = new Size(buttonWidth * 2, buttonHeight);
            // Добавляем обработчики событий для кнопок "+" и "-"
            plusButton.Click += (sender, e) =>
            {
                int quantity = int.Parse(quantityTextBox.Text);
                quantity++;
                quantityTextBox.Text = quantity.ToString();
                label_total.Text = Convert.ToString(CalculateTotalPrice());
            };

            minusButton.Click += (sender, e) =>
            {
                int quantity = int.Parse(quantityTextBox.Text);
                if (quantity > 0)
                {
                    quantity--;
                    quantityTextBox.Text = quantity.ToString();
                }
                label_total.Text = Convert.ToString(CalculateTotalPrice());
            };

            deleteButton.Click += (sender, e) =>
            {
                flowLayoutPanel_Product.Controls.Remove(listItem);
                label_total.Text = Convert.ToString(CalculateTotalPrice());
            };

            // Добавляем элементы управления к ListItem
            listItem.Controls.Add(quantityTextBox);
            listItem.Controls.Add(plusButton);
            listItem.Controls.Add(minusButton);
            listItem.Controls.Add(deleteButton);
        }
        private decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (var listItem in flowLayoutPanel_Product.Controls.OfType<ListItem>())
            {
                int quantity = int.Parse(listItem.Controls["quantityTextBox"].Text); // Получаем количество товара из TextBox
                decimal pricePerItem = decimal.Parse(listItem.Coust.Replace("₽", "")); // Получаем цену товара из свойства Coust

                totalPrice += quantity * pricePerItem;
            }

            return totalPrice;
        }
        Random random = new Random();
        int number;

        private void button_order_Click(object sender, EventArgs e)
        {
            number = random.Next(0,100);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Prepare the SQL command outside the loop
                string sql = "INSERT INTO order_ (date_, cost, code, status) VALUES (@date_, @cost, @code, @status)";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    // Add parameters to the command
                    command.Parameters.Add("@date_", NpgsqlDbType.Date);
                    command.Parameters.Add("@cost", NpgsqlDbType.Numeric);
                    command.Parameters.Add("@code", NpgsqlDbType.Integer);
                    command.Parameters.Add("@status", NpgsqlDbType.Text);
                    // Set parameter values
                    command.Parameters["@date_"].Value = DateTime.Today;
                    command.Parameters["@cost"].Value = CalculateTotalPrice();
                    command.Parameters["@code"].Value = number;
                    command.Parameters["@status"].Value = "Новый";

                    // Execute the command
                    command.ExecuteNonQuery();
                }
            }
            int orderId = GetOrderId();
            CreateTicket();
        }
        int orderId = 0;
        private int GetOrderId()
        {

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Prepare the SQL command outside the loop
                string sql = "SELECT id FROM order_ WHERE code = @code";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@code", Convert.ToString(number));

                    // Execute the command
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderId = reader.GetInt32(0); // Assuming id is of type integer
                        }
                    }
                }
            }

            return orderId;
        }
        public void CreateTicket()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = orderId + ".pdf";
            saveFileDialog.Filter = "PDF файлы (*.pdf)|*.pdf";

            string path;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
            }
            else
            {
                return;
            }

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                Graphics graphics = e.Graphics;
                Font font = new Font("Arial", 12);
                Font titleFont = new Font("Arial", 16);
                float fontHeight = font.GetHeight();

                float startX = 10;
                float startY = 10;
                float offset = 40;

                graphics.DrawString("Талон на получение", titleFont, Brushes.Black, (e.PageBounds.Width - graphics.MeasureString("Талон на получение", font).Width) / 2, startY);
                startY += offset;

                graphics.DrawString($"Дата заказа: {DateTime.Today.Date.ToShortDateString()}", font, Brushes.Black, startX, startY);
                startY += offset;

                graphics.DrawString($"Номер заказа: {orderId}", font, Brushes.Black, startX, startY);
                startY += offset;

                graphics.DrawString("Состав заказа:", font, Brushes.Black, startX, startY);
                startY += offset;

                foreach (ListItem listItem in flowLayoutPanel_Product.Controls)
                {
                    graphics.DrawString($"- {listItem.Name_product} - {listItem.Controls["quantityTextBox"].Text} шт.", font, Brushes.Black, startX, startY);
                    startY += offset;
                }

                graphics.DrawString($"Сумма заказа: {CalculateTotalPrice()}", font, Brushes.Black, startX, startY);
                startY += offset;

                graphics.DrawString($"Сумма скидки: {0}", font, Brushes.Black, startX, startY);
                startY += offset;

                graphics.DrawString($"Пункт выдачи: {comboBox_addres.SelectedItem.ToString()}", font, Brushes.Black, startX, startY);
                startY += offset;

                graphics.DrawString($"Код для получения: {number}", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, startX, startY);
            };

            printDocument.PrinterSettings.PrintToFile = true;
            printDocument.PrinterSettings.PrintFileName = path;
            printDocument.Print();
        }

    }
}
