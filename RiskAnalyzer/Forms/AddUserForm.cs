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
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void addbutton_Click(object sender, EventArgs e)
        {

            if (login.Text == String.Empty || password.Text == String.Empty || comboBox1.Text == String.Empty)
            {
                MessageBox.Show("Неверный ввод, заполните все ячейки", "Ошибка");
            }
            else
            {
                string connect = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

                MySqlConnection connection = new MySqlConnection(connect);

                String mid = "";

                try
                {

                    connection = new MySqlConnection(connect);
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM peoples", connection);

                    MySqlDataReader oledRead = command.ExecuteReader();
                    while (oledRead.Read())
                    {
                        mid = oledRead["idpeoples"].ToString();
                        int i = int.Parse(mid);
                        i++;
                        mid = i.ToString();
                    }
                    oledRead.Close();
                }

                catch (System.Data.DataException o)
                {
                    System.Windows.Forms.MessageBox.Show("error");
                }
                finally
                {
                    connection.Close();
                }

                try
                {
                    string hashpass = GetMD5Hash(password.Text);
                    int rolesql = Convert.ToInt32(comboBox1.Text);
                    connection.Open();
                    String strSQL2;
                    String correctString;
                    correctString = login.Text.Replace(",", ".");
                    strSQL2 = "Insert into peoples (idpeoples,login,password,role) " + "value ('" + Convert.ToInt32(mid) + "', '" + login.Text + "' , '" + hashpass + "' , '" + rolesql + "' )";

                    MySqlCommand command0 = new MySqlCommand(strSQL2, connection);
                    command0.ExecuteNonQuery();

                }
                catch (System.Data.DataException o)
                {
                    System.Windows.Forms.MessageBox.Show("error");
                }
                finally
                {
                    connection.Close();
                }


            }
            EditUsersForm m = this.Owner as EditUsersForm;
            m.LoadData();
            this.Close();
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

        private void role_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для добавления введите значения и нажмите добавить.", "Помошь");

        }
    }
}
