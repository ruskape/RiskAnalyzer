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
    public partial class EditMaterial : Form
    {
        public bool Ok;

        public EditMaterial()
        {
            InitializeComponent();
            EditMaterial_Activated();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            MySqlConnection connection = new MySqlConnection(connect);
            connection.Open();
            if (nameMaterial.Text == String.Empty ||
                Ro_liquid.Text == String.Empty ||
                delta_H_kip.Text == String.Empty ||
                t_kip_liquid.Text == String.Empty ||
                M.Text == String.Empty ||
                E_ud.Text == String.Empty ||
                C_nkpr.Text == String.Empty)
            {
                MessageBox.Show("Неверный ввод, заполните все ячейки", "Ошибка");
            }
            else
            {
                try
                {
                    String strSQL;
                    strSQL = "UPDATE materials SET ";
                    strSQL += "materialsname = '" + nameMaterial.Text + "' " ;
                    strSQL += "," + "materialsclass = '" + Int32.Parse(comboBox1.Text) + "' ";
                    strSQL += "WHERE idmaterials =" + AdminForm.mId;
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

                try
                {
                    connection = new MySqlConnection(connect);
                    connection.Open();
                    String strSQL;
                    String correctString;
                    //
                    correctString = Ro_liquid.Text.Replace(",", ".");
                    strSQL = "UPDATE materials_parameters SET ";
                    strSQL += "value = " + correctString + " ";
                    strSQL += "WHERE ";
                    strSQL += "idmaterial =" + AdminForm.mId + " and idparameters = 1";
                    MySqlCommand command1 = new MySqlCommand(strSQL, connection);
                    command1.ExecuteNonQuery();
                    //
                    correctString = C_liqiud.Text.Replace(",", ".");
                    strSQL = "UPDATE materials_parameters SET ";
                    strSQL += "value = " + correctString + " ";
                    strSQL += "WHERE ";
                    strSQL += "idmaterial =" + AdminForm.mId + " and idparameters = 2";
                    MySqlCommand command2 = new MySqlCommand(strSQL, connection);
                    command2.ExecuteNonQuery();
                    //
                    correctString = delta_H_kip.Text.Replace(",", ".");
                    strSQL = "UPDATE materials_parameters SET ";
                    strSQL += "value = " + correctString + " ";
                    strSQL += "WHERE ";
                    strSQL += "idmaterial =" + AdminForm.mId + " and idparameters = 3";
                    MySqlCommand command3 = new MySqlCommand(strSQL, connection);
                    command3.ExecuteNonQuery();
                    //
                    correctString = t_kip_liquid.Text.Replace(",", ".");
                    strSQL = "UPDATE materials_parameters SET ";
                    strSQL += "value = " + correctString + " ";
                    strSQL += "WHERE ";
                    strSQL += "idmaterial =" + AdminForm.mId + " and idparameters = 4";
                    MySqlCommand command4 = new MySqlCommand(strSQL, connection);
                    command4.ExecuteNonQuery();
                    //
                    correctString = M.Text.Replace(",", ".");
                    strSQL = "UPDATE materials_parameters SET ";
                    strSQL += "value = " + correctString + " ";
                    strSQL += "WHERE ";
                    strSQL += "idmaterial =" + AdminForm.mId + " and idparameters = 5";
                    MySqlCommand command5 = new MySqlCommand(strSQL, connection);
                    command5.ExecuteNonQuery();
                    //
                    correctString = E_ud.Text.Replace(",", ".");
                    strSQL = "UPDATE materials_parameters SET ";
                    strSQL += "value = " + correctString + " ";
                    strSQL += "WHERE ";
                    strSQL += "idmaterial =" + AdminForm.mId + " and idparameters = 6";
                    MySqlCommand command6 = new MySqlCommand(strSQL, connection);
                    command6.ExecuteNonQuery();
                    //
                    correctString = C_nkpr.Text.Replace(",", ".");
                    strSQL = "UPDATE materials_parameters SET ";
                    strSQL += "value = " + correctString + " ";
                    strSQL += "WHERE ";
                    strSQL += "idmaterial =" + AdminForm.mId + " and idparameters = 7";
                    MySqlCommand command7 = new MySqlCommand(strSQL, connection);
                    command7.ExecuteNonQuery();

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

        public void EditMaterial_Activated()
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            MySqlConnection conMat;
            conMat = new MySqlConnection(connect);
            MySqlConnection connection = new MySqlConnection(connect);
            try
            {
                connection.Open();
                String idmaterial = AdminForm.mId;
                MySqlCommand command11 = new MySqlCommand("SELECT * FROM Materials WHERE idmaterials = + '" + idmaterial + "' ", connection);
                MySqlDataReader oledbRead3 = command11.ExecuteReader();
                while (oledbRead3.Read())
                        nameMaterial.Text = oledbRead3["materialsname"].ToString();
                comboBox1.Text = oledbRead3["materialsclass"].ToString();
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
                String idmaterial = AdminForm.mId;
                MySqlCommand command2 = new MySqlCommand("SELECT * FROM materials_parameters WHERE idmaterial = + '"+idmaterial+"' ", connection);
                MySqlDataReader oledbRead2 = command2.ExecuteReader();
                while (oledbRead2.Read())
                {
                    if (oledbRead2["idparameters"].ToString() == "1")
                    {
                        Ro_liquid.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "2")
                    {
                        C_liqiud.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "3")
                    {
                        delta_H_kip.Text = oledbRead2["value"].ToString();
                    }
                    
                    if (oledbRead2["idparameters"].ToString() == "4")
                    {
                        t_kip_liquid.Text = oledbRead2["value"].ToString();
                    }
                    
                    if (oledbRead2["idparameters"].ToString() == "5")
                    {
                        M.Text = oledbRead2["value"].ToString();
                    }

                    if (oledbRead2["idparameters"].ToString() == "6")
                    {
                        E_ud.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "7")
                    {
                        C_nkpr.Text = oledbRead2["value"].ToString();
                    }
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
            MessageBox.Show("Для изменения введите значения в поля и нажмите изменить.", "Помошь");

        }
    }
}
