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
    public partial class bieumau1 : Form
    {
        public bieumau1()
        {
            InitializeComponent();
        }

        private void bieumau1_Load(object sender, EventArgs e)
        {
            formatDate();
            dataPLSK();
            getDTBM1();
            dtgBM1.DefaultCellStyle.ForeColor = Color.Blue;
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
        //add data cbPLSK
        public void dataPLSK()
        {
            /*cbPLSK.Items.Add("I");
            cbPLSK.Items.Add("II");
            cbPLSK.Items.Add("III");
            cbPLSK.Items.Add("IV");
            cbPLSK.Items.Add("V");
            cbPLSK.SelectedIndex = 0;*/
        }
        //color mouse move datagridview
        private void dtgBM1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgBM1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                dtgBM1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
        private void dtgBM1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgBM1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dtgBM1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }
        //dem stt datagrid view
        private void dtgBM1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        //get ds bieu mau 1
        public void getDTBM1()
        {
            DataTable _dskq = BUS.bieumau1BUS.getDSBM1();
            dtgBM1.DataSource = _dskq;
        }

        //them bieu mau
        public void themBM()
        {
            CLASS.bieumau1 bm1 = new CLASS.bieumau1();
            bm1.ngaythang = dtpNgayKham.Text;
            bm1.sumNam = int.Parse(txtNam.Text);
            bm1.sumNu = int.Parse(txtNu.Text);
            bm1.sumTong = bm1.sumNu + bm1.sumNam;

            //bm1.PLSK = cbPLSK.Text;
            bool kq = BUS.bieumau1BUS.ThemBM(bm1);
            if (kq == true)
            {
                getDTBM1();
            }
            else
            {
                MessageBoxEx.Show("Thêm dữ liệu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //goi ham them
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dtpNgayKham.Value.Date > DateTime.Now.Date)
            {
                MessageBoxEx.Show("Ngày khám không hợp lệ !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtNam.Text == string.Empty)
                {
                    txtNam.Text = "0";
                    if (txtNu.Text == string.Empty)
                    {
                        txtNu.Text = "0";
                        int tong = int.Parse(txtNam.Text) + int.Parse(txtNu.Text);
                        txtTong.Text = tong.ToString();
                        try
                        {
                            themBM();
                            MessageBoxEx.Show("Thêm Đối Tượng Thành Công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                    else MessageBoxEx.Show("Số lượng Nữ không lệ !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBoxEx.Show("Số lượng Nam không lệ !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //xoa bieu mau  
        private void btnXoa_Click(object sender, EventArgs e)
        {
            CLASS.bieumau1 bm = new CLASS.bieumau1();
            int idx = dtgBM1.CurrentRow.Index;
            if (dtgBM1.Rows[idx].Cells[0].Value.ToString() != "")
            {
                int idBM = int.Parse(dtgBM1.Rows[idx].Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show("Xác nhận xóa KQ?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                   
                        bool kq = BUS.bieumau1BUS.XoaBM(idBM);
                        if (kq == true)
                        {
                        try
                        {
                            MessageBoxEx.Show("Đã xóa kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getDTBM1();
                        } catch (Exception ex) { MessageBox.Show(ex.Message); };
                    }
                        else { MessageBoxEx.Show("Không thể xoá kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                   
                }
            }
            else { MessageBoxEx.Show("Không tìm thấy KQ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        //lam moi ds
        private void btnMoi_Click(object sender, EventArgs e)
        {
            getDTBM1();
            MessageBoxEx.Show("Đã làm mới ds!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //get value dtg -> textbox
        private void dtgBM1_DoubleClick(object sender, EventArgs e)
        {
            if (dtgBM1.SelectedCells.Count > 0) // make sure user select at least 1 row 
            {
                string ngaythang = dtgBM1.CurrentRow.Cells[1].Value.ToString();
                string sumNam = dtgBM1.CurrentRow.Cells[2].Value.ToString();
                string sumNu = dtgBM1.CurrentRow.Cells[3].Value.ToString();
                string sumTong = dtgBM1.CurrentRow.Cells[4].Value.ToString();
                string PLSK = dtgBM1.CurrentRow.Cells[5].Value.ToString();
                dtpNgayKham.Value = DateTime.ParseExact(ngaythang, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                txtNam.Text = sumNam;
                txtNu.Text = sumNu;
                txtTong.Text = sumTong;
                //cbPLSK.Text = PLSK;
            }
            btnSua.Enabled = true;
        }

        //ham sua doi tuong trong ds
        public void suaDTBM1()
        {
            CLASS.bieumau1 bm1 = new CLASS.bieumau1();
            int idx = dtgBM1.CurrentRow.Index;
            bm1.idBM1 = int.Parse(dtgBM1.Rows[idx].Cells[0].Value.ToString());
            bm1.ngaythang = dtgBM1.Text;
            bm1.sumNam = int.Parse(txtNam.Text);
            bm1.sumNu = int.Parse(txtNu.Text);
            bm1.sumTong = bm1.sumNu + bm1.sumNam;
            //bm1.PLSK = cbPLSK.Text;
            bool kq = BUS.bieumau1BUS.SuaBM(bm1);
            if (kq == true)
            {
                getDTBM1();
            }
            else
            {
                MessageBoxEx.Show("Sửa đối tượng thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txtNam.Text != string.Empty)
                {
                    if (txtNu.Text != string.Empty)
                    {
                        try
                        {
                            suaDTBM1();
                            btnSua.Enabled = false;
                            MessageBoxEx.Show("Sửa Đối Tượng Thành Công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                    else MessageBoxEx.Show("Số lượng Nữ không lệ !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBoxEx.Show("Số lượng Nam không lệ !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //in bao cao
        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("idBM1", typeof(Int16));
            dt.Columns.Add("ngaythang", typeof(string));
            dt.Columns.Add("sumNam", typeof(Int16));
            dt.Columns.Add("sumNu", typeof(Int16));
            dt.Columns.Add("sumTong", typeof(Int16));
            dt.Columns.Add("PLSK", typeof(string));

            //add datagridview data to table
            foreach (DataGridViewRow dgv in dtgBM1.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("bieumau1.xml");
            string path = Directory.GetCurrentDirectory().ToString() + @"\report\bieumau1.rpt";
            //transefer data to crystalreportviewer
            ReportDocument report = new ReportDocument();
            report.Load(path); 
            report.SetDataSource(ds);
            PRINTVIEW.phieuCLS form = new PRINTVIEW.phieuCLS();
            form.Text = "QUẢN LÝ SỨC KHOẺ TRƯỚC KHI BỐ TRÍ VIỆC LÀM";
            form.crystalReportViewer1.ReportSource = report;
            form.ShowDialog();
        }

        private void txtNu_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                int sumTong = int.Parse(txtNam.Text) + int.Parse(txtNu.Text);
                txtTong.Text = sumTong.ToString();
                //cbPLSK.Focus();
            }
        }

        private void txtNam_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtNu.Focus();
            }
        }

        private void cbPLSK_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                btnThem.Focus();
            }
        }

        //xuat excel
        private void copyAlltoClipboard()
        {
            dtgBM1.SelectAll();
            DataObject dataObj = dtgBM1.GetClipboardContent();
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

        //loc theo ngay
        public void searchByDate()
        {
            string from = dtpFrom.Text;
            string to = dtpTo.Text;
            DataTable _dskqTK = BUS.timkiemBUS.getDSKQbyDateBM1(from, to);
            dtgBM1.DataSource = _dskqTK;
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
    }
}
