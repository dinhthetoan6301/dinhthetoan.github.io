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
    public partial class Bill : Form
    {
        string connectionsString = @"Data Source=LAPTOP-CGN63Q67\FLOWER; Initial Catalog = Final; Persist Security Info=True;User ID =Flower; Password=123";
        public Bill()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionsString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select oID as 'ID', oDate as 'Date', oPrice as 'Price' from Bill", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable d = new DataTable();
                adapter.Fill(d);
                if (d.Rows.Count > 0)
                {
                    grid_Bill.DataSource = d;
                }
            }
        }
        private void Bill_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new TuyChon().Show();
            this.Hide();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
