using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Zoo
{
    public partial class Form_Auto : Form
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=159632;Database=Zoo";
        public Form_Auto()
        {
            InitializeComponent();
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            if (Check_user(textBox_login.Text, textBox_password.Text).type == 1)
            {
                Admin admin = new Admin();
                admin.FormClosed += (s, args) => Close();
                admin.Show();
            }
            else if (Check_user(textBox_login.Text, textBox_password.Text).type == 2)
            {
                Product manager = new Product(2);
                manager.FormClosed += (s, args) => Close();
                manager.Show();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
        }

        private void button_enter_gost_Click(object sender, EventArgs e)
        {
            Product product = new Product(0);
            product.FormClosed += (s, args) => Close();
            product.Show();
        }
        private (int id, int type) Check_user(string login, string password)
        {
            int id = 0;
            int type = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT id, role FROM users where login = @login AND password = @password";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = reader.GetInt32(0);
                            type = reader.GetInt32(1);
                        }
                    }
                }
            }
            return (id, type);
        }
    }
}
