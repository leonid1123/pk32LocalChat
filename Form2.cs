using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace pk32LocalChat
{
    public partial class Form2 : Form
    {
        string login = "";
        string password = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//кнопка входа в систему
            string connectionString = @"server=localhost;userid=chat_admin;password=123456;database=chat32";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            if (conn.State.ToString() == "Open")
            {
                MessageBox.Show("Подключение успешно");
            }
            else
            {
                MessageBox.Show("Всё пропало!");
            }
            login = textBox1.Text.Trim();
            password = textBox1.Text.Trim();
            if (login.Length > 0 & password.Length > 0)
            {
                string sql1 = "SELECT password FROM auth WHERE login = @login";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@login", login);
                cmd1.Prepare();
                MySqlDataReader rdr = cmd1.ExecuteReader();
                if (rdr.HasRows)
                {
                    //проверить пароль
                    while (rdr.Read())
                    {
                        string storedPassword = rdr.GetString(0);
                        if (password.Equals(storedPassword))
                        {
                            MessageBox.Show("всё хорошо");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ТАКОГО ПОЛЬЗОВАТЕЛЯ НЕТ!!!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1= new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
