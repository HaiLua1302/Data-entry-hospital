using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKBNV
{
    public partial class QLbenh : Form
    {
        public QLbenh()
        {
            InitializeComponent();
        }

        private void QUẢN_LÝ_NHÂN_VIÊN_Load(object sender, EventArgs e)
        {
            getDT_SQL();
            dtgDM.DefaultCellStyle.ForeColor = Color.Blue;
            btnSua.Enabled = false;
        }
        //get data sql
        public void getDT_SQL()
        {
            DataTable _dskq = BUS.nhombenhBUS.getDSKQ_SQL();
            dtgDM.DataSource = _dskq;
        }
        //efect
        private void dtgDM_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgDM.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dtgDM.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }
        private void dtgDM_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (e.RowIndex > -1)
            {
                dtgDM.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                dtgDM.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
        private void dtgDM_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        //insert data
        public void insert_data()
        {
            CLASS.nhombenh nb = new CLASS.nhombenh();
            nb.maBenh =  txtMaBenh.Text;
            nb.tenBenh = txtTenBenh.Text;

            bool kq = BUS.nhombenhBUS.insertDATA(nb);
            if(kq == true)
            {
                getDT_SQL();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaBenh.Text != string.Empty)
            {
                if (txtTenBenh.Text != string.Empty)
                {
                    int check = BUS.timkiemBUS.checkDuplicate_nb(txtMaBenh.Text);
                    if (check == 0)
                    {
                        insert_data();
                    }
                    MessageBoxEx.Show("Mã bệnh đã có !!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MessageBoxEx.Show("Tên bệnh không hợp lệ !!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBoxEx.Show("Mã bệnh không hợp lệ !!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtMaBenh_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox currentContainer = ((TextBox)sender);
            int caretPosition = currentContainer.SelectionStart;

            currentContainer.Text = currentContainer.Text.ToUpper();
            currentContainer.SelectionStart = caretPosition++;
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            getDT_SQL();
            btnSua.Enabled = false;
            txtMaBenh.Text = "";
            txtTenBenh.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idx = dtgDM.CurrentRow.Index;
            if (dtgDM.Rows[idx].Cells[0].Value.ToString() != "")
            {
                string maBenh = dtgDM.Rows[idx].Cells[0].Value.ToString();

                DialogResult result = MessageBox.Show("Xác nhận xóa KQ?!!! \nXoá dữ liệu này có thể làm ảnh hưởng đến các biểu mẫu", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {

                    bool kq = BUS.nhombenhBUS.deleteDATA(maBenh);
                    if (kq == true)
                    {
                        try
                        {
                            MessageBoxEx.Show("Đã xóa kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getDT_SQL();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); };
                    }
                    else { MessageBoxEx.Show("Không thể xoá kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                }
            }
            else { MessageBoxEx.Show("Không tìm thấy KQ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        //pass data to textbox from dtg
        private void dtgDM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = dtgDM.CurrentRow.Index;
            string maBenh = dtgDM.Rows[idx].Cells[0].Value.ToString();
            string tenBenh = dtgDM.Rows[idx].Cells[1].Value.ToString();

            txtMaBenh.Text = maBenh;
            txtTenBenh.Text = tenBenh;

            btnSua.Enabled = true;
        }
        //update data
        public void update_data()
        {
            CLASS.nhombenh nb = new CLASS.nhombenh();
            nb.maBenh = txtMaBenh.Text;
            nb.tenBenh = txtTenBenh.Text;

            bool kq = BUS.nhombenhBUS.updateDATA(nb);
            if (kq == true)
            {
                getDT_SQL();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaBenh.Text != string.Empty)
            {
                if (txtTenBenh.Text != string.Empty)
                {
                    int check = BUS.timkiemBUS.checkDuplicate_nb(txtMaBenh.Text);
                    if (check == 0)
                    {
                        update_data();
                    }
                    MessageBoxEx.Show("Mã bệnh đã có !!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MessageBoxEx.Show("Tên bệnh không hợp lệ !!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBoxEx.Show("Mã bệnh không hợp lệ !!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //xuat excel
        private void copyAlltoClipboard()
        {
            dtgDM.SelectAll();
            DataObject dataObj = dtgDM.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
    }
}
