using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLLTNETNHOM2
{
    public partial class addstudent : Form
    {
        public addstudent()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("confirm?","alert",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtTensv.Clear();
            txtLop.Clear();
            txtMasv.Clear();
            //txtEmail.Clear();
            txtEmail.Text = "";
            txtSDT.Clear();
            txtHocKy.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTensv.Text != "" && txtLop.Text != "" && txtMasv.Text != "" && txtEmail.Text != "" && txtHocKy.Text != "" && txtSDT.Text != "")
            {
                string name = txtTensv.Text;
                string enroll = txtMasv.Text;
                string dep = txtLop.Text;
                string sem = txtHocKy.Text;
                Int64 mobile = Int64.Parse(txtSDT.Text);
                string email = txtEmail.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HUYHIEU;database = library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent (sname, enroll,dep,sem,contact,email) values ('" + name + "','" + enroll + "','" + dep + "','" + sem + "'," + mobile + ",'" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Đã Lưu Dữ Liệu!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin","Suggest",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addstudent_Load(object sender, EventArgs e)
        {

        }
    }
}
