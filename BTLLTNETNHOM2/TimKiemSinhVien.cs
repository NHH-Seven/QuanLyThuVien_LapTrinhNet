using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BTLLTNETNHOM2
{
    public partial class TimKiemSinhVien : Form
    {
        public TimKiemSinhVien()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void TimKiemSinhVien_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = HUYHIEU; database = library;integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];




        }
        int bid;
        Int64 rowld;
        private void txtSearchTen_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchTen.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HUYHIEU; database = library;integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where sname LIKE '" + txtSearchTen.Text + "%'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HUYHIEU; database = library;integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

          
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = HUYHIEU; database = library;integrated security = True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent where stuid = "+bid+"";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            rowld = Int64.Parse(DS.Tables[0].Rows[0][0].ToString());

            txtTenSV.Text = DS.Tables[0].Rows[0][1].ToString();
            txtLop.Text = DS.Tables[0].Rows[0][2].ToString();
            txtHocKy.Text = DS.Tables[0].Rows[0][3].ToString();
            txtMasv.Text = DS.Tables[0].Rows[0][4].ToString();
            txtSDT.Text = DS.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = DS.Tables[0].Rows[0][6].ToString();



        }

        private void btnSua_Click(object sender, EventArgs e)
        { 
            string sname = txtTenSV.Text;
            string enroll = txtMasv.Text;
            string dep = txtLop.Text;
            string sem = txtHocKy.Text;
            Int64 contact = Int64.Parse(txtSDT.Text);
            string email = txtEmail.Text;

            if (MessageBox.Show("Dữ liệu sẽ được cập nhập", "success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HUYHIEU; database = library;integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Update NewStudent set sname='" + sname + "',enroll ='" + enroll + "',dep='" + dep + ",sem='" + sem + "',contact='" + contact + "',email='" + email + "' where stuid = " + rowld + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                TimKiemSinhVien_Load(this, null);
            }
        }

        private void btnLMoi_Click(object sender, EventArgs e)
        {
            TimKiemSinhVien_Load(this, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("dữ liệu sẽ được xóa .comfirm?,", "delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HUYHIEU; database = library;integrated security = True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewStudent where stuid =" + rowld + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                TimKiemSinhVien_Load(this, null);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
