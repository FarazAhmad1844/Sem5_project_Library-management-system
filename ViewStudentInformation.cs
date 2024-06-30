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
    public partial class ViewStudentInformation : Form
    {
        public ViewStudentInformation()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void ViewStudentInformation_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
    


            string cs = "Data Source=FARAZ-AHMAD\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            string quary = "select* from NewStudent";
            SqlDataAdapter da = new SqlDataAdapter(quary, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse((dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
            }
            panel2.Visible = true;

            string cs = "Data Source=FARAZ-AHMAD\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            string quary = "select* from NewBook where bid=" + bid + "";
            SqlDataAdapter da = new SqlDataAdapter(quary, con);
            DataSet dt = new DataSet();
            da.Fill(dt);

            //rowid = Int64.Parse(dt.Tables[0].Rows[0][0].ToString());

            txtName.Text = dt.Tables[0].Rows[0][1].ToString();
           txtEnrollement.Text = dt.Tables[0].Rows[0][2].ToString();
             txtDepartment.Text = dt.Tables[0].Rows[0][3].ToString();
            txtSemester.Text = dt.Tables[0].Rows[0][4].ToString();
            txtContact.Text = dt.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = dt.Tables[0].Rows[0][6].ToString();
        }
    }
}
