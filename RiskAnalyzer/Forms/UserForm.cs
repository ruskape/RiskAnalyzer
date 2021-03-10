using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Word = Microsoft.Office.Interop.Word;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace RiskAnalyzer.Forms
{
    public partial class UserForm : Form
    {
        public int idpeoples;
        public int idmaterialfor;

        public void setiduser(int id)
        {
            idpeoples = id;
        }
        private bool isLeftButtonDown = false;
        private RiskAnalyzer.GMapMarkerImage currentMarker;
        private GMap.NET.WindowsForms.GMapOverlay markersOverlay;
        public double latforcircle = 0;
        public double lngforcircle = 0;
        public double latposition = 59.885392;
        public double lngposotion = 30.166442;
        double sr_ind_risk_a = 0;
        double sr_ind_risk_b = 0;
        double sr_ind_risk_c = 0;
        double koll_risk = 0;

        public UserForm()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.park as Bitmap;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dataGridView2[column, row];
            DataGridViewCell cell2 = dataGridView2[0, row - 1];


            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        public void UserForm_Load(object sender, EventArgs e)
        {
            gMapControl1.Dock = DockStyle.Fill;
            trackBar1.Maximum = 18;
            trackBar1.Minimum = 5;
            gMapControl1.Bearing = 0; 
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.GrayScaleMode = true;
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 18;
            gMapControl1.MinZoom = 5;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.NegativeMode = false;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Zoom = 12;
            trackBar1.Value = (int)gMapControl1.Zoom;
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            GMap.NET.MapProviders.GMapProvider.WebProxy = System.Net.WebRequest.GetSystemWebProxy();
            GMap.NET.MapProviders.GMapProvider.WebProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            gMapControl1.Position = new GMap.NET.PointLatLng(latposition, lngposotion);
            markersOverlay = new GMap.NET.WindowsForms.GMapOverlay(gMapControl1, "marker");
            gMapControl1.OnMapZoomChanged += new MapZoomChanged(mapControl_OnMapZoomChanged);
            gMapControl1.MouseClick += new MouseEventHandler(mapControl_MouseClick);
            gMapControl1.MouseDown += new MouseEventHandler(mapControl_MouseDown);
            gMapControl1.MouseUp += new MouseEventHandler(mapControl_MouseUp);
            gMapControl1.OnMarkerEnter += new MarkerEnter(mapControl_OnMarkerEnter);

            gMapControl1.Overlays.Add(markersOverlay);
            
            dataGridView2.AutoGenerateColumns = false;

            comboBoxcalc.Items.Clear();

            nameMaterialComboBox.Items.Clear();
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            MySqlConnection connection = new MySqlConnection(connect);
            try
            {
                connection.Open();

                MySqlCommand command1 = new MySqlCommand("SELECT * FROM materials", connection);
                MySqlDataReader oledbRead1 = command1.ExecuteReader();
                while (oledbRead1.Read())
                {
                    nameMaterialComboBox.Items.Add(oledbRead1["materialsname"]);
                }
                oledbRead1.Close();


                MySqlCommand command2 = new MySqlCommand("SELECT * FROM calculation WHERE iduser = " + idpeoples, connection);
                MySqlDataReader oledbRead2 = command2.ExecuteReader();
                while (oledbRead2.Read())
                {
                    comboBoxcalc.Items.Add(oledbRead2["nameobject"]);
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
        
        public double Search_f_k(double r)
        {
            double fk = 0;

            if (r <= 300)
            {
                fk = 0.17;
                return fk;
            }
            else if (r <= 700 & r >= 300)
            {
                fk = 0.22;
                return fk;
            }
            else
            {
                fk = 1;
                return fk;
            }
        }

        private double npeople(double r, double step, double Ro_zone_b, double Ro_zone_v)
        {
            double npeople = 0;
            double previousnpeople = 0;

            if (r <= 300)
            {
                npeople = 5;
                return npeople;
            }
            else if (r <= 700 & r >= 300)
            {
                previousnpeople = Math.PI * Math.Pow(r - step, 2) / 1000000;
                npeople = Math.PI * Math.Pow(r, 2) / 1000000;

                npeople = npeople - previousnpeople;
                npeople = npeople * Ro_zone_b;
                npeople = Math.Round(npeople, 0);
                return npeople;
            }
            else
            {
                previousnpeople = Math.PI * Math.Pow(r - step, 2) / 1000000;
                npeople = Math.PI * Math.Pow(r, 2) / 1000000;

                npeople = npeople - previousnpeople;
                npeople = npeople * Ro_zone_v;
                npeople = Math.Round(npeople, 0);
                return npeople;
            }
        }
        
        public double searcharr(double Pr)
        {
            double value = 0;
            value = Pr;

            if (Pr <= 2.67)
            {
                value = 0;
                return value;
            }

            else if (Pr > 8.09)
            {
                value = 100;
                return value;
            }

            else
            {
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if ((Pr <= PL[i, j]))
                        {
                            double abc = PL[i, j];
                            value = i * 10 + j + 1;
                            if (value > 100)
                            {
                                value = 100;
                            }
                            return value;
                        }
                    }
                }
            }
            return value;
        }

        public double[,] PL =
            {                   { 0.00, 2.67, 2.95, 3.12, 3.25, 3.36, 3.45, 3.52, 3.59, 3.66 },//0
                                { 3.72, 3.77, 3.82, 3.90, 3.92, 3.96, 4.01, 4.05, 4.08, 4.12 },//1
                                { 4.16, 4.19, 4.23, 4.26, 4.29, 4.33, 4.36, 4.39, 4.42, 4.45 },//2
                                { 4.48, 4.50, 4.53, 4.56, 4.59, 4.61, 4.64, 4.67, 4.69, 4.72 },//3
                                { 4.75, 4.77, 4.80, 4.82, 4.85, 4.87, 4.90, 4.92, 4.95, 4.97 },//4
                                { 5.00, 5.03, 5.05, 5.08, 5.10, 5.13, 5.15, 5.18, 5.20, 5.23 },//5
                                { 5.25, 5.28, 5.31, 5.33, 5.36, 5.39, 5.41, 5.44, 5.47, 5.50 },//6
                                { 5.52, 5.55, 5.58, 5.61, 5.64, 5.67, 5.71, 5.74, 5.77, 5.81 },//7
                                { 5.84, 5.88, 5.92, 5.95, 5.99, 6.04, 6.08, 6.13, 6.18, 6.23 },//8
                                { 6.28, 6.34, 6.41, 6.48, 6.55, 6.64, 6.75, 6.88, 7.05, 7.33 },//9
                                { 7.33, 7.37, 7.41, 7.46, 7.51, 7.58, 7.65, 7.75, 7.88, 8.09 },//10
            };

        public void nameMaterialComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            MySqlConnection connection = new MySqlConnection(connect);
            try
            {
                connection.Open();
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM materials", connection);
                MySqlDataReader oledbRead1 = command1.ExecuteReader();
                while (oledbRead1.Read())
                {
                    if (nameMaterialComboBox.Text == oledbRead1["materialsname"].ToString())
                    {
                        break;
                    }
                }
                String idmaterial = oledbRead1["idmaterials"].ToString();
                oledbRead1.Close();

                MySqlCommand command2 = new MySqlCommand("SELECT * FROM materials_Parameters WHERE idmaterial =" + idmaterial, connection);
                MySqlDataReader oledbRead2 = command2.ExecuteReader();


                while (oledbRead2.Read())
                {
                    if (oledbRead2["idparameters"].ToString() == "1")
                    {
                        Ro_liquid_label.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "2")
                    {
                        C_liqiud_label.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "3")
                    {
                        delta_H_kip_label.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "4")
                    {
                        t_kip_liquid_label.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "5")
                    {
                        M_label.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "6")
                    {
                        E_ud_label.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "7")
                    {
                        C_nkpr_label.Text = oledbRead2["value"].ToString();
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
        
        private void ChangeMaterialsLabels (int id)
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connect);
            try
            {
                connection.Open();

                MySqlCommand command2 = new MySqlCommand("SELECT * FROM materials_Parameters WHERE idmaterial =" + id, connection);
                MySqlDataReader oledbRead2 = command2.ExecuteReader();


                while (oledbRead2.Read())
                {

                    if (oledbRead2["idparameters"].ToString() == "1")
                    {
                        Ro_liquid_label.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "2")
                    {
                        C_liqiud_label.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "3")
                    {
                        delta_H_kip_label.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "4")
                    {
                        t_kip_liquid_label.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "5")
                    {
                        M_label.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "6")
                    {
                        E_ud_label.Text = oledbRead2["value"].ToString();
                    }
                    if (oledbRead2["idparameters"].ToString() == "7")
                    {
                        C_nkpr_label.Text = oledbRead2["value"].ToString();
                    }
                }
                oledbRead2.Close();


                MySqlCommand command1 = new MySqlCommand("SELECT * FROM materials WHERE idmaterials =" + id, connection);
                MySqlDataReader oledbRead1 = command1.ExecuteReader();
                while (oledbRead1.Read())
                {
                   nameMaterialComboBox.Text = oledbRead1["materialsname"].ToString();
  
                }
                
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




        public void comboBoxcalc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            MySqlConnection connection = new MySqlConnection(connect);
            try
            {
                connection.Open();
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM calculation", connection);
                MySqlDataReader oledbRead1 = command1.ExecuteReader();

                while (oledbRead1.Read())
                {
                    if (comboBoxcalc.Text == oledbRead1["nameobject"].ToString())
                    {
                        break;
                    }
                }
                String idcalculation = oledbRead1["idcalculation"].ToString();
                oledbRead1.Close();

                MySqlCommand command2 = new MySqlCommand("SELECT * FROM calculation WHERE idcalculation =" + idcalculation, connection);
                MySqlDataReader oledbRead2 = command2.ExecuteReader();


                while (oledbRead2.Read())
                {
                    if (oledbRead2["idcalculation"].ToString() == idcalculation.ToString())
                    {
                        nameobject.Text = oledbRead2["nameobject"].ToString();
                        V_reservuares_label.Text = oledbRead2["tankvolume"].ToString();
                        t_reservuares_label.Text = oledbRead2["temperature"].ToString();
                        S_of_park_label.Text = oledbRead2["parkarea"].ToString();
                        number_of_reservuares_label.Text = oledbRead2["numbersoftanks"].ToString();
                        deg_ocuuracy_label.Text = oledbRead2["fillingdegree"].ToString();
                        lymbda_pov_label.Text = oledbRead2["lyambdapov"].ToString();
                        Ro_pov_label.Text = oledbRead2["ropov"].ToString();
                        C_pov_label.Text = oledbRead2["cpov"].ToString();
                        latforcircle = Convert.ToDouble(oledbRead2["lat"].ToString());
                        lngforcircle = Convert.ToDouble(oledbRead2["lng"].ToString());
                        idmaterialfor = Convert.ToInt16(oledbRead2["idmaterial"].ToString());
                        ChangeMaterialsLabels(idmaterialfor);
                        int domino = Convert.ToInt16(oledbRead2["domino"].ToString());
                        ChangeDomino(domino);
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

        private void ChangeDomino(int domino)
        {
            if (domino == 0)
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }

        }

        private int Chkdomino()
        {
            if (checkBox1.Checked == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void Callculate_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            gMapControl1.Overlays.Clear();
            UserForm_Load(sender, e);
            GMapOverlay markers = new GMapOverlay(gMapControl1, "markers");

            
            Stopwatch SW = new Stopwatch(); 
            SW.Start(); 
            
            double p0 = 101325;
            double R = 8310;
            double fp_beton = 150;
            double nu = 1;

            double step = 0;

            //Физические свойства веществ и материалов
            double Ro_liquid = 0;
            double C_liqiud = 0;
            double delta_H_kip = 0;
            double t_kip_liquid = 0;
            double M = 0;
            double lymbda_pov = 0;
            double Ro_pov = 0;
            double C_pov = 0;
            double E_ud = 0;
            double C_nkpr = 0;

            //Свойства объекта хранения и прилегающейй территории
            double V_reservuares = 0;
            double t_reservuares = 0;
            double S_of_park = 0;
            double number_of_reservuares = 0;
            double deg_ocuuracy = 0;
            double number_of_staff = 5;
            double Ro_zone_b = 200;
            double Ro_zone_v = 2000;

            double summ_risk_a = 0;
            double summ_numbers_a = 0;
            double summ_risk_b = 0;
            double summ_numbers_b = 0;
            double summ_risk_c = 0;
            double summ_numbers_c = 0;


            //Расчет параметров поражающих факторов
            double impulse = 0;
            double Pr_explosion = 0;
            double V = 0;
            int kk = 0;
            int kk_a = 0;
            int kk_b = 0;
            int kk_c = 0;
            double q_fireball = 0;
            double E_f_pov = 350; 
            double F_q = 0;
            double r_r = 0; 
            double r = 0; 
            double Pr = 0;
            double delta_p = 0;

            string zone_a = "A";
            string zone_b = "B";
            string zone_c = "C";

            double t0 = 5;
            double x = 0;
            double u = 5;
            double t_blast = 0;
            double t_fire = 0;

            double Pr_pozhar_proliva = 0;
            double sr_ind_risk = 0;
            double total_potential_risk = 0;
            double total_numbers_of_people = 0;
            double numbers_of_people2 = 0;

            double C0 = 340;
            double teta = 7;
            double E = 1332858;
            double Rx_kr1 = 0.34;
            double U_fronta_plameni = 300;

            double H = 0; 
            double D_s = 0; 
            double m_g = 0;

            button3.Visible = true;

            chart2.Series[0].Points.Clear();
            chart2.ChartAreas[0].AxisX.Title = "Расстояние, м";
            chart2.ChartAreas[0].AxisY.Title = "Потенциальный риск, 1/год";

            void sr_risk_counter(double numbers_of_peoples, double steps, double Risk)
            {

                if (steps <= 300)
                {
                    summ_risk_a = summ_risk_a + Math.Round(Risk * 2 * 0.17, 2);
                    summ_numbers_a = number_of_staff;
                }

                else if (steps >= 300 & steps <= 700)
                {
                    summ_risk_b = summ_risk_b + Math.Round(Risk * numbers_of_peoples * 0.22, 2);
                    summ_numbers_b = summ_numbers_b + numbers_of_peoples;
                }

                else if (steps > 700)
                {
                    summ_risk_c = summ_risk_c + Math.Round(Risk * numbers_of_peoples, 2);
                    summ_numbers_c = summ_numbers_c + numbers_of_peoples;
                }

            }


            void koll_risk_counter(double numbers_of_peoples, double Risk)
            {
                koll_risk = koll_risk + Risk * numbers_of_peoples;
            }


            if (V_reservuares_label.Text == String.Empty ||
            t_reservuares_label.Text == String.Empty ||
            S_of_park_label.Text == String.Empty ||
            number_of_reservuares_label.Text == String.Empty ||
            deg_ocuuracy_label.Text == String.Empty 
            )
            {
                MessageBox.Show("Неверный ввод, заполните все ячейки", "Ошибка");

            }

            else if (latforcircle == 0 ||
            lngforcircle == 0)
            {
                MessageBox.Show("Укажите объект на карте", "Ошибка");
            }

            else
            {
                step = 50;// Convert.ToDouble(step_label.Text);

                //Физические свойства веществ и материалов
                Ro_liquid = Convert.ToDouble(Ro_liquid_label.Text);
                C_liqiud = Convert.ToDouble(C_liqiud_label.Text);
                delta_H_kip = Convert.ToDouble(delta_H_kip_label.Text);
                t_kip_liquid = Convert.ToDouble(t_kip_liquid_label.Text);
                M = Convert.ToDouble(M_label.Text);
                lymbda_pov = Convert.ToDouble(lymbda_pov_label.Text);
                Ro_pov = Convert.ToDouble(Ro_pov_label.Text);
                C_pov = Convert.ToDouble(C_pov_label.Text);
                E_ud = Convert.ToDouble(E_ud_label.Text);
                C_nkpr = Convert.ToDouble(C_nkpr_label.Text);
                //Свойства объекта хранения и прилегающейй территории
                V_reservuares = Convert.ToDouble(V_reservuares_label.Text);
                t_reservuares = Convert.ToDouble(t_reservuares_label.Text);
                S_of_park = Convert.ToDouble(S_of_park_label.Text);
                number_of_reservuares = Convert.ToDouble(number_of_reservuares_label.Text);
                deg_ocuuracy = Convert.ToDouble(deg_ocuuracy_label.Text);
            }
            

            if ((step > 49) && (deg_ocuuracy > 0) && (V_reservuares > 0) && (S_of_park > 0) && (number_of_reservuares > 0))
            {

                double P_v = number_of_reservuares * System.Math.Pow(10, (-6)) * 0.115;
                double P_o_sh = number_of_reservuares * System.Math.Pow(10, (-6)) * 0.2;
                double P_p_v = number_of_reservuares * System.Math.Pow(10, (-6)) * 0.077;

                if (checkBox1.Checked == true)
                {
                     m_g = number_of_reservuares * deg_ocuuracy * V_reservuares * Ro_liquid;

                }
                else
                {
                    m_g = deg_ocuuracy * V_reservuares * Ro_liquid;

                }

                ////////////////////////////////////////////////////////////////
                //Расчет количества опасного вещества, участвующего в аварии
                //double m_g = number_of_reservuares *  deg_ocuuracy * V_reservuares * Ro_liquid;

                //Количество жидкости, мгновенно вскипающей при
                //разгерметизации оборудования
                double G_mgn = Math.Round(m_g * (1 - Math.Exp(-((C_liqiud * ((t_reservuares + 273.15) - (t_kip_liquid + 273.15)) / delta_H_kip)))), 2);

                //Давление насыщенных паров сжиженного газа при
                //температуре окружающей среды
                double P_n = Math.Round(p0 * Math.Exp(((delta_H_kip * M) / R) * ((1 / (t_kip_liquid + 273.15)) - (1 / (t_reservuares + 273.15)))), 1);

                //Количество пара в свободном объеме резервуара 
                double G_sv = Math.Round((1 - deg_ocuuracy) * M / R * ((P_n * V_reservuares) / (273.15 + t_reservuares)), 2);

                //Площадь пролива жидкости,
                //оставшейся после мгновенного вскипания
                double Vg = (m_g - G_mgn);
                double F_g = Math.Round((fp_beton * Vg) / Ro_liquid, 2);

                //Ограничение плошади обвалования 
                if (F_g > S_of_park)
                {
                    F_g = S_of_park;
                }


                //Масса паров, образующихся при кипении пролива
                double e_pov = Math.Round(Math.Sqrt(lymbda_pov * Ro_pov * C_pov), 2);
                double G_parov = Math.Round(2 * (t_reservuares - t_kip_liquid) / delta_H_kip * (e_pov / Math.Sqrt(3.14)) * F_g * Math.Sqrt(3600), 2);

                //Интенсивность испарения из пролива, обусловленного
                //диффузионными процессами
                double W = Math.Round(System.Math.Pow(10, (-6)) * nu * Math.Sqrt(M) * p0 / 1000, 6);

                //Общее количество испарившейся жидкости
                double G_isp = Math.Round(W * S_of_park * 3600, 2);

                //Суммарное количество пара, участвующего в образовании
                //паровоздушного облака
                double m = Math.Round(G_mgn + G_sv + G_parov + G_isp, 2);

                //Заполнение таблиц
                for (double i = 0; i <= S_of_park; i = i + 100/*step*/)
                {

                    if (i >= S_of_park + 1)
                    {
                        break;
                    }

                    r = i;

                    //взрыв


                    double Rx = r / Math.Pow(E / p0, 0.33);

                    Rx = Rx / 100;
                    if (Rx < Rx_kr1)
                    {
                        Rx = Rx_kr1;
                    }

                    //избыточное давление
                    double Px = Math.Pow(U_fronta_plameni, 2) / Math.Pow(C0, 2) * ((teta - 1) / teta) * (0.83 / Rx - (0.14 / Math.Pow(Rx, 2)));
                    double WW = U_fronta_plameni / C0 * (teta - 1) / teta;
                    double Ix = WW * (1 - 0.4 * WW) * (0.06 / Rx + 0.01 / Math.Pow(Rx, 2) + 0.0025 / Math.Pow(Rx, 3));

                    delta_p = Math.Round(Px * p0 / 1000, 2);
                    impulse = Math.Round(Ix * Math.Pow(p0, 0.66) * Math.Pow(E, 0.33) * (teta - 1 / teta) * 10 / C0, 2);//0.85=E*teta-1/teta

                    V = Math.Pow((17500 / 1000 / delta_p), 8.4) + Math.Pow((290 / impulse), 9.3);
                    Pr_explosion = Math.Round(5 - (0.26 * Math.Log(V)), 2);

                    double pl2 = searcharr(Pr_explosion);


                    //огненный шар
                    D_s = Math.Round(6.48 * Math.Pow(m_g, 0.325), 2);  //Диаметр огненного шара
                    H = D_s;  //Величина H принимается равной D_s

                    F_q = Math.Pow(D_s, 2) / (4 * ((Math.Pow(H, 2) + Math.Pow(i, 2))));
                    r_r = Math.Exp(-7.0 * Math.Pow(10, -4) * (Math.Sqrt(Math.Pow(i, 2) + (Math.Pow(H, 2))) - (D_s / 2)));

                    q_fireball = Math.Round(E_f_pov * F_q * r_r, 2);

                    t_blast = 0.92 * Math.Pow(m, 0.303);
                    Pr = Math.Round(-12.8 + (2.56 * Math.Log(t_blast * Math.Pow(q_fireball, 1.33))), 2);

                    if (q_fireball < 4)
                    {
                        double o = i;
                        x = o - i;
                    }

                    //пожар пролива
                    t_fire = t0 + x / u;
                    Pr_pozhar_proliva = Math.Round(-12.8 + 2.56 * Math.Log(t_fire * Math.Pow(q_fireball, 1.3)), 2);

                    double pl1 = searcharr(Pr);

                    double pl3 = searcharr(Pr_pozhar_proliva);

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[kk].Cells[0].Value = (i).ToString();
                    dataGridView1.Rows[kk].Cells[1].Value = (q_fireball).ToString();
                    dataGridView1.Rows[kk].Cells[2].Value = (Pr).ToString();
                    dataGridView1.Rows[kk].Cells[3].Value = (pl1).ToString();
                    dataGridView1.Rows[kk].Cells[4].Value = (delta_p).ToString();
                    dataGridView1.Rows[kk].Cells[5].Value = (Math.Round(impulse/1000,2)).ToString();
                    dataGridView1.Rows[kk].Cells[6].Value = (Pr_explosion).ToString();
                    dataGridView1.Rows[kk].Cells[7].Value = (pl2).ToString();
                    dataGridView1.Rows[kk].Cells[8].Value = (pl3).ToString();

                    //расчет рисков
                    double pot_ogn_schsr =Math.Round (P_o_sh * pl1 * 10000,2);
                    double pot_v = Math.Round(P_v * pl2 * 10000,2);
                    double pot_p_pr = Math.Round(P_p_v * pl3 * 10000,2);

                    double ri = pot_ogn_schsr + pot_v + pot_p_pr;

                    numbers_of_people2 = npeople(r, 100, Ro_zone_b, Ro_zone_v);

                    total_potential_risk = total_potential_risk + (ri * numbers_of_people2 * Search_f_k(r));
                    total_numbers_of_people = total_numbers_of_people + numbers_of_people2;

                    sr_ind_risk = Math.Round(sr_ind_risk + total_potential_risk / total_numbers_of_people, 2);
                    
                    dataGridView2.Rows.Add();

                    if (i <= 300)
                    {
                        dataGridView2.Rows[kk].Cells[0].Value = (zone_a).ToString();

                    }

                    else if (i >= 300 & i <= 700)
                    {
                        dataGridView2.Rows[kk].Cells[0].Value = (zone_b).ToString();
                    }

                    else if (i > 700)
                    {
                        dataGridView2.Rows[kk].Cells[0].Value = (zone_c).ToString();
                    }

                    sr_risk_counter(numbers_of_people2, r, ri);
                    koll_risk_counter(numbers_of_people2, ri);


                    dataGridView2.Rows[kk].Cells[1].Value = (i).ToString();
                    dataGridView2.Rows[kk].Cells[2].Value = (pot_ogn_schsr).ToString();
                    dataGridView2.Rows[kk].Cells[3].Value = (pot_v).ToString();
                    dataGridView2.Rows[kk].Cells[4].Value = (pot_p_pr).ToString();
                    dataGridView2.Rows[kk].Cells[5].Value = (ri).ToString();
                    dataGridView2.Rows[kk].Cells[6].Value = (numbers_of_people2).ToString();

                    if (r == 300)
                    {
                        kk_a = kk;
                    }
                    else if (r == 700)
                    {
                        kk_b = kk;
                    }
                    else if (r == S_of_park)
                    {
                        kk_c = kk;
                    }
                    chart2.ChartAreas[0].AxisX.Minimum = 0;
                    chart2.ChartAreas[0].AxisX.Maximum = S_of_park;
                    chart2.Series[0].Points.AddXY(i, ri);
                    kk = kk + 1;
                }

                int counttmp = kk / 5;
                int steplegend = 0;
                int bb = kk;
                Graphics g;
                Brush br;
                pictureBox2.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics gg = Graphics.FromImage(pictureBox2.Image);

                for (double i = S_of_park; i > 0; i = i - 100)
                {
                    kk = kk - 1;

                    double ri_max = Convert.ToDouble(dataGridView2[5, 0].Value);
                    double ri_iter = Convert.ToDouble(dataGridView2[5, kk].Value) / ri_max * 10;

                    label36.Text = ri_max.ToString();
                    label35.Text = Convert.ToDouble(dataGridView2[5, bb - 1].Value).ToString();


                    CreateCircle(latforcircle, lngforcircle, i, ri_iter, markers, S_of_park);
                    CreateMarker(latforcircle, lngforcircle, markers);



                    double red = Math.Round(255 * ri_iter, 0);
                    double green = Math.Round(255 - (255 * ri_iter), 0);
                    if (red > 255)
                    {
                        red = 255;
                    }
                    if (red < 1)
                    {
                        red = 1;
                    }
                    if (green > 255)
                    {
                        green = 255;
                    }
                    if (green < 1)
                    {
                        green = 1;
                    }

                    g = CreateGraphics();
                    if (counttmp == 0)
                    {
                        counttmp = 1;
                    }
                    if (kk % counttmp == 0)
                    {

                        br = new SolidBrush(Color.FromArgb(100, Color.FromArgb(Convert.ToInt32(red), Convert.ToInt32(green), 0)));
                        gg.FillRectangle(br, new Rectangle(steplegend, 10, 400, 46));
                        steplegend = steplegend + 200;
                    }
                }
                sr_ind_risk_a = Math.Round(summ_risk_a / summ_numbers_a, 2);
                dataGridView2.Rows[kk_a].Cells[7].Value = (sr_ind_risk_a*10).ToString();

                sr_ind_risk_b = Math.Round(summ_risk_b / summ_numbers_b, 2);
                dataGridView2.Rows[kk_b].Cells[7].Value = (sr_ind_risk_b*10).ToString();

                sr_ind_risk_c = Math.Round(summ_risk_c / summ_numbers_c, 2);
                dataGridView2.Rows[kk_c].Cells[7].Value = (sr_ind_risk_c*10).ToString();

                koll_risk = Math.Round(koll_risk / 1000, 2);
                dataGridView2.Rows[kk_c].Cells[8].Value = (koll_risk).ToString();

                MessageBox.Show("Расчеты параметров поражающих факторов и показателей риска представлены в таблицах", "Резальтат");
            }
            else
            {
                MessageBox.Show("Укажите верно все технологические параметры и отметьте объект на карте", "Помощь");
            }
            SW.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выберите вешество, укажите параметры резервуарного парка, шаг, и нажмите рассчитать.", "Помошь");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeForm f4 = new HomeForm();
            this.Hide();
            f4.Show();
        }

        
        public void Export_Data_To_Word(DataGridView DGV,DataGridView DGV2, string filename)

        {
            Word.Document oDoc = new Word.Document();
            oDoc.Application.Visible = false;

            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            Word.Paragraph objPara;

            objPara = oDoc.Paragraphs.Add();
            objPara.Range.Font.Name = "Tahoma";
            objPara.Range.Font.Size = 10;

            objPara.Range.Text = "Исходные данные:" + "\r\n";
            objPara.Range.Text = "Вещество, содержащееся в резервуарах: " + nameMaterialComboBox.Text + "\r\n";
            objPara.Range.Text = "Площадь парка: " + S_of_park_label.Text + "м^2\r\n";
            objPara.Range.Text = "Количество резервуаров: " + number_of_reservuares_label.Text + "шт.\r\n";
            objPara.Range.Text = "Степень заполненности: " + deg_ocuuracy_label.Text + "%\r\n";
            objPara.Range.Text = "Объем резервуара: " + V_reservuares_label.Text + "л\r\n"; ;
            objPara.Range.Text = "Температура жидкости в резервуаре: " + t_reservuares_label.Text + "°C\r\n";
            objPara.Range.Text = "Средний индивидуальный риск зоны А: " + sr_ind_risk_a + " 1/год*10⁻⁷\r\n";
            objPara.Range.Text = "Средний индивидуальный риск зоны Б: " + sr_ind_risk_b + " 1/год*10⁻⁷\r\n";
            objPara.Range.Text = "Средний индивидуальный риск зоны В: " + sr_ind_risk_c + " 1/год*10⁻⁸\r\n";
            objPara.Range.Text = "Коллективный риск: " + koll_risk + " 1/год*10⁻³\r\n";

            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;

                Object[,] DataArray = new object[RowCount * 2 + 2, ColumnCount];
                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";

                int r = 0;

                 for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    DataArray[0, c] = DGV.Columns[c].HeaderText;
                }
                 for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 1; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    }
                }

                 for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    DataArray[RowCount, c] = DGV.Columns[c].HeaderText;
                }
                 for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 1; r <= RowCount - 1; r++)
                    {
                        DataArray[RowCount + r, c] = DGV.Rows[r].Cells[c].Value;
                    }
                }

                int dataRowCount = RowCount * 2 + 1;
                int dataColomnCount = ColumnCount;

                for (r = 0; r <= dataRowCount - 1; r++)
                {
                    for (int c = 0; c <= dataColomnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                 oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref dataRowCount, ref dataColomnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Calibri";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 10;

            }

             foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
            {
                Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                headerRange.Text = "Отчёт о моделировании";
                headerRange.Font.Size = 12;
                headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
            
            oDoc.SaveAs2(filename);
            oDoc.Close();

        }


        private void button3_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "Отчёт о моделировании.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Export_Data_To_Word(dataGridView1,dataGridView2, sfd.FileName);
            }
            
        }


        private void V_reservuares_label_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

             if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void t_reservuares_label_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

             if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void S_of_park_label_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') )
            {
                e.Handled = true;
            }

             if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void number_of_reservuares_label_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

             if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void deg_ocuuracy_label_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

             if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }


        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dataGridView2.AdvancedCellBorderStyle.Top;
            }

        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }
        

        void mapControl_MouseUp(object sender, MouseEventArgs e)
        {
             if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isLeftButtonDown = false;
            }
        }

        void mapControl_MouseDown(object sender, MouseEventArgs e)
        {
             if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isLeftButtonDown = true;
            }
        }

        void mapControl_OnMarkerEnter(GMapMarker item)
        {
            if (item is GMapMarkerImage)
            {
                currentMarker = item as GMapMarkerImage;
             }
        }

        

        void mapControl_MouseClick(object sender, MouseEventArgs e)
        {

             if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
 
                markersOverlay.Markers.Clear();
                PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                 
                Bitmap bitmap = Bitmap.FromFile(Application.StartupPath + @"\marker.png") as Bitmap;
 
                GMapMarker marker = new GMapMarkerImage(point, bitmap);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                latforcircle = point.Lat;
                lngforcircle = point.Lng;
                latposition = point.Lat;
                lngposotion = point.Lng;

                 markersOverlay.Markers.Add(marker);
            }
        }
         void mapControl_OnMapZoomChanged()
        {
        }

        int Alpha(double s_park)
        {
            if (s_park > 2000)
            {
                return 1;
            }
            else
            {
                double tmp = 10000 / s_park;
                 int alpha = Convert.ToInt32(tmp);
                return alpha;
            }

        }


        private void CreateMarker(Double lat,Double lon, GMapOverlay markers)
        {
            PointLatLng point = new PointLatLng(lat, lon);

 
            Bitmap bitmap = Bitmap.FromFile(Application.StartupPath + @"\marker.png") as Bitmap;
 
            GMapMarker marker = new GMapMarkerImage(point, bitmap);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
 
            marker.ToolTipText = string.Format("{0},{1}, {2}{3}{4}", point.Lat, point.Lng, "Радиус  ", S_of_park_label.Text, "m^2");
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);

        }




        private void CreateCircle(Double lat, Double lon, double radius, double ri_iter, GMapOverlay markers, double S_park)
        {
            PointLatLng point = new PointLatLng(lat, lon);
            int segments = 1080;

            List<PointLatLng> gpollist = new List<PointLatLng>();

            for (int i = 0; i < segments; i++)
            {
                gpollist.Add(FindPointAtDistanceFrom(point, i * (Math.PI / 180), radius / 1000));
            }

            GMapPolygon polygon = new GMapPolygon(gpollist, "Circle");
            double red =  Math.Round(255 * ri_iter,0);
            double green = Math.Round(255 - (255 * ri_iter),0);
            if (red > 255)
            {
                red = 255;
            }
            if (red < 1)
            {
                red = 1;
            }
            if (green > 255)
            {
                green = 255;
            }
            if (green < 1)
            {
                green = 1;
            }
            int alpha = Alpha(S_park);



            polygon.Fill = new SolidBrush(Color.FromArgb(3, Color.FromArgb(Convert.ToInt32(red), Convert.ToInt32(green), 0)));
            double x = 0.000000001;
            float a = (float)x;

            polygon.Stroke = new Pen(Color.BlanchedAlmond, a);
            markers.Polygons.Add(polygon);
            
            gMapControl1.Overlays.Add(markers);

        }

        public static GMap.NET.PointLatLng FindPointAtDistanceFrom(GMap.NET.PointLatLng startPoint, double initialBearingRadians, double distanceKilometres)
        {
            const double radiusEarthKilometres = 6371.01;
            var distRatio = distanceKilometres / radiusEarthKilometres;
            var distRatioSine = Math.Sin(distRatio);
            var distRatioCosine = Math.Cos(distRatio);

            var startLatRad = DegreesToRadians(startPoint.Lat);
            var startLonRad = DegreesToRadians(startPoint.Lng);

            var startLatCos = Math.Cos(startLatRad);
            var startLatSin = Math.Sin(startLatRad);

            var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));
            var endLonRads = startLonRad + Math.Atan2(Math.Sin(initialBearingRadians) * distRatioSine * startLatCos, distRatioCosine - startLatSin * Math.Sin(endLatRads));

            return new GMap.NET.PointLatLng(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads));
        }

        public static double DegreesToRadians(double degrees)
        {
            const double degToRadFactor = Math.PI / 180;
            return degrees * degToRadFactor;
        }

        public static double RadiansToDegrees(double radians)
        {
            const double radToDegFactor = 180 / Math.PI;
            return radians * radToDegFactor;
        }

        private void gMapControl1_OnMapZoomChanged()
        {
            trackBar1.Value = (int)gMapControl1.Zoom;

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            gMapControl1.Zoom = trackBar1.Value;
        }

        private void Savemap_button_Click(object sender, EventArgs e)
        {
            try
            {
 
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
 
                    dialog.Filter = "PNG (*.png)|*.png";
 
                    dialog.FileName = "Снимок карты";
 
                    Image image = gMapControl1.ToImage();

                    if (image != null)
                    {
                        using (image)
                        {
 
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
 
                                string fileName = dialog.FileName;
 
                                if (!fileName.EndsWith(".png",
                                StringComparison.OrdinalIgnoreCase))
                                {
                                    fileName += ".png";
                                }
                                 image.Save(fileName);

                                 MessageBox.Show("Карта успешно сохранена в директории： "
                                + Environment.NewLine
                                + dialog.FileName, "GMap.NET",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                 MessageBox.Show("Ошибка при сохранении карты： "
                + Environment.NewLine
                + exception.Message,
                "GMap.NET",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand);
            }
        }


        private DataTable ToDataTable(DataGridView dataGridView1, DataGridView dataGridView2)
        {
            var dt = new DataTable();

            foreach (DataGridViewColumn dataGridViewColumn in dataGridView1.Columns)
            {
                if (dataGridViewColumn.Visible)
                {
                    dt.Columns.Add();
                }
            }
            var cell = new object[dataGridView1.Columns.Count];

            foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
            {
                for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
                {
                    cell[i] = dataGridViewRow.Cells[i].Value;
                }
                dt.Rows.Add(cell);
            }

            foreach (DataGridViewColumn dataGridViewColumn in dataGridView2.Columns)
            {
                if (dataGridViewColumn.Visible)
                {
                    dt.Columns.Add();
                }
            }

            foreach (DataGridViewRow dataGridViewRow in dataGridView2.Rows)
            {
                for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
                {
                    cell[i] = dataGridViewRow.Cells[i].Value;
                }
                dt.Rows.Add(cell);
            }

            return dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (nameobject.Text == String.Empty || V_reservuares_label.Text == String.Empty ||
            t_reservuares_label.Text == String.Empty ||
            S_of_park_label.Text == String.Empty ||
            number_of_reservuares_label.Text == String.Empty ||
            deg_ocuuracy_label.Text == String.Empty)
            {
                MessageBox.Show("Для сохранения параметров расчета необходимо заполнить все поля технологических параметров", "Ошибка сохранения");
            }

            else if (latforcircle == 0 || lngforcircle == 0)

            {
                MessageBox.Show("Отстутствуют координаты объекта", "Ошибка сохранения");

            }

            else
            {
                string connect = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

 
                MySqlConnection connection = new MySqlConnection(connect);

                try
                {

                    connection.Open();


                    MySqlCommand command1 = new MySqlCommand("SELECT * FROM materials", connection);
                    MySqlDataReader oledbRead1 = command1.ExecuteReader();
                    while (oledbRead1.Read())
                    {
                        if (nameMaterialComboBox.Text == oledbRead1["materialsname"].ToString())
                        {
                             break;
                        }
                    }
                     String idmaterial = oledbRead1["idmaterials"].ToString();
                    oledbRead1.Close();

                    int chkdomino = Chkdomino();

                    String strSQL2;
                    strSQL2 = "Insert into calculation (nameobject,iduser,idmaterial,tankvolume,temperature,parkarea,numbersoftanks,fillingdegree,lat,lng,lyambdapov,ropov,cpov,domino) " + "value ('" + nameobject.Text + "', '" + idpeoples + "' , '" + idmaterial + "' , '" + V_reservuares_label.Text + "', '" + t_reservuares_label.Text + "' ,'" + S_of_park_label.Text + "' ,'" + number_of_reservuares_label.Text + "' ,'" + deg_ocuuracy_label.Text + "' ,'" + latforcircle + "' ,'" + lngforcircle + "' ,'" + lymbda_pov_label.Text + "' ,'" + Ro_pov_label.Text + "','" + C_pov_label.Text + "','" + chkdomino + "' )";

                    MySqlCommand command0 = new MySqlCommand(strSQL2, connection);
                    command0.ExecuteNonQuery();
                    System.Windows.Forms.MessageBox.Show("Ваш расчёт успешно сохранен в базу данных");
                       comboBoxcalc.Items.Clear();

                    MySqlCommand command2 = new MySqlCommand("SELECT * FROM calculation WHERE iduser = " + idpeoples, connection);
                    MySqlDataReader oledbRead2 = command2.ExecuteReader();
                    while (oledbRead2.Read())
                    {
                        comboBoxcalc.Items.Add(oledbRead2["nameobject"]);
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
        }

        private void clearlabels_Click(object sender, EventArgs e)
        {
            nameobject.Text = "";
            V_reservuares_label.Text = "";
            t_reservuares_label.Text = "";
            S_of_park_label.Text = "";
            number_of_reservuares_label.Text = "";
            deg_ocuuracy_label.Text = "";
            lymbda_pov_label.Text = "";
            Ro_pov_label.Text = "";
            C_pov_label.Text = "";
            latforcircle = 0;
            lngforcircle = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            UserForm_Load(sender, e);
         }
    }
}
