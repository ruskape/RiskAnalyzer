using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RiskAnalyzer.Forms
{
    public partial class HomeForm : Form
    {
        public bool Ok;
        public bool bAdmi_login;
        public String sUsers_login;
        public String sUsers;
        public int kol = 0;
        public int role = 0;
        public int idusername = 0;
        public HomeForm()

        {
            InitializeComponent();

        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void about_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Модуль расчета оценки показателей риска для объекта хранения горючих вешеств класса 2.", "О программе");
        }

        private void help_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Введите логин и пароль для входа в программу.", "Помощь");
        }

        private static string GetMD5Hash(string text)
        {
            using (var hashAlg = MD5.Create()) 
            {
                byte[] hash = hashAlg.ComputeHash(Encoding.UTF8.GetBytes(text)); 
                var builder = new StringBuilder(hash.Length * 2); 
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("X2")); 
                }
                return builder.ToString(); 
            }
        }


        private void enter_button_Click(object sender, EventArgs e)
        {
            if (password_textbox.Text == String.Empty || login_textbox.Text == String.Empty)
            {
                MessageBox.Show("Неверный ввод, заполните все ячейки", "Ошибка");
            }
            else
            {



                string hashpass = GetMD5Hash(password_textbox.Text);
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT idpeoples,login,password,role FROM peoples WHERE login ='" + login_textbox.Text + "' and password ='" + hashpass + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);



                if (dt.Rows.Count == 1)
                {
                    role = Convert.ToInt32(dt.Rows[0][3]);

                    if (role == 1)
                    {
                        this.Hide();
                        AdminForm f2 = new AdminForm();
                        f2.Show();
                    }
                    else if (role == 2)
                    {
                        idusername = Convert.ToInt32(dt.Rows[0][0]);

                        this.Hide();
                        UserForm f3 = new UserForm();
                        f3.setiduser(idusername);
                        f3.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Неправильно введены данные","Ошибка авторизации");
                    connection.Close();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DBConnect f4 = new DBConnect();
            f4.Show();
            
        }
    }
}
