using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PKBNV
{
    public partial class bieumau2 : Form
    {
        public bieumau2()
        {
            InitializeComponent();
        }

        private void bieumau2_Load(object sender, EventArgs e)
        {
            effect();
            formatDate();
            getDTBM2();
            dtgBM2.DefaultCellStyle.ForeColor = Color.Blue;
        }
        //effect diferent
        public void effect()
        {
            this.ActiveControl = txtNam;
            btnSua.Enabled = false;
        }
        //format date
        public void formatDate()
        {
            dtpNgayKham.Format = DateTimePickerFormat.Custom;
            dtpNgayKham.CustomFormat = "dd-MM-yyyy";
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "dd-MM-yyyy";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "dd-MM-yyyy";
        }
        //color mouse move datagridview
        private void dtgbm2_CellMouseLeave_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgBM2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dtgBM2.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }

        private void dtgbm2_CellMouseMove_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgBM2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                dtgBM2.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
        //dem stt datagrid view
        private void dtgbm2_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        //get ds bieu mau 1
        public void getDTBM2()
        {
            DataTable _dskq = BUS.bieumau2BUS.getDSBM2();
            dtgBM2.DataSource = _dskq;
        }
        //them bieu mau
        public void themBM()
        {
            CLASS.bieumau2 bm2 = new CLASS.bieumau2();
            bm2.ngaythang = dtpNgayKham.Text;
            if (txtNam.Text == string.Empty){ txtNam.Text = "0"; bm2.sumNam = 0; } else { bm2.sumNam = int.Parse(txtNam.Text); };
            if (txtNu.Text == string.Empty) { txtNu.Text = "0"; bm2.sumNu = 0; } else { bm2.sumNu = int.Parse(txtNu.Text); };        
            if (txtSK1.Text == string.Empty || txtSK1.Text == "I") { txtSK1.Text = "0"; };
            if (txtSK2.Text == string.Empty || txtSK2.Text == "II") { txtSK2.Text = "0"; };
            if (txtSK3.Text == string.Empty || txtSK3.Text == "III") { txtSK3.Text = "0"; };
            if (txtSK4.Text == string.Empty || txtSK4.Text == "IV") { txtSK4.Text = "0"; };
            if (txtSK5.Text == string.Empty || txtSK5.Text == "V") { txtSK5.Text = "0"; };
            bm2.sumSK1 = int.Parse(txtSK1.Text);
            bm2.sumSK2 = int.Parse(txtSK2.Text);
            bm2.sumSK3 = int.Parse(txtSK3.Text);
            bm2.sumSK4 = int.Parse(txtSK4.Text);
            bm2.sumSK5 = int.Parse(txtSK5.Text);
            bm2.sumTong = bm2.sumNu + bm2.sumNam;
            int sumSK = bm2.sumSK1 + bm2.sumSK2 + bm2.sumSK3 + bm2.sumSK4 + bm2.sumSK5;
            txtTong.Text = bm2.sumTong.ToString();
            if (sumSK <= bm2.sumTong)
            {
                bool kq = BUS.bieumau2BUS.ThemBM(bm2);
                if (kq == true)
                {
                    getDTBM2();
                    MessageBoxEx.Show("Thêm Đối Tượng Thành Công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
            else
            {
                MessageBoxEx.Show("Số ĐK khám nhỏ hơn với Tổng số loại SK!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dtpNgayKham.Value.Date > DateTime.Now.Date)
            {
                MessageBoxEx.Show("Ngày khám không hợp lệ !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    themBM();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }   
            }
        }
        //xoa doi tương chỉ định
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idx = dtgBM2.CurrentRow.Index;
            if (dtgBM2.Rows[idx].Cells[0].Value.ToString() != "")
            {
                int idBM = int.Parse(dtgBM2.Rows[idx].Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show("Xác nhận xóa KQ?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {

                    bool kq = BUS.bieumau2BUS.XoaBM(idBM);
                    if (kq == true)
                    {
                        try
                        {
                            MessageBoxEx.Show("Đã xóa kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getDTBM2();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); };
                    }
                    else { MessageBoxEx.Show("Không thể xoá kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                }
            }
            else { MessageBoxEx.Show("Không tìm thấy KQ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        //lam moi ds
        private void btnMoi_Click(object sender, EventArgs e)
        {
            getDTBM2();
            MessageBoxEx.Show("Đã làm mới ds!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dtpNgayKham.Value = DateTime.Now;
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
            txtNam.Text = "";
            txtNu.Text = "";
            txtSK1.Text = "I";
            txtSK2.Text = "II";
            txtSK3.Text = "III";
            txtSK4.Text = "IV";
            txtSK5.Text = "V";
        }
        // get doi tuong from data grid view
        private void dtgBM2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgBM2.SelectedCells.Count > 0) // make sure user select at least 1 row 
            {
                string ngaythang = dtgBM2.CurrentRow.Cells[1].Value.ToString();
                string sumNam = dtgBM2.CurrentRow.Cells[2].Value.ToString();
                string sumNu = dtgBM2.CurrentRow.Cells[3].Value.ToString();
                string sumTong = dtgBM2.CurrentRow.Cells[4].Value.ToString();
                string sumSK1 = dtgBM2.CurrentRow.Cells[5].Value.ToString();
                string sumSK2 = dtgBM2.CurrentRow.Cells[6].Value.ToString();
                string sumSK3 = dtgBM2.CurrentRow.Cells[7].Value.ToString();
                string sumSK4 = dtgBM2.CurrentRow.Cells[8].Value.ToString();
                string sumSK5 = dtgBM2.CurrentRow.Cells[9].Value.ToString();
                dtpNgayKham.Value = DateTime.ParseExact(ngaythang, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                txtNam.Text = sumNam;
                txtNu.Text = sumNu;
                txtTong.Text = sumTong;
                txtSK1.Text = sumSK1;
                txtSK2.Text = sumSK2;
                txtSK3.Text = sumSK3;
                txtSK4.Text = sumSK4;
                txtSK5.Text = sumSK5;
            }
            btnSua.Enabled = true;
        }
        //ham sua doi tuong trong ds
        public void suaDTbm2()
        {
            CLASS.bieumau2 bm2 = new CLASS.bieumau2();
            int idx = dtgBM2.CurrentRow.Index;
            bm2.idBM2 = int.Parse(dtgBM2.Rows[idx].Cells[0].Value.ToString());
            bm2.ngaythang = dtpNgayKham.Text;
            if (txtNam.Text == string.Empty) { txtNam.Text = "0"; bm2.sumNam = 0; } else { bm2.sumNam = int.Parse(txtNam.Text); };
            if (txtNu.Text == string.Empty) { txtNu.Text = "0"; bm2.sumNu = 0; } else { bm2.sumNu = int.Parse(txtNu.Text); };
            if (txtSK1.Text == string.Empty || txtSK1.Text == "I") { txtSK1.Text = "0"; };
            if (txtSK2.Text == string.Empty || txtSK2.Text == "II") { txtSK2.Text = "0"; };
            if (txtSK3.Text == string.Empty || txtSK3.Text == "III") { txtSK3.Text = "0"; };
            if (txtSK4.Text == string.Empty || txtSK4.Text == "IV") { txtSK4.Text = "0"; };
            if (txtSK5.Text == string.Empty || txtSK5.Text == "V") { txtSK5.Text = "0"; };
            bm2.sumSK1 = int.Parse(txtSK1.Text);
            bm2.sumSK2 = int.Parse(txtSK2.Text);
            bm2.sumSK3 = int.Parse(txtSK3.Text);
            bm2.sumSK4 = int.Parse(txtSK4.Text);
            bm2.sumSK5 = int.Parse(txtSK5.Text);
            bm2.sumTong = bm2.sumNu + bm2.sumNam;
            int sumSK = bm2.sumSK1 + bm2.sumSK2 + bm2.sumSK3 + bm2.sumSK4 + bm2.sumSK5;
            txtTong.Text = bm2.sumTong.ToString();
            if (sumSK <= bm2.sumTong)
            {
                bool kq = BUS.bieumau2BUS.SuaBM(bm2);
                if (kq == true)
                {
                    getDTBM2();
                    btnSua.Enabled = false;
                    MessageBoxEx.Show("Sửa Đối Tượng Thành Công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
            }
            else
            {
                MessageBoxEx.Show("Số ĐK khám nhỏ hơn với Tổng số loại SK!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtpNgayKham.Value.Date > DateTime.Now.Date)
            {
                MessageBoxEx.Show("Ngày khám không hợp lệ !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    suaDTbm2();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        //xuat excel
        private void copyAlltoClipboard()
        {
            dtgBM2.SelectAll();
            DataObject dataObj = dtgBM2.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void button3_Click(object sender, EventArgs e)
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("idBM2", typeof(Int16));
            dt.Columns.Add("ngaythang", typeof(string));
            dt.Columns.Add("sumNam", typeof(Int16));
            dt.Columns.Add("sumNu", typeof(Int16));
            dt.Columns.Add("sumTong", typeof(Int16));
            dt.Columns.Add("sumSK1", typeof(Int16));
            dt.Columns.Add("sumSK2", typeof(Int16));
            dt.Columns.Add("sumSK3", typeof(Int16));
            dt.Columns.Add("sumSK4", typeof(Int16));
            dt.Columns.Add("sumSK5", typeof(Int16));

            //add datagridview data to table
            foreach (DataGridViewRow dgv in dtgBM2.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("bieumau2.xml");
            string path = Directory.GetCurrentDirectory().ToString() + @"\report\bieumau2.rpt";
            //transefer data to crystalreportviewer
            ReportDocument report = new ReportDocument();
            report.Load(path);
            report.SetDataSource(ds);
            PRINTVIEW.phieuCLS form = new PRINTVIEW.phieuCLS();
            form.Text = "QUẢN LÝ SỨC KHOẺ NGƯỜI LAO ĐỘNG THÔNG QUA KHÁM ĐỊNH KỲ";
            form.crystalReportViewer1.ReportSource = report;
            form.ShowDialog();
        }


        //loc theo ngay
        public void searchByDate()
        {
            string from = dtpFrom.Text;
            string to = dtpTo.Text;
            DataTable _dskqTK = BUS.timkiemBUS.getDSKQbyDateBM2(from, to);
            dtgBM2.DataSource = _dskqTK;
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                searchByDate();
            }
            catch (Exception ex)
            { MessageBoxEx.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtSK1_Click(object sender, EventArgs e)
        {
            txtSK1.Text = "";
        }

        private void txtSK2_Click(object sender, EventArgs e)
        {
            txtSK2.Text = "";
        }

        private void txtSK3_Click(object sender, EventArgs e)
        {
            txtSK3.Text = "";
        }

        private void txtSK4_Click(object sender, EventArgs e)
        {
            txtSK4.Text = "";
        }

        private void txtSK5_Click(object sender, EventArgs e)
        {
            txtSK5.Text = "";
        }
    }
}
