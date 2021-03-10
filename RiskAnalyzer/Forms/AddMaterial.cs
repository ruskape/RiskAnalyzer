using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RiskAnalyzer
{
    public partial class AddMaterial : Form
    {

        public AddMaterial()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            String mid = "";

            MySqlConnection connection = new MySqlConnection(connect);
            

            try
            {
                if (nameMaterial.Text == String.Empty ||
                    Ro_liquid.Text == String.Empty ||
                    delta_H_kip.Text == String.Empty ||
                    t_kip_liquid.Text == String.Empty ||
                    M.Text == String.Empty ||
                    //lymbda_pov.Text == String.Empty ||
                    //Ro_pov.Text == String.Empty ||
                    //C_pov.Text == String.Empty ||
                    E_ud.Text == String.Empty ||
                    C_nkpr.Text == String.Empty)
                {
                    MessageBox.Show("Неверный ввод, заполните все ячейки", "Ошибка");
                }

                else
                {
                    connection.Open();
                    String strSQL;
                    String strSQL2;
                    String correctString;
                    int classmaterial = Int32.Parse(comboBox1.Text);
                    //0
                    correctString = nameMaterial.Text.Replace(",", ".");
                    strSQL2 = "Insert into materials (materialsname,materialsclass) " + "value ( '" + correctString + "','" + classmaterial + "' )";

                    MySqlCommand command0 = new MySqlCommand(strSQL2, connection);
                    command0.ExecuteNonQuery();
                    //

                        MySqlCommand command = new MySqlCommand("SELECT * FROM materials", connection);

                        MySqlDataReader oledRead = command.ExecuteReader();
                        while (oledRead.Read())
                        {
                            mid = oledRead["idmaterials"].ToString();
                            int i = int.Parse(mid);
                            mid = i.ToString();
                        }
                        oledRead.Close();
                    //1
                    correctString = Ro_liquid.Text.Replace(",", ".");
                    strSQL = "Insert into materials_parameters (idmaterial,idparameters,value) " + "value (" + mid + ", " + "1, " + correctString + " )";

                    MySqlCommand command1 = new MySqlCommand(strSQL, connection);
                    command1.ExecuteNonQuery();
                    //2
                    correctString = C_liqiud.Text.Replace(",", ".");
                    strSQL = "Insert into materials_parameters (idmaterial,idparameters,value) " + "value (" + mid + ", " + "2, " + correctString + " )"; ;
                    MySqlCommand command2 = new MySqlCommand(strSQL, connection);
                    command2.ExecuteNonQuery();
                    //3
                    correctString = delta_H_kip.Text.Replace(",", ".");
                    strSQL = "Insert into materials_parameters (idmaterial,idparameters,value) " + "value (" + mid + ", " + "3, " + correctString + " )"; ;
                    MySqlCommand command3 = new MySqlCommand(strSQL, connection);
                    command3.ExecuteNonQuery();
                    //4
                    strSQL = "Insert into materials_parameters (idmaterial,idparameters,value) ";
                    strSQL += "value (";
                    strSQL += mid + ", ";
                    strSQL += "4, ";
                    correctString = t_kip_liquid.Text.Replace(",", ".");
                    strSQL += correctString;
                    strSQL += " )";
                    MySqlCommand command4 = new MySqlCommand(strSQL, connection);
                    command4.ExecuteNonQuery();
                    //5
                    strSQL = "Insert into materials_parameters (idmaterial,idparameters,value) ";
                    strSQL += "value (";
                    strSQL += mid + ", ";
                    strSQL += "5, ";
                    correctString = M.Text.Replace(",", ".");
                    strSQL += correctString;
                    strSQL += " )";
                    MySqlCommand command5 = new MySqlCommand(strSQL, connection);
                    command5.ExecuteNonQuery();
                    //
                    strSQL = "Insert into materials_parameters (idmaterial,idparameters,value) ";
                    strSQL += "value (";
                    strSQL += mid + ", ";
                    strSQL += "6, ";
                    correctString = E_ud.Text.Replace(",", ".");
                    strSQL += correctString;
                    strSQL += " )";
                    MySqlCommand command6 = new MySqlCommand(strSQL, connection);
                    command6.ExecuteNonQuery();
                    //
                    strSQL = "Insert into materials_parameters (idmaterial,idparameters,value) ";
                    strSQL += "value (";
                    strSQL += mid + ", ";
                    strSQL += "7, ";
                    correctString = C_nkpr.Text.Replace(",", ".");
                    strSQL += correctString;
                    strSQL += " )";
                    MySqlCommand command7 = new MySqlCommand(strSQL, connection);
                    command7.ExecuteNonQuery();
                }

            }
            catch (System.Data.DataException o)
            {
                System.Windows.Forms.MessageBox.Show("error");
            }
            finally
            {
                connection.Close();
                AdminForm m = this.Owner as AdminForm;
                m.LoadData();
                this.Close();
            }
        }

        private void Ro_liquid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void C_liqiud_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void delta_H_kip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void t_kip_liquid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void M_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void E_ud_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void C_nkpr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        private void help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для добавления введите значения в поля и нажмите добавить.", "Помошь");

        }
    }
}
