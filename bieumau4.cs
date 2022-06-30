using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PKBNV
{
    public partial class bieumau4 : Form
    {
        public bieumau4()
        {
            InitializeComponent();
        }

        private void bieumau4_Load(object sender, EventArgs e)
        {
            getData_sql();
            insert_data_cb();
            dtgDM.DefaultCellStyle.ForeColor = Color.Blue;
            btnSua.Enabled = false;
        }
        //ínsert data combobox
        public void insert_data_cb()
        {
            cbLyDo.Items.Add("Ốm");
            cbLyDo.Items.Add("Tai Nạn Lao Động");
            cbLyDo.Items.Add("Bệnh Nghề Nghiệp");
            cbLyDo.SelectedIndex = 0;

            for(int i = 1;i < 13;i++)
            {
                cbThang.Items.Add("Tháng " + i);
            }
            cbThang.SelectedIndex = 0;
        }
        //get data sql
        public void getData_sql()
        {
            DataTable _dskq = BUS.bieumau4BUS.getDSKQ_SQL(int.Parse(txtIdDATA.Text));
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

        private void txtSoLD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                (e.KeyChar == '.' && (txtSoLD.Text.Length == 0 || txtSoLD.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void textNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                (e.KeyChar == '.' && (txtIdDATA.Text.Length == 0 || txtIdDATA.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }
        //get so luong tong nguoi LD
        public int tongSoNLD()
        {
            int tongLD = BUS.nguoiLDBUS.getSLLD(int.Parse(txtIdDATA.Text));
            return tongLD;
        }
        //get so luong tong nguoi LD sx
        public int tongSoNLD_SX()
        {
            int tongLD_SX = BUS.nguoiLDBUS.getSLLD_SX(int.Parse(txtIdDATA.Text));
            return tongLD_SX;
        }
        //get so luong tong nguoi LD tx
        public int tongSoNLD_TX()
        {
            int tongLD_TX = BUS.nguoiLDBUS.getSLLD_TX(int.Parse(txtIdDATA.Text));
            return tongLD_TX;
        }
        //tao ham xu ly 
        public void insert_data()
        {
            CLASS.bieumau4 bm = new CLASS.bieumau4();
            bm.nhomBenh = cbLyDo.Text;
            bm.thang = cbThang.Text;
            bm.sl = int.Parse(txtSoLD.Text);
            bm.idLD = int.Parse(txtIdDATA.Text);
            bm.slNgay = float.Parse(txtNgayNghi.Text);

            float tbNgay = bm.slNgay / bm.sl;
            bm.tbSoNgay = float.Parse(string.Format("{0:0.000}", tbNgay));

            int idx = cbLyDo.SelectedIndex;
            float phanTram = 0; 
            switch (idx)
            {
                case 0:
                    phanTram = (bm.sl / float.Parse(tongSoNLD().ToString())) * 100;
                    bm.phanTram = float.Parse(string.Format("{0:0.000}", phanTram));
                    break;
                case 1:
                    phanTram = (bm.sl / float.Parse(tongSoNLD_SX().ToString())) * 100;
                    bm.phanTram = float.Parse(string.Format("{0:0.000}", phanTram));
                    break;
                case 2:
                    phanTram = (bm.sl / float.Parse(tongSoNLD_TX().ToString())) * 100;
                    bm.phanTram = float.Parse(string.Format("{0:0.000}", phanTram));
                    break;
            }
            bool kq = BUS.bieumau4BUS.insertDATA(bm);
            if(kq == true)
            {
                getData_sql();
            }
        }
        //update
        public void update_data()
        {
            CLASS.bieumau4 bm = new CLASS.bieumau4();
            bm.sl = int.Parse(txtSoLD.Text);
            bm.slNgay = float.Parse(txtNgayNghi.Text);
            bm.idBM = int.Parse(dtgDM.CurrentRow.Cells[0].Value.ToString());
            float tbNgay = bm.slNgay / bm.sl;
            bm.tbSoNgay = float.Parse(string.Format("{0:0.000}", tbNgay));

            int idx = cbLyDo.SelectedIndex;
            float phanTram = 0;
            switch (idx)
            {
                case 0:
                    phanTram = (bm.sl / float.Parse(tongSoNLD().ToString())) * 100;
                    bm.phanTram = float.Parse(string.Format("{0:0.000}", phanTram));
                    break;
                case 1:
                    phanTram = (bm.sl / float.Parse(tongSoNLD_SX().ToString())) * 100;
                    bm.phanTram = float.Parse(string.Format("{0:0.000}", phanTram));
                    break;
                case 2:
                    phanTram = (bm.sl / float.Parse(tongSoNLD_TX().ToString())) * 100;
                    bm.phanTram = float.Parse(string.Format("{0:0.000}", phanTram));
                    break;
            }
            bool kq = BUS.bieumau4BUS.updateDATA(bm);
            if (kq == true)
            {
                getData_sql();
            }
        }

        //xuat excel
        private void copyAlltoClipboard()
        {
            dtgDM.SelectAll();
            DataObject dataObj = dtgDM.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        //xu ly sự kiện
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtNgayNghi.Text != string.Empty)
            {
                if (txtSoLD.Text != string.Empty)
                {
                    CLASS.bieumau4 bm = new CLASS.bieumau4();
                    bm.thang = cbThang.Text;
                    bm.nhomBenh = cbLyDo.Text;
                    bm.nam = int.Parse(dtgDM.CurrentRow.Cells[7].Value.ToString());
                    int check_thang = BUS.timkiemBUS.checkDuplicate_thang_BM4(bm);
                    if (check_thang > 0)
                    {
                         MessageBox.Show("Dữ liệu " + cbThang.Text + " Đã Có !!!\nVui lòng chọn đối tượng cần cập nhật.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            insert_data();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error); };
                    }
                }
                else { MessageBox.Show("Số lượng người LĐ Không hợp lệ !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Số lượng ngày nghỉ không hợp lệ !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }


        }
        //get double click
        private void dtgDM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nhombenh = dtgDM.CurrentRow.Cells[1].Value.ToString();
            string thang = dtgDM.CurrentRow.Cells[6].Value.ToString();
            string slNguoi = dtgDM.CurrentRow.Cells[2].Value.ToString();
            string slNgay = dtgDM.CurrentRow.Cells[4].Value.ToString();

            cbLyDo.Text = nhombenh;
            cbThang.Text = thang;
            txtSoLD.Text = slNguoi;
            txtNgayNghi.Text = slNgay;

            cbLyDo.Enabled = false;
            cbThang.Enabled = false;

            btnSua.Enabled = true;
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            getData_sql();
            txtSoLD.Text = "";
            txtNgayNghi.Text = "";
            cbLyDo.SelectedIndex = 0;
            cbThang.SelectedIndex = 0;
            /*string test = "";
            for (int i = 0; i <= dtgDM.RowCount - 1; i++)
            {
                if (dtgDM.Rows[i].Cells[1].Value.ToString() == "Ốm")
                {
                    if (dtgDM.Rows[i].Cells[6].Value.ToString() == "Tháng 1")
                    {
                        test = dtgDM.Rows[i].Cells[2].Value.ToString();
                    }
                }
            }
            MessageBox.Show(test);*/
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtNgayNghi.Text != string.Empty)
            {
                if (txtSoLD.Text != string.Empty)
                {
                        try
                        {
                        update_data();
                        MessageBox.Show("Update thành công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSua.Enabled = false;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error); };
                        
                }
                else { MessageBox.Show("Số lượng người LĐ Không hợp lệ !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Số lượng ngày nghỉ không hợp lệ !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idx = dtgDM.CurrentRow.Index;
            if (dtgDM.Rows[idx].Cells[0].Value.ToString() != "")
            {
                int idBM = int.Parse(dtgDM.Rows[idx].Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show("Xác nhận xóa KQ?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {

                    bool kq = BUS.bieumau4BUS.deleteDATA(idBM);
                    if (kq == true)
                    {
                        try
                        {
                            MessageBoxEx.Show("Đã xóa kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getData_sql();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); };
                    }
                    else { MessageBoxEx.Show("Không thể xoá kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                }
            }
            else { MessageBoxEx.Show("Không tìm thấy KQ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("IDBM", typeof(Int16));
            dt.Columns.Add("nhomBenh", typeof(string));
            dt.Columns.Add("slLaoDong", typeof(Int16));
            dt.Columns.Add("phanTram", typeof(string));
            dt.Columns.Add("slNgayNghi", typeof(Int16));
            dt.Columns.Add("TBNgay", typeof(string));
            dt.Columns.Add("thang", typeof(string));
            dt.Columns.Add("nam", typeof(Int16));
            dt.Columns.Add("idLD", typeof(Int16));
   


            //add datagridview data to table
            foreach (DataGridViewRow dgv in dtgDM.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, 
                    dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("bieumau4.xml");

            //transefer data to crystalreportviewer
            string path = Directory.GetCurrentDirectory().ToString() + @"\report\bieumau4.rpt";
            ReportDocument report = new ReportDocument();
            report.Load(path);
            report.SetDataSource(ds);
            PRINTVIEW.phieuCLS form = new PRINTVIEW.phieuCLS();
            form.Text = "TÌNH HÌNH NGHỈ VIỆC DO ỐM , TAI NẠN LAO ĐỘNG VÀ NGHỀ NGHIỆP";
            form.crystalReportViewer1.ReportSource = report;
            form.ShowDialog();
            
        }
    }
}
