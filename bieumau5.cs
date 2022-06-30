using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PKBNV
{
    public partial class bieumau5 : Form
    {

        public bieumau5()
        {
            InitializeComponent();
        }

        private void bieumau5_Load(object sender, EventArgs e)
        {
            getDATA_SQL();
            insert_DT_cb();
            getNhombenh();
            formatNam();
            autoCompleteData_khuvuc();
            txtmaBenh.Text = "";
            btnSua.Enabled = false;
        }
        //format nam
        public void formatNam()
        {
            dtpTimeRec.Format = DateTimePickerFormat.Custom;
            dtpTimeRec.CustomFormat = "dd-MM-yyyy";
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "dd-MM-yyyy";
        }
        //auto completedata khu vuc
        private void autoCompleteData_khuvuc()
        {
            SqlConnection con = new SqlConnection(getDB._connectionString);
            SqlCommand com = new SqlCommand("Select khuvuc from benhnhan", con);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            //AutoCompleteStringCollection Contains a collection of strings to use for the auto-complete feature on certain Windows Forms controls.
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            while (rdr.Read())
            {
                if (rdr["khuvuc"].GetType() != typeof(DBNull))
                {
                    autoCompleteCollection.Add(rdr.GetString(0));
                }
                
            }
            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtKhuVuc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtKhuVuc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtKhuVuc.AutoCompleteCustomSource = autoCompleteCollection;
            con.Close();
        }
        //auto completedata phương pháp
        private void autoCompleteData_Phuongphap()
        {
            SqlConnection con = new SqlConnection(getDB._connectionString);
            SqlCommand com = new SqlCommand("Select phuongPhap from benhnhan", con);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            //AutoCompleteStringCollection Contains a collection of strings to use for the auto-complete feature on certain Windows Forms controls.
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            while (rdr.Read())
            {
                if (rdr["phuongPhap"].GetType() != typeof(DBNull))
                {
                    autoCompleteCollection.Add(rdr.GetString(0));
                }
            }
            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtPhuongPhap.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtPhuongPhap.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPhuongPhap.AutoCompleteCustomSource = autoCompleteCollection;
            con.Close();
        }
        //auto completedata luu ý
        private void autoCompleteData_luuY()
        {
            SqlConnection con = new SqlConnection(getDB._connectionString);
            SqlCommand com = new SqlCommand("Select luuY from benhnhan", con);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            //AutoCompleteStringCollection Contains a collection of strings to use for the auto-complete feature on certain Windows Forms controls.
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            while (rdr.Read())
            {
                if (rdr["luuY"].GetType() != typeof(DBNull))
                {
                    autoCompleteCollection.Add(rdr.GetString(0));
                }
            }
            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtLuuY.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtLuuY.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtLuuY.AutoCompleteCustomSource = autoCompleteCollection;
            con.Close();
        }
        //get nhom benh
        public void getNhombenh()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(getDB._connectionString))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT maBenh, tenBenh FROM nhombenh", con))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        //Insert the Default Item to DataTable.
                        DataRow row = dt.NewRow();
                        row[0] = 0;
                        row[1] = "---------Điền bệnh-------";
                        dt.Rows.InsertAt(row, 0);

                        //Assign DataTable as DataSource.
                        cbTenBenh.DataSource = dt;
                        cbTenBenh.DisplayMember = "tenBenh";
                        cbTenBenh.ValueMember = "maBenh";

                        //Set AutoCompleteMode.
                        cbTenBenh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cbTenBenh.AutoCompleteSource = AutoCompleteSource.ListItems;
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //insert data to cb
        public void insert_DT_cb()
        {
            cbGT.Items.Add("Nam");
            cbGT.Items.Add("Nữ");
            cbGT.SelectedIndex = 0;

            cbTinhTrang.Items.Add("Bình Thường");
            cbTinhTrang.Items.Add("Yếu");
            cbTinhTrang.Items.Add("Nhập Viện");
            cbTinhTrang.Items.Add("Thương Tật Nhẹ");
            cbTinhTrang.Items.Add("Thương Tật Nhẹ");
            cbTinhTrang.Items.Add("Tử Vong");
            cbTinhTrang.SelectedIndex = 0;

            cbFilter.Items.Add("Theo Tên");
            cbFilter.Items.Add("Theo Năm Sinh");
            cbFilter.Items.Add("Theo Bệnh");
            cbFilter.Items.Add("Theo Tình Trạng");
            cbFilter.Items.Add("Theo Thời Gian");
            cbFilter.SelectedIndex = 0;

            cbKieuIn.Items.Add("Tổng Hợp");
            cbKieuIn.Items.Add("Theo Nhóm Bệnh");
            cbKieuIn.SelectedIndex = 0;
        }
        //get DATA
        public void getDATA_SQL()
        {
            DataTable _dskq = BUS.bieumau5BUS.getDSBN();
            dtgBM.DataSource = _dskq;
        }
        //efect
        private void dtgBM_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgBM.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dtgBM.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }

        private void dtgBM_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgBM.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                dtgBM.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void dtgBM_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        //them data
        public void insertDATA()
        {
            CLASS.benhnhan bn = new CLASS.benhnhan();
            bn.tenBN = txtTenBN.Text;
            bn.gioitinh = cbGT.Text;
            if (txtTuoi.Text == string.Empty) { bn.tuoi = 0; } else { bn.tuoi = int.Parse(txtTuoi.Text); };
            bn.khuvuc = txtKhuVuc.Text;
            bn.maBenh = txtmaBenh.Text;
            if (txtTuoiNghe.Text == string.Empty) { bn.tuoinghe = 0; } else { bn.tuoinghe = int.Parse(txtTuoiNghe.Text); };
            bn.tinhTrang = cbTinhTrang.Text;
            bn.phuongPhap = txtPhuongPhap.Text;
            bn.luuY = txtLuuY.Text;
            bn.timeRec = dtpTimeRec.Text;
            bool kq = BUS.bieumau5BUS.ThemBN(bn);
            if (kq == true)
            {
                getDATA_SQL();
            }
            else { MessageBoxEx.Show("Thêm dữ liệu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenBN.Text != string.Empty)
            {
                if (txtTuoi.Text != string.Empty)
                {
                    if (cbTenBenh.SelectedIndex != 0)
                    {
                        try
                        {
                            insertDATA();
                        }
                        catch (Exception Ex) { MessageBoxEx.Show(Ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); };

                    }
                    else { MessageBoxEx.Show("Loại Bệnh Không Hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else { MessageBoxEx.Show("Tuổi Bệnh Nhân Không Hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBoxEx.Show("Tên Bệnh Nhân Không Hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

       
        //get id from cb
        private void cbTenBenh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmaBenh.Text = cbTenBenh.SelectedValue.ToString();
        }

        //lam moi
        private void btnMoi_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenBN.Text = "";
                txtTuoi.Text = "";
                txtKhuVuc.Text = "";
                cbGT.SelectedIndex = 0;
                cbTenBenh.SelectedIndex = 0;
                cbTinhTrang.SelectedIndex = 0;
                txtPhuongPhap.Text = "";
                txtLuuY.Text = "";
                btnSua.Enabled = false;
                getDATA_SQL();
            }
            catch (Exception ex) { MessageBoxEx.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        //xoa data
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idx = dtgBM.CurrentRow.Index;
            if (dtgBM.Rows[idx].Cells[0].Value.ToString() != "")
            {
                int idBN = int.Parse(dtgBM.Rows[idx].Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show("Xác nhận xóa KQ?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {

                    bool kq = BUS.bieumau5BUS.XoaBN(idBN);
                    if (kq == true)
                    {
                        try
                        {
                            MessageBoxEx.Show("Đã xóa kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getDATA_SQL();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    else { MessageBoxEx.Show("Không thể xoá kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                }
            }
            else { MessageBoxEx.Show("Không tìm thấy KQ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        // loc doi tuong 
        public void filter_DATA()
        {
            int idx = cbFilter.SelectedIndex;
            string sql = "";
            switch (idx)
            {
                case 0:
                    sql = "tenBN LIKE N'%" + txtTenBN.Text + "%' ";
                    break;
                case 1:
                    sql = "tuoi = " + int.Parse(txtTuoi.Text);
                    break;
                case 2:
                    sql = "tenBenh LIKE N'%" + cbTenBenh.Text +"%'";
                    break;
                case 3:
                    sql = "tinhTrang LIKE N'%" + cbTinhTrang.Text + "%'";
                    break;
                case 4:
                    sql = "timeRec BETWEEN N'" + dtpFrom.Text + "' AND N'" + dtpTimeRec.Text + "'";
                    break;
                default:break;
            }
            DataTable _dskq = BUS.timkiemBUS.search_by_filter(sql);
            dtgBM.DataSource = _dskq;
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                filter_DATA();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }



        //xuat excel
        private void copyAlltoClipboard()
        {
            dtgBM.SelectAll();
            DataObject dataObj = dtgBM.GetClipboardContent();
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

        //do du lieu ve field
        private void dtgBM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgBM.SelectedCells.Count > 0)
            {
                string tenBN = dtgBM.CurrentRow.Cells[1].Value.ToString();
                string gioitinh = dtgBM.CurrentRow.Cells[2].Value.ToString();
                string tuoi = dtgBM.CurrentRow.Cells[3].Value.ToString();
                string tuoinghe = dtgBM.CurrentRow.Cells[4].Value.ToString();
                string khuvuc = dtgBM.CurrentRow.Cells[5].Value.ToString();
                string tinhtrang = dtgBM.CurrentRow.Cells[6].Value.ToString();
                string phuongphap = dtgBM.CurrentRow.Cells[7].Value.ToString();
                string luuY = dtgBM.CurrentRow.Cells[8].Value.ToString();
                string timeRec = dtgBM.CurrentRow.Cells[9].Value.ToString();
                string tenBenh = dtgBM.CurrentRow.Cells[10].Value.ToString();


                //MessageBoxEx.Show(tenBN +"--"+ tuoi + "--" +gioitinh + "--" +tuoinghe +
                  //  "--" +tenBenh + "--" +tinhtrang + "--" +phuongphap + "--" +khuvuc + "--" +timeRec, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenBN.Text = tenBN;
                 txtTuoi.Text = tuoi;
                 if(gioitinh == "Nam") { cbGT.SelectedIndex = 0; } else { cbGT.SelectedIndex = 1; };
                 txtTuoiNghe.Text = tuoinghe;
                 cbTenBenh.Text = tenBenh;
                cbTinhTrang.SelectedItem = tinhtrang;
                 txtPhuongPhap.Text = phuongphap;
                txtLuuY.Text = luuY;
                 txtKhuVuc.Text = khuvuc;
                dtpTimeRec.Value = DateTime.ParseExact(timeRec, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            btnSua.Enabled = true;

        }
        // edit data
        public void editData()
        {
            CLASS.benhnhan bn = new CLASS.benhnhan();
            bn.tenBN = txtTenBN.Text;
            bn.gioitinh = cbGT.Text;
            if (txtTuoi.Text == string.Empty) { bn.tuoi = 0; } else { bn.tuoi = int.Parse(txtTuoi.Text); };
            bn.khuvuc = txtKhuVuc.Text;
            bn.maBenh = txtmaBenh.Text;
            if (txtTuoiNghe.Text == string.Empty) { bn.tuoinghe = 0; } else { bn.tuoinghe = int.Parse(txtTuoiNghe.Text); };
            bn.tinhTrang = cbTinhTrang.Text;
            bn.phuongPhap = txtPhuongPhap.Text;
            bn.luuY = txtLuuY.Text;
            bn.timeRec = dtpTimeRec.Text;
            bn.idBN = int.Parse(dtgBM.CurrentRow.Cells[0].Value.ToString());
            bool kq = BUS.bieumau5BUS.SuaBN(bn);
            if (kq == true)
            {
                getDATA_SQL();
            }
            else { MessageBoxEx.Show("Sửa dữ liệu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenBN.Text != string.Empty)
            {
                if (txtTuoi.Text != string.Empty)
                {
                    if (cbTenBenh.SelectedIndex != 0)
                    {

                        try
                        {
                            editData();
                            MessageBoxEx.Show("Sửa dữ liệu Thành Công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSua.Enabled = false;
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }


                    }
                    else { MessageBoxEx.Show("Loại Bệnh Không Hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else { MessageBoxEx.Show("Tuổi Bệnh Nhân Không Hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBoxEx.Show("Tên Bệnh Nhân Không Hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if(cbKieuIn.SelectedIndex == 0)
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("idBN", typeof(Int16));
                dt.Columns.Add("TenBN", typeof(string));
                dt.Columns.Add("gioitinh", typeof(string));
                dt.Columns.Add("tuoi", typeof(Int16));
                dt.Columns.Add("tuoinghe", typeof(Int16));
                dt.Columns.Add("khuvuc", typeof(string));
                dt.Columns.Add("tinhtrang", typeof(string));
                dt.Columns.Add("phuongphap", typeof(string));
                dt.Columns.Add("luuY", typeof(string));
                dt.Columns.Add("timeRec", typeof(string));
                dt.Columns.Add("tenBenh", typeof(string));


                //add datagridview data to table
                foreach (DataGridViewRow dgv in dtgBM.Rows)
                {
                    dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value,
                        dgv.Cells[10].Value);
                }
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("bieumau5.xml");

                //transefer data to crystalreportviewer
                report.bieumau5 bm = new report.bieumau5();
                bm.SetDataSource(ds);
                PRINTVIEW.phieuCLS form = new PRINTVIEW.phieuCLS();
                form.Text = "QUẢN LÝ BỆNH MÃN TÍNH";
                form.crystalReportViewer1.ReportSource = bm;
                form.ShowDialog();
            } 
            else
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("idBN", typeof(Int16));
                dt.Columns.Add("TenBN", typeof(string));
                dt.Columns.Add("gioitinh", typeof(string));
                dt.Columns.Add("tuoi", typeof(Int16));
                dt.Columns.Add("tuoinghe", typeof(Int16));
                dt.Columns.Add("khuvuc", typeof(string));
                dt.Columns.Add("tinhtrang", typeof(string));
                dt.Columns.Add("phuongphap", typeof(string));
                dt.Columns.Add("luuY", typeof(string));
                dt.Columns.Add("timeRec", typeof(string));
                dt.Columns.Add("tenBenh", typeof(string));


                //add datagridview data to table
                foreach (DataGridViewRow dgv in dtgBM.Rows)
                {
                    dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value,
                        dgv.Cells[10].Value);
                }
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("bieumau6.xml");

                //transefer data to crystalreportviewer
                report.bieumau6 bm = new report.bieumau6();
                bm.SetDataSource(ds);
                PRINTVIEW.phieuCLS form = new PRINTVIEW.phieuCLS();
                form.Text = "QUẢN LÝ BỆNH MÃN TÍNH THEO TỪNG BỆNH";
                form.crystalReportViewer1.ReportSource = bm;
                form.ShowDialog();
            }
        }

        private void txtTuoiNghe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtTuoiNghe.Text.Length == 0 || txtTuoiNghe.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtTuoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtTuoi.Text.Length == 0 || txtTuoi.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
