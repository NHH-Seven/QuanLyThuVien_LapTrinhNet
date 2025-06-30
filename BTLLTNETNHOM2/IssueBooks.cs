using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.Collections.Specialized;

namespace BTLLTNETNHOM2
{
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source =  HUYHIEU; database = library;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand("select bName from NewBook",con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                for(int i = 0;i< sdr.FieldCount; i++)
                {
                    comboBoxBooks.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();

        }

        int count;

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtMasv.Text != "")
            {
                string eid = txtMasv.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =  HUYHIEU; database = library;integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                
                cmd.CommandText = "select * from NewStudent where enroll = '" + eid + "'";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                //-----------------------------------------
                //--------------
                cmd.CommandText = "select count(std_enroll) from IRBookk where std_enroll = '" + eid + "' and book_return_date IS NULL";
                SqlDataAdapter Dal = new SqlDataAdapter(cmd);
                DataSet Dsl = new DataSet();
                Dal.Fill(Dsl);
                count = int.Parse(Dsl.Tables[0].Rows[0][0].ToString());
                //------------------------
                if (DS.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = DS.Tables[0].Rows[0][1].ToString();
                    txtlop.Text = DS.Tables[0].Rows[0][3].ToString();
                    txtHocKy.Text =DS.Tables[0].Rows[0][4].ToString();
                    txtSdt.Text = DS.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = DS.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    txtName.Clear();
                    txtlop.Clear();
                    txtHocKy.Clear();
                    txtSdt.Clear();
                    txtEmail.Clear();
                    MessageBox.Show("Mã sinh viên không đúng","error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "")
            {
                if(comboBoxBooks.SelectedIndex != -1 && count <= 2)
                {
                    string enroll = txtMasv.Text;
                    string sname = txtName.Text;
                    string sdep = txtlop.Text;
                    string sem = txtHocKy.Text;
                    Int64 contact = Int64.Parse(txtSdt.Text);
                    string email = txtEmail.Text;
                    string bookname = comboBoxBooks.Text;
                    string bookIssueDate = dateTimePicker.Text;

                    string eid = txtMasv.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source =  HUYHIEU; database = library;integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = cmd.CommandText = "insert into IRBookk (std_enroll,std_name,std_dep,std_sem,std_contact,std_email,book_name,book_issue_date) values ('" + enroll +"','"+ sname+"','"+sdep+"','"+sem+"',"+contact+",'"+email+"','"+bookname+"','"+bookIssueDate+"')";
                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Đã thêm", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("chọn sách , hoặc đã mượn tối đã số lượng sách ", "Không thể mượn sách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tên sinh viên không đúng", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenSv_TextChanged(object sender, EventArgs e)
        {
            if(txtMasv.Text == "")
            {
                txtName.Clear();
                txtlop.Clear();
                txtHocKy.Clear();
                txtSdt.Clear();
                txtEmail.Clear();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMasv.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure?", "condirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
