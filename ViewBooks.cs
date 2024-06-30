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
namespace Library_Management_System
{
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;


            string cs = "Data Source=FARAZ-AHMAD\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            string quary = "select* from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(quary, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("user data will be Deleted. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string cs = "Data Source=FARAZ-AHMAD\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                string query = "delete from NewBook where bid='" + rowid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Deleted Successfully");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
               bid= int.Parse((dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
            }
            panel2.Visible = true;

            string cs = "Data Source=FARAZ-AHMAD\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            string quary = "select* from NewBook where bid="+bid+"";
            SqlDataAdapter da = new SqlDataAdapter(quary, con);
            DataSet dt = new DataSet();
            da.Fill(dt);

            rowid = Int64.Parse(dt.Tables[0].Rows[0][0].ToString());

            txtBName.Text = dt.Tables[0].Rows[0][1].ToString();
            txtAuthor.Text= dt.Tables[0].Rows[0][2].ToString();
            txtPublication.Text= dt.Tables[0].Rows[0][3].ToString();
            txtPDate.Text= dt.Tables[0].Rows[0][4].ToString();
            txtPrice.Text= dt.Tables[0].Rows[0][5].ToString();
            txtQuantity.Text= dt.Tables[0].Rows[0][6].ToString();


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("user data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string cs = "Data Source=FARAZ-AHMAD\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                string query = "update NewBook set bName=@bname  ,bAuthor=  @bauthor,bPubl=@publication ,bPDate=@pdate ,bPrice=@price, bQuan=@quan where bid='" + rowid + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@bname", txtBName.Text);
                cmd.Parameters.AddWithValue("@bauthor", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@publication", txtPublication.Text);
                cmd.Parameters.AddWithValue("@pdate", txtPDate.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@quan", txtQuantity.Text);

                con.Open();
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Updated Successfully");


                txtBName.Text = "";
                txtAuthor.Text = "";
                txtPublication.Text = "";
                txtPDate.Text = "";
                txtPrice.Text = "";
                txtQuantity.Text = "";

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}       
