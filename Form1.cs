using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace pk32LocalChat
{
    public partial class Form1 : Form
    {
        string nik = "";
        string login = "";
        string password = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {//кнопка регистрации
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
            nik = textBox1.Text.Trim();
            login = textBox4.Text.Trim();
            password = textBox2.Text.Trim();
            if (nik.Length > 0 & login.Length > 0 & password.Length > 0)
            {
                string sql1 = "SELECT id FROM auth WHERE username = @nik";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@nik", nik);
                cmd1.Prepare();
                MySqlDataReader rdr = cmd1.ExecuteReader();
                if (rdr.HasRows)
                {
                    MessageBox.Show("Такой ник занят");
                }
                else
                {
                    if (password.Equals(textBox3.Text.Trim()))
                    {
                        MessageBox.Show("Такой ник свободен");
                        conn.Close();
                        conn.Open();
                        string sql2 = "INSERT INTO auth(username,login,password) VALUES(@nik,@login,@pass)";
                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                        cmd2.Parameters.AddWithValue("@nik", nik);
                        cmd2.Parameters.AddWithValue("@login", login);
                        cmd2.Parameters.AddWithValue("@pass", password);
                        cmd2.Prepare();
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Ты зарегистрирован! ПОДГОТОВЬСЯ!!!");
                    } else
                    {
                        MessageBox.Show("Не удивил :-(");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//кнопка перехода к логину
           
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
            
        }
    }
}
