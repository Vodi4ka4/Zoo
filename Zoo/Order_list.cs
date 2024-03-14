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
    public partial class Order_list : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Zoo";
        public Order_list()
        {
            InitializeComponent();
            Form_Load();
        }
        private void Form_Load()
        {
            /*using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                // Открываем подключение
                connection.Open();

                // Напишем SQL-запрос для выборки данных
                string sql = "SELECT * FROM order_";

                // Создаем объект адаптера данных
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection))
                {
                    // Создаем объект DataTable для хранения данных
                    DataTable dataTable = new DataTable();

                    // Заполняем DataTable данными из базы данных
                    adapter.Fill(dataTable);

                    // Привязываем DataTable к DataGridView
                    dataGridView_order.DataSource = dataTable;
                }
            }
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                List<Order_> order_list = new List<Order_>();
                connection.Open();
                var command = new NpgsqlCommand($"SELECT * FROM order_");
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Order_ order_ = new Order_();
                    order_.Id = (int)reader[0];
                    order_.Date_ = (DateTime)reader[2];
                    order_.Cost = (Decimal)reader[3];
                    order_.Code = (int)reader[1];
                    order_.Status = (string)reader[4];
                    order_list.Add(order_);
                }
                reader.Close();
                connection.Close();
            }*/
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM order_";
                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(query, connection);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "order_");
                    dataGridView_order.DataSource = dataSet.Tables["order_"];
                    dataGridView_order.Columns[0].HeaderText = "ID";
                    dataGridView_order.Columns[1].HeaderText = "Дата";
                    dataGridView_order.Columns[2].HeaderText = "Цена";
                    dataGridView_order.Columns[3].HeaderText = "Код";
                    dataGridView_order.Columns[4].HeaderText = "Статус";
                    /*foreach (DataRow row in dataSet.Tables["order_"].Rows)
                    {
                        string phoneNumber = row[2].ToString();
                        row[2] = FormatPhoneNumber(phoneNumber);
                    }*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                }
            }
            dataGridView_order.AllowUserToAddRows = true;
            dataGridView_order.ReadOnly = false;
        }
    }
}
