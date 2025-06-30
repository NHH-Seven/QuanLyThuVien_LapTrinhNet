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

namespace BTLLTNETNHOM2
{
    public partial class Thongke : Form
    {
        public Thongke()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Thongke_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = HUYHIEU; database = library;integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IRBookk where book_return_date IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            cmd.CommandText = "select * from IRBookk where book_return_date IS NOT NULL";
            SqlDataAdapter dal = new SqlDataAdapter(cmd);
            DataSet dsl = new DataSet();
            dal.Fill(dsl);
            dataGridView2.DataSource = dsl.Tables[0];


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
