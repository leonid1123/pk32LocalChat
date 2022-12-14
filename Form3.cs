using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pk32LocalChat
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string connectionString = @"server=localhost;userid=chat_admin;password=123456;database=chat32";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT username FROM auth";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader usernames = command.ExecuteReader();
            while (usernames.Read())
            {
                listBox2.Items.Add(usernames.GetString(0));
            }
            conn.Close();
        }
    }
}
