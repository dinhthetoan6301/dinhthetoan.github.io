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
    public partial class Form3 : Form
    {
        string connectionsString = @"Data Source=LAPTOP-CGN63Q67\FLOWER; Initial Catalog = Final; Persist Security Info=True;User ID =Flower; Password=123";

        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullname.Text))
            {
                MessageBox.Show("Plaease enter your Full Name!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Plaease enter your Address!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNumber.Text))
            {
                MessageBox.Show("Plaease enter your Phone Number!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumber.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Plaease enter your Username!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Plaease enter your Password!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtConfirm.Text))
            {
                MessageBox.Show("Plaease enter Confirm Password!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirm.Focus();
                return;
            }
            if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("Password and Confirm Password don't match!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirm.Focus();
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionsString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("userAdd", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@userName", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@userFullname", txtFullname.Text.Trim());
                cmd.Parameters.AddWithValue("@userAddress", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@userPassword", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@userNumber", txtNumber.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully!");
                new Form1().Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }
    } 
}
