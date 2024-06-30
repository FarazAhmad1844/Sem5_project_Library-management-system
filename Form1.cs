using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usernametb_MouseEnter(object sender, EventArgs e)
        {

        }

        private void usernametb_MouseClick(object sender, MouseEventArgs e)
        {
             if (usernametb.Text == "Username")
            {
                usernametb.Clear();
            }
        }

        private void Passwordtb_MouseClick(object sender, MouseEventArgs e)
        {
            if (Passwordtb.Text == "Password")
            {
                Passwordtb.Clear();
                Passwordtb.PasswordChar = '*';

            }
        }

        private void Passwordtb_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string cs = "Data Source=FARAZ-AHMAD\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            string query="select * from logintabel where username='"+usernametb.Text+"' and pass ='" +Passwordtb.Text+ "'";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();

            try
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable ds = new DataTable();

                da.Fill(ds);



                if (ds.Rows.Count != 0)
                {
                    this.Hide();
                    Dashboard dsa = new Dashboard();
                    dsa.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Username OR Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                con?.Close();
            }

        }
    }
}
