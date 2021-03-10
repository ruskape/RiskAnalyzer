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
using RiskAnalyzer.Forms;

namespace RiskAnalyzer.Forms
{
    public partial class EditUsersForm : Form
    {
        public static String mId1;
        public static string connect = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        MySqlConnection connection = new MySqlConnection(connect);

        public static MySqlDataAdapter da = new MySqlDataAdapter();

        public EditUsersForm()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            DataSet ds = new DataSet();

            string Query = "SELECT * FROM peoples";

            MySqlCommand cmd = new MySqlCommand(Query, connection);

            da.SelectCommand = new MySqlCommand(Query, connection);
            ds.Tables.Clear();
            da.Fill(ds);
            int Row = 0;
            dataGridView1.DataSource = ds.Tables[0];
            if ((Row >= 0) && (Row < dataGridView1.Rows.Count))
                dataGridView1.CurrentCell = dataGridView1[0, Row];
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }



        private void AddUsers_Click(object sender, EventArgs e)
        {
            AddUserForm f22 = new AddUserForm();
            f22.Show(this);
        }

        private void EditUsers_Click(object sender, EventArgs e)
        {
            int vardelete = dataGridView1.CurrentRow.Index;

            int vardelete2 = Convert.ToInt32(dataGridView1[0, vardelete].Value);
            mId1 = vardelete2.ToString();

            EditUser fuseredit = new EditUser();

            fuseredit.Show();
        }

        private void DeleteUsers_Click(object sender, EventArgs e)
        {
            int replay = 0;

            MySqlConnection connection = new MySqlConnection(connect);

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                int h = (int)dataGridView1.CurrentRow.Cells[dataGridView1.Columns.Count - 4].Value;
                string Query = "DELETE FROM peoples WHERE idpeoples =" + h;
                MySqlCommand cmd = new MySqlCommand(Query, connection);
                replay = cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                connection.Close();
                if (replay > 0)
                {
                MessageBox.Show("Запись успешно удалена", "Все ОК", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadData();
            }
        }

        private void UpdateUsers_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void backToAdminForm_Click(object sender, EventArgs e)
        {
            AdminForm f28 = new AdminForm();
            this.Hide();
            f28.Show();
        }

        private void help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для добавления или изменения веделите строку и нажмите соответствующие кнопки.", "Помошь");

        }
    }
}
