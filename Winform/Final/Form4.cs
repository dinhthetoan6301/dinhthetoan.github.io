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
    public partial class Form4 : Form
    {
        string connectionsString = @"Data Source=LAPTOP-CGN63Q67\FLOWER; Initial Catalog = Final; Persist Security Info=True;User ID =Flower; Password=123";
        public Form4()
        {
            InitializeComponent();
            LoadData(); 
        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionsString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select oID as 'ID', dhFullname as 'Customer Name', dhName as 'Pizza Name', dhSize as 'Size', dhType as 'Đế', dhOther as 'Phô Mai', dhAddress as 'Address', dhNumber as 'Number', dhStatus as 'Status' from DatHang", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable d = new DataTable();
                adapter.Fill(d);
                if (d.Rows.Count > 0)
                {
                    grid_Donhang.DataSource = d;
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtStaffaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStaffnumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new TuyChon().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionsString))
            {
                conn.Open();
                string find = "Select oID as 'ID', dhFullname as 'Customer Name', dhName as 'Pizza Name', dhSize as 'Size', dhType as 'Đế', dhOther as 'Phô Mai', dhAddress as 'Address', dhNumber as 'Number', dhStatus as 'Status' from DatHang where oID like '%" + txtorderID.Text + "%'";
                SqlCommand fi = new SqlCommand(find, conn);
                SqlDataAdapter a = new SqlDataAdapter(fi);
                DataTable t = new DataTable();
                a.Fill(t);
                grid_Donhang.DataSource = t;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionsString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update DatHang set dhStatus = N'Xác Nhận' where oID like '%" + txtorderID.Text + "%'", conn);
                SqlDataAdapter a1 = new SqlDataAdapter(cmd);
                DataTable t1 = new DataTable();
                a1.Fill(t1);
                grid_Donhang.DataSource = t1;
                LoadData();
            }
        }
    }
}
