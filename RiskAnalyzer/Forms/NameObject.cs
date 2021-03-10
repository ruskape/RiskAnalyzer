using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskAnalyzer.Forms
{
    public partial class NameObject : Form
    {

        public string objectname;

        public NameObject()
        {
            InitializeComponent();
        }

        private void Callculate_Click(object sender, EventArgs e)
        {

            string tmp =Convert.ToString(nameobject_label.Text);
            objectname = tmp;

        }
    }
}
