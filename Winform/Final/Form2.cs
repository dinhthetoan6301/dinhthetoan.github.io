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
    public partial class Form2 : Form
    {
        string connectionsString = @"Data Source=LAPTOP-CGN63Q67\FLOWER; Initial Catalog = Final; Persist Security Info=True;User ID =Flower; Password=123";
        public Form2()
        {
            InitializeComponent();
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionsString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select userFullname as 'Full Name', userName as 'Username', userPassword as 'Password', userAddress as 'Addresss', userNumber as 'Number', userCMND as 'CMND' from Users", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable d = new DataTable();
                adapter.Fill(d);
                if (d.Rows.Count > 0)
                {
                    grid_Staff.DataSource = d;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionsString))
            {
                conn.Open();
                string find = "Select userFullname as 'Full Name', userName as 'Username', userPassword as 'Password', userAddress as 'Addresss', userNumber as 'Number', userCMND as 'CMND' from Users where userName like '%" + txtUsername.Text + "%'";
                SqlCommand fi = new SqlCommand(find, conn);
                SqlDataAdapter a = new SqlDataAdapter(fi);
                DataTable t = new DataTable();
                a.Fill(t);
                grid_Staff.DataSource = t;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionsString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Users set userFullname ='" + txtFullname.Text + "', userPassword ='" + txtPassword.Text + "', userAddress ='" + txtAddress.Text + "', userNumber ='" + txtNumber.Text + "', userCMND ='" + txtCMND.Text + "' where userName like '%" + txtUsername.Text + "%'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtFullname.Text = rdr[0].ToString();
                    txtPassword.Text = rdr[1].ToString();
                    txtAddress.Text = rdr[2].ToString();
                    txtNumber.Text =  rdr[3].ToString();
                    txtCMND.Text =  rdr[4].ToString();
                }
                MessageBox.Show("Update Succesfully!");
                LoadData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionsString))
            {
                conn.Open();
                string del = "delete from Users where userName like '%" + txtUsername.Text + "%'";
                DialogResult result = MessageBox.Show("Are You Sure?", "Connection String", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SqlCommand de = new SqlCommand(del, conn);
                    int row = de.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("Successfully!");
                    }
                    else
                        return;
                }
                LoadData();
            }
        }

        private void grid_Staff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {
            new TuyChon().Show();
            this.Hide();
        }
    }
}
