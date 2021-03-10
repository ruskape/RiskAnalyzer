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

    public partial class EditUser : Form
    {
        public bool Ok;

        public EditUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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
                connection.Open();

                try
                {
                    string hashpass = GetMD5Hash(password.Text);

                    int tmpnumber = Int32.Parse(EditUsersForm.mId1);
                    String strSQL = " UPDATE `riskdata`.`peoples` SET `idpeoples` = '" + tmpnumber + "', `login` = '" + login.Text + "' , `password` = '" + hashpass + "' , `role` = '" + Int32.Parse(comboBox1.Text) + "'  WHERE(`idpeoples` = '" + tmpnumber + "')";

                    MySqlCommand command2 = new MySqlCommand(strSQL, connection);
                    command2.ExecuteNonQuery();
                }
                catch (System.Data.DataException o)
                {
                    System.Windows.Forms.MessageBox.Show("error");
                }
                finally
                {
                    connection.Close();
                }

                Ok = true;
                this.Close();
            }
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

        private void EditUser_Activated(object sender, EventArgs e)
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            MySqlConnection conMat;
            conMat = new MySqlConnection(connect);
            MySqlConnection connection = new MySqlConnection(connect);
            try
            {
                connection.Open();
                String idpeoples = EditUsersForm.mId1;
                MySqlCommand command11 = new MySqlCommand("SELECT * FROM peoples WHERE idpeoples = + '" + idpeoples + "' ", connection);
                MySqlDataReader oledbRead3 = command11.ExecuteReader();
                while (oledbRead3.Read())
                    login.Text = oledbRead3["login"].ToString();
                oledbRead3.Close();
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
                connection.Open();
                String idpeoples = EditUsersForm.mId1;
                MySqlCommand command2 = new MySqlCommand("SELECT * FROM peoples WHERE idpeoples = + '" + idpeoples + "' ", connection);
                MySqlDataReader oledbRead2 = command2.ExecuteReader();
                while (oledbRead2.Read())
                {
                    comboBox1.Text = oledbRead2["role"].ToString();

                }
                oledbRead2.Close();
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


        private void role_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для изменения введите значения и нажмите изменить.", "Помошь");

        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }


}
