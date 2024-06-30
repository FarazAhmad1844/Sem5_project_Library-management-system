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
using Crud.classes;

namespace Library_Management_System
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
         
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPrice.Text != "" && txtPublication.Text != "" && txtQuantity.Text != "")
            {
                string cs = "Data Source=FARAZ-AHMAD\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into NewBook (bName,bAuthor,bPubl,BPDate,bPrice,bQuan) values(@bname,@bauthor,@publication,@pdate,@price,@quan)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@bname", txtBookName.Text);
                cmd.Parameters.AddWithValue("@bauthor", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@publication", txtPublication.Text);
                cmd.Parameters.AddWithValue("@pdate", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@price", txtBookName.Text);
                cmd.Parameters.AddWithValue("@quan", txtBookName.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New Book Added Successfully");


                txtBookName.Text="";
                txtAuthor.Text="";
                txtPublication.Text="";
                dateTimePicker1.Text="";
                txtPrice.Text="";
                txtQuantity.Text="";

            }
            else
            {
                MessageBox.Show("Please Fill All Data");
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete your unsave data!", "Are you sure?", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
             {
                this.Close();
            }
        }
    }
}
