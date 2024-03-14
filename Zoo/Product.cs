using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoo
{
    public partial class Product : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Zoo";
        List<string> idProduct = new List<string>();
        public Product(int role)
        {
            InitializeComponent();
            populateItems();
            if (role == 2)
            {
                button_list_order.Visible = true;
            }
        }
        private void populateItems(string searchTerm = "", string sortingCriteria = "", int offset = 0)
        {
            flowLayoutPanel_Product.Controls.Clear();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT id, title, cost, image, description ,manufacturer FROM product";
                    if (sortingCriteria != "")
                    {
                        sql += " " + sortingCriteria + ", " + " id LIMIT " + itemsPerPage + " OFFSET " + offset;
                    }
                    else
                    {
                        sql += " ORDER BY id LIMIT " + itemsPerPage + " OFFSET " + offset;
                    }

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
                                flowLayoutPanel_Product.Controls.Add(listItem);
                                listItem.MouseClick += (sender, e) =>
                                {
                                    if (e.Button == MouseButtons.Right)
                                    {
                                        // Создаем контекстное меню
                                        ContextMenu contextMenu = new ContextMenu();

                                        // Добавляем пункт меню "Добавить в заказ"
                                        MenuItem menuItem = new MenuItem("Добавить в заказ");
                                        menuItem.Click += (s, args) =>
                                        {
                                            idProduct.Add(listItem.Id);
                                            if (button_order.Visible == false)
                                            {
                                            button_order.Visible = true;
                                            }
                                        };
                                        contextMenu.MenuItems.Add(menuItem);
                                        

                                        // Привязываем контекстное меню к элементу ListItem и отображаем его
                                        listItem.ContextMenu = contextMenu;
                                    }
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных из базы данных: " + ex.Message);
            }
        }
        private void PopulatePage(int pageNumber)
        {
            int offset = (pageNumber - 1) * itemsPerPage;
            string sortingCriteria = GetSortingCriteria();
            populateItems(textBox_search.Text, sortingCriteria, offset);
        }
        private string GetSortingCriteria()
        {
            string sortingCriteria = "";
            switch (comboBox_Sorting.SelectedIndex)
            {
                case 1:
                    sortingCriteria = "ORDER BY cost ASC";
                    break;
                case 2:
                    sortingCriteria = "ORDER BY cost DESC";
                    break;
                case 3:
                    sortingCriteria = "ORDER BY title ASC";
                    break;
                case 4:
                    sortingCriteria = "ORDER BY title DESC";
                    break;
            }
            return sortingCriteria;
        }
        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            populateItems(textBox_search.Text);

        }
        private int currentPage = 1;
        private int totalPages;
        private const int itemsPerPage = 5;
        private void DisplayPagination()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string countSql = "SELECT COUNT(*) FROM product";
                    using (NpgsqlCommand countCommand = new NpgsqlCommand(countSql, connection))
                    {
                        int totalProducts = Convert.ToInt32(countCommand.ExecuteScalar());
                        totalPages = (int)Math.Ceiling((double)totalProducts / itemsPerPage);
                    }
                }

                flowLayoutPanel_Pagination.Controls.Clear(); // Очищаем предыдущие элементы

                // Добавляем кнопку "<" для перехода к предыдущей странице
                AddPageButton("<", currentPage - 1);

                // Добавляем кнопки для каждой страницы
                for (int i = 1; i <= totalPages; i++)
                {
                    Label pageButton = new Label
                    {
                        Text = i.ToString(),
                        Width = 20,
                        Height = 20,
                        Margin = new Padding(5),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Cursor = Cursors.Hand
                    };

                    if (i == currentPage)
                    {
                        pageButton.Font = new System.Drawing.Font(pageButton.Font, FontStyle.Bold | FontStyle.Underline);
                    }

                    // Обработчик клика для перехода на выбранную страницу
                    pageButton.Click += (sender, e) =>
                    {
                        currentPage = int.Parse(((Label)sender).Text);
                        PopulatePage(currentPage);
                    };

                    flowLayoutPanel_Pagination.Controls.Add(pageButton);
                }

                // Добавляем кнопку ">" для перехода к следующей странице
                AddPageButton(">", currentPage + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных из базы данных: " + ex.Message);
            }
        }

        private void AddPageButton(string buttonText, int targetPage)
        {
            // Создаем элемент Label для кнопки страницы
            Label pageButton = new Label
            {
                Text = buttonText,
                Width = 15,
                Height = 15,
                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            // Обработчик клика для перехода на выбранную страницу
            pageButton.Click += (sender, e) =>
            {
                if (targetPage > 0 && targetPage <= totalPages)
                {
                    currentPage = targetPage;
                    PopulatePage(currentPage);
                }
            };

            // Добавляем кнопку в панель пагинации
            flowLayoutPanel_Pagination.Controls.Add(pageButton);
        }
        private void comboBox_Sorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortingCriteria = "";
            switch (comboBox_Sorting.SelectedIndex)
            {
                case 0:
                    sortingCriteria = ""; // По умолчанию сортировка отсутствует
                    break;
                case 1:
                    sortingCriteria = "ORDER BY cost ASC";
                    break;
                case 2:
                    sortingCriteria = "ORDER BY cost DESC";
                    break;
                case 3:
                    sortingCriteria = "ORDER BY title ASC";
                    break;
                case 4:
                    sortingCriteria = "ORDER BY title DESC";
                    break;
            }
                populateItems(textBox_search.Text, sortingCriteria);
        }

        private void Product_Load(object sender, EventArgs e)
        {
            DisplayPagination();
            PopulatePage(1);
        }

        private void button_order_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.SetSelectedArticle(idProduct);
            order.FormClosed += (s, args) => Close();
            order.Show();
        }

        private void button_list_order_Click(object sender, EventArgs e)
        {
            Order_list order_List = new Order_list();
            order_List.FormClosed += (s, args) => Close();
            order_List.Show();
        }
    }
}
