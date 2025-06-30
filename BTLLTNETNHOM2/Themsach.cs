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
    public partial class Themsach : Form
    {
        public Themsach()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPrice.Text != "" && txtPubliction.Text != "" && txtQuantity.Text != "")
            {
                string bName = txtBookName.Text;
                string bAuthor = txtAuthor.Text;
                string publicaion = txtPubliction.Text;
                string pdate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = HUYHIEU ; database = library; integrated security = true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into NewBook(bname,bAuthor, bPubl, bPDate,bPrice,bQuan) values ('" + bName + "','" + bAuthor + "','" + publicaion + "','" + pdate + "'," + price + "," + quan + ")";
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Đã Lưu", "succuess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPubliction.Clear();
                txtQuantity.Clear();
                txtPrice.Clear();
            }
            else
            {
                MessageBox.Show("dữ liệu nhập không hợp lệ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

     
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("điều này sẽ XÓA Dữ liệu chưa được lưu của bạn", "Bạn chắc chắn?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Themsach_Load(object sender, EventArgs e)
        {

        }
    }
}
