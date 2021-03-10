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

namespace RiskAnalyzer
{

    public partial class AdminForm : Form
    {
        public static String mId;
        public static string connect = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        MySqlConnection connection = new MySqlConnection(connect);

        public static MySqlDataAdapter da = new MySqlDataAdapter();

        public AdminForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
        
        public void LoadData()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            DataSet ds = new DataSet();

            string Query = "SELECT * FROM Materials";

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

        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMaterial f2 = new AddMaterial();
            f2.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int vardelete = dataGridView1.CurrentRow.Index;
            int vardelete2 = Convert.ToInt32(dataGridView1[0, vardelete].Value);
            mId = vardelete2.ToString();
            EditMaterial fmaterial_edit = new EditMaterial();
            fmaterial_edit.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                int replay = 0;

        MySqlConnection connection = new MySqlConnection(connect);

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                int vardelete = dataGridView1.CurrentRow.Index;
                int vardelete2 = Convert.ToInt32(dataGridView1[0, vardelete].Value);
                string Query = "DELETE FROM Materials WHERE idmaterials =" + vardelete2;
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


        private void button5_Click_1(object sender, EventArgs e)
        {
            HomeForm f4 = new HomeForm();
            this.Hide();
            f4.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditUsersForm f5 = new EditUsersForm();
            this.Hide();
            f5.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для редактирования или удаления выделите строку, для редактирования базы данных пользователей нажмите соответствующую кнопку.", "Помошь");

        }
    }
}
