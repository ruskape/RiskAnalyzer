using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskAnalyzer.Forms
{
    public partial class DBConnect : Form
    {

        public DBConnect()
        {
            InitializeComponent();
        }


        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        public void save_Click(object sender, EventArgs e)

        {

            string connect = "server=" + servername_label.Text + ";" + "user=" + username_label.Text + ";" + "database=" + database_label.Text + ";" + "password=" + password_label.Text + ";";

            MySqlConnection myConnection = new MySqlConnection(connect);

            try
            {
                myConnection.Open();
                MessageBox.Show("Соединение установлено.");
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["MyConnectionString"].ConnectionString = connect;
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            myConnection.Close();
            
            this.Hide();
            HomeForm form = new HomeForm();
            form.ShowDialog();
        }
    }
}
