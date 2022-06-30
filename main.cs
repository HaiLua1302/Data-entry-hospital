using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PKBNV
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();

            
        }
        private void main_Load(object sender, EventArgs e)
        {
            IsServerConnected(getDB._connectionString);
        }

        private static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    MessageBoxEx.Show("Kết Nối Server Thất Bại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    return false;
                }
            }
        }
        private void biểuMẫu1ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            pkCLS form_pk = new pkCLS();
            form_pk.Show();    
        }

        private void tHOÁTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBoxEx.Show
                ("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            if (h == DialogResult.OK)
                Application.Exit();
        }

      
        private void biểuMẫu1ToolStripMenuItem8_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void biểuMẫu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bieumau1 bieumau = new bieumau1();
            bieumau.ShowDialog();
        }

        private void biểuMẫu1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bieumau2 bieumau = new bieumau2();
            bieumau.ShowDialog();
        }

        private void biểuMẫu1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            bieumau3 bieumau = new bieumau3();
            bieumau.ShowDialog();
        }

        private void biểuMẫu1ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            bieumau5 bieumau = new bieumau5();
            bieumau.ShowDialog();
        }

        private void biểuMẫu1ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            nguoiLD nguoiLD = new nguoiLD();
            nguoiLD.ShowDialog();
        }

        private void biểuMẫu1ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            bieumau7 bieumau = new bieumau7();
            bieumau.ShowDialog();
        }

        private void biểuMẫu1ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            bieumau8 bieumau = new bieumau8();
            bieumau.ShowDialog();
        }

        private void bệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLbenh bieumau = new QLbenh();
            bieumau.ShowDialog();
        }

        private void kHOAPHÒNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qlKhoaPhong bieumau = new qlKhoaPhong();
            bieumau.ShowDialog();
        }

        private void chứcDanhToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            qlChucDanh bieumau = new qlChucDanh();
            bieumau.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
