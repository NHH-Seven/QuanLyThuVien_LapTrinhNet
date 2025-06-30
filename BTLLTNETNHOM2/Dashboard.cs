using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLLTNETNHOM2
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("are you sure you want to exit?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
          
        }

        private void phieuMuonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBooks ib = new IssueBooks();
            ib.Show();
        }

        private void traSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBooks rb = new ReturnBooks();
            rb.Show();
        }

        private void thongKeSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thongke tk = new Thongke();
            tk.Show();
        }

        private void themSachMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Themsach ts = new Themsach();
            ts.Show();
        }

        private void timKiemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimkiemSach tk = new TimkiemSach();
            tk.Show();
        }

        private void themKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addstudent add = new addstudent();
            add.Show();
        }

        private void timKiemToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TimKiemSinhVien tksv = new TimKiemSinhVien();
            tksv.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void nguoiDungToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
