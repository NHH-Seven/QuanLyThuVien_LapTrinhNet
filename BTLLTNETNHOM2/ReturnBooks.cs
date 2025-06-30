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
    public partial class ReturnBooks : Form
    {
        public ReturnBooks()
        {
            InitializeComponent();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = HUYHIEU; database = library;integrated security  = True";
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandText = "select * from IRBookk where std_enroll = '" + txtMasv.Text + "' and book_return_date IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count !=0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("ID không hợp lệ hoặc Không có sách được phát hành", "error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
        }

        private void ReturnBooks_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            txtMasv.Clear();


        }
        string bname;
        string bdate;
        Int64 rowid;



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {


                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            txtTenSach.Text = bname;
            txtNgayMuon.Text = bdate;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = HUYHIEU; database = library ;integrated security  = True";
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "Update IRBookk set book_return_date = '" + dateTimePicker1.Text + "'where std_enroll = '" + txtMasv.Text + "' and id = "+rowid+"" ;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Trả về thành công ", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnBooks_Load(this, null);


           

        }

        private void txtTenSv_TextChanged(object sender, EventArgs e)
        {
            if(txtMasv.Text == "")
            {
                panel3.Visible = false;
                dataGridView1.DataSource = null;
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            txtMasv.Clear();
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            panel3.Visible=false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
