using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Final
{
    public partial class Form5 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-CGN63Q67\FLOWER; Initial Catalog = Final; Persist Security Info=True;User ID =Flower; Password=123");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public Form5()
        {
            InitializeComponent();
            LoadData(); 
        }
        private void LoadData()
        {
            connect.Open();
            cmd = new SqlCommand("select oID as 'ID', oPrice as 'Price' from Bill order by oID", connect);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                grid_Donhang.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Data");
            }

            connect.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new TuyChon().Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            connect.Open();
            cmd = new SqlCommand("select SUM(oPrice) as 'Doanh Thu' from Bill", connect);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                grid_Donhang.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Data");
            }

            connect.Close();
        }
    }
}
