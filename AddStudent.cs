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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEnrollement.Clear();
            txtDepartment.Clear();
            txtSemester.Clear();
            txtEmail.Clear();
            txtContact.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtEnrollement.Text!="" && txtEmail.Text!= "" && txtDepartment.Text != "" && txtContact.Text != "" && txtSemester.Text != "")
            {
                string cs = "Data Source=FARAZ-AHMAD\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into NewStudent (sname,enroll,dep,sem,contact,email) values(@name,@enroll,@dep,@sem,@contact,@email)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@enroll", txtEnrollement.Text);
                cmd.Parameters.AddWithValue("@dep", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@sem", txtSemester.Text);
                cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                con.Open();
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Student Added Successfully");
            }
            else
            {
                MessageBox.Show("Please Fill Empty Fields", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
