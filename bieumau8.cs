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
    public partial class bieumau8 : Form
    {
        public bieumau8()
        {
            InitializeComponent();
        }
        //load data,funtion...
        private void bieumau8_Load(object sender, EventArgs e)
        {
            formatNam();
            getDataSql();
            insert_dt_cb();
            autoCompleteData_cv_before();
            autoCompleteData_tenBNN();
            autoCompleteData_cvHiennay();
            autoCompleteData_Phuongphap();
            autoCompleteData_luuY();
            btnSua.Enabled = false;
            dtgBM.DefaultCellStyle.ForeColor = Color.Blue;
        }
        //format nam
        public void formatNam()
        {
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "dd-MM-yyyy";
            dtpFrom.Value = DateTime.Now;

            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "dd-MM-yyyy";
            dtpTo.Value = DateTime.Now;

            dtpPhatHien.Format = DateTimePickerFormat.Custom;
            dtpPhatHien.CustomFormat = "dd-MM-yyyy";
            dtpPhatHien.Value = DateTime.Now;
        }
        //insert data combobox
        public void insert_dt_cb()
        {
            cbGT.Items.Add("Nam");
            cbGT.Items.Add("Nữ");
            cbGT.SelectedIndex = 0;

            cbFilter.Items.Add("---Theo tên BN---");
            cbFilter.Items.Add("---Theo Giới Tính---");
            cbFilter.Items.Add("---Theo Tuổi---");
            cbFilter.Items.Add("---Theo Tên BNN---");
            cbFilter.Items.Add("---Theo Tỷ lệ %---");
            cbFilter.Items.Add("---Theo Ngày Tháng---");
            cbFilter.SelectedIndex = 0;
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
        //stt
        private void dtgBM_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        //auto completedata nghe truoc khi bi bnn
        private void autoCompleteData_cv_before()
        {
            SqlConnection con = new SqlConnection(getDB._connectionString);
            SqlCommand com = new SqlCommand("Select cvTruocBNN from bieumau8", con);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            //AutoCompleteStringCollection Contains a collection of strings to use for the auto-complete feature on certain Windows Forms controls.
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            while (rdr.Read())
            {
                autoCompleteCollection.Add(rdr.GetString(0));
            }
            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtCV_before.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtCV_before.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCV_before.AutoCompleteCustomSource = autoCompleteCollection;
            con.Close();
        }
        //auto completedata ten bnn
        private void autoCompleteData_tenBNN()
        {
            SqlConnection con = new SqlConnection(getDB._connectionString);
            SqlCommand com = new SqlCommand("Select cvTruocBNN from bieumau8", con);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            //AutoCompleteStringCollection Contains a collection of strings to use for the auto-complete feature on certain Windows Forms controls.
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            while (rdr.Read())
            {
                autoCompleteCollection.Add(rdr.GetString(0));
            }
            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtTenBNN.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtTenBNN.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTenBNN.AutoCompleteCustomSource = autoCompleteCollection;
            con.Close();
        }
        //auto completedata ten bnn
        private void autoCompleteData_cvHiennay()
        {
            SqlConnection con = new SqlConnection(getDB._connectionString);
            SqlCommand com = new SqlCommand("Select cvHienNay from bieumau8", con);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            //AutoCompleteStringCollection Contains a collection of strings to use for the auto-complete feature on certain Windows Forms controls.
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            while (rdr.Read())
            {
                autoCompleteCollection.Add(rdr.GetString(0));
            }
            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtCV_hiennay.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtCV_hiennay.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCV_hiennay.AutoCompleteCustomSource = autoCompleteCollection;
            con.Close();
        }
        //auto completedata phương pháp
        private void autoCompleteData_Phuongphap()
        {
            SqlConnection con = new SqlConnection(getDB._connectionString);
            SqlCommand com = new SqlCommand("Select phuongPhap from bieumau8", con);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            //AutoCompleteStringCollection Contains a collection of strings to use for the auto-complete feature on certain Windows Forms controls.
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            while (rdr.Read())
            {
                autoCompleteCollection.Add(rdr.GetString(0));
            }
            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtPhuongPhap.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtPhuongPhap.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPhuongPhap.AutoCompleteCustomSource = autoCompleteCollection;
            con.Close();
        }
        //auto completedata phương pháp
        private void autoCompleteData_luuY()
        {
            SqlConnection con = new SqlConnection(getDB._connectionString);
            SqlCommand com = new SqlCommand("Select luuY from bieumau8", con);
            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            //AutoCompleteStringCollection Contains a collection of strings to use for the auto-complete feature on certain Windows Forms controls.
            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            while (rdr.Read())
            {
                autoCompleteCollection.Add(rdr.GetString(0));
            }
            //Set AutoCompleteSource property of txt_StateName as CustomSource
            txtLuuY.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteMode property of txt_StateName as SuggestAppend. SuggestAppend Applies both Suggest and Append
            txtLuuY.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtLuuY.AutoCompleteCustomSource = autoCompleteCollection;
            con.Close();
        }
        //get data from sql
        public void getDataSql()
        {
            DataTable _dskq = BUS.bieumau8BUS.getDSKQ_SQL();
            dtgBM.DataSource = _dskq;
        }
        //insert data
        public void insert_data()
        {
            CLASS.benhnhan bn = new CLASS.benhnhan();
            CLASS.bieumau8 bm = new CLASS.bieumau8();

            bn.tenBN = txtTenBN.Text;
            bn.gioitinh = cbGT.Text;
            bn.tuoi = int.Parse(txtNS.Text);

            bm.nghe_before = txtCV_before.Text;
            bm.tuoiNghe = float.Parse(txtTuoi_nghe.Text);
            bm.ngayPhatHien = dtpPhatHien.Text;
            bm.tenBNN = txtTenBN.Text;
            bm.phuongPhap = txtPhuongPhap.Text;
            bm.tyLyld = txtTyleLD.Text + " %";
            bm.cvHienNay = txtCV_hiennay.Text;
            bm.timeRec = dtpTo.Text;
            bm.luuY = txtLuuY.Text;

            bool kq = BUS.bieumau8BUS.insertDATA(bm,bn);
            if(kq == true)
            {
                getDataSql();
            }

        }
        //insert data has id
        public void insert_data_has_id()
        {
            CLASS.benhnhan bn = new CLASS.benhnhan();
            CLASS.bieumau8 bm = new CLASS.bieumau8();
            
            bn.tenBN = txtTenBN.Text;
            bn.gioitinh = cbGT.Text;
            if (txtNS.Text == string.Empty) { bn.tuoi = 0; } else { bn.tuoi = int.Parse(txtNS.Text); };
   
            bm.nghe_before = txtCV_before.Text;
            if (txtTuoi_nghe.Text == string.Empty) { bm.tuoiNghe = 0; } else { bm.tuoiNghe = float.Parse(txtTuoi_nghe.Text); };
            bm.ngayPhatHien = dtpPhatHien.Text;
            bm.tenBNN = txtTenBN.Text;
            bm.phuongPhap = txtPhuongPhap.Text;
            bm.tyLyld = txtTyleLD.Text + " %";
            bm.cvHienNay = txtCV_hiennay.Text;
            bm.luuY = txtLuuY.Text;
            bm.timeRec = dtpTo.Text;
            bm.idBN = int.Parse(txtidBN.Text);

            bool kq = BUS.bieumau8BUS.insertDATA(bm, bn);
            if (kq == true)
            {
                getDataSql();
            }

        }
        private void btnThem_Click(object sender, EventArgs e)
        {   
            if(txtTenBN.Text != string.Empty)
            {
                int idBN;
                if (txtidBN.Text == string.Empty)
                {
                    idBN = 0;
                }
                else { idBN = int.Parse(txtidBN.Text); };

                int check = BUS.timkiemBUS.checkDuplicate_bm8(idBN);
                int kq = BUS.timkiemBUS.checkData_bn_null(idBN);

                if (check == 0)
                {
                    if (kq == 0)
                    {
                        try
                        {
                            insert_data();
                            MessageBox.Show("Thêm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        try
                        {
                            insert_data_has_id();
                            MessageBox.Show("Thêm Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                } else { MessageBoxEx.Show("Dữ liệu này đã có ,\nVui lòng chọn và sửa !!!", "Thông Báo !!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }
        //refresh
        private void btnMoi_Click(object sender, EventArgs e)
        {
            getDataSql();
            formatNam();
            txtidBN.Text = "";
            txtTenBN.Text = "";
            cbGT.SelectedIndex = 0;
            txtNS.Text = "";
            txtCV_before.Text = "";
            txtTuoi_nghe.Text = "";
            txtTenBNN.Text = "";
            txtCV_hiennay.Text = "";
            txtTyleLD.Text = "";
            txtPhuongPhap.Text = "";
            txtLuuY.Text = "";
            btnSua.Enabled = false;
            txtidBN.Enabled = true;
        }
        //delete data
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idx = dtgBM.CurrentRow.Index;  
            if (dtgBM.Rows[idx].Cells[0].Value.ToString() != "")
            {
                int idx_bm = int.Parse(dtgBM.CurrentRow.Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show("Xác nhận xóa KQ?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {

                    bool kq_bm = BUS.bieumau8BUS.deleteDATA(idx_bm);
                    if (kq_bm == true)
                    {
                        try
                        {
                            MessageBoxEx.Show("Đã xóa kết quả biểu mẫu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult result_bn = MessageBox.Show("Xác nhận xoá dữ liệu bệnh nhân !!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                            if (result_bn == DialogResult.Yes)
                            {
                                int idx_bn = int.Parse(dtgBM.CurrentRow.Cells[1].Value.ToString());
                                bool kq_bn = BUS.bieumau8BUS.deleteDATA_BN(idx_bn);
                                if (kq_bn == true)
                                {
                                    MessageBoxEx.Show("Đã xóa dữ liệu bệnh nhân!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    getDataSql();
                                }    
                            }
                                getDataSql();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); };
                    }
                    else { MessageBoxEx.Show("Không thể xoá kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                }
            }
            else { MessageBoxEx.Show("Không tìm thấy KQ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }                   
        }
        //pass data to textbox from datagridview
        private void dtgBM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgBM.SelectedCells.Count > 0)
            {
                string idMB = dtgBM.CurrentRow.Cells[0].Value.ToString();
                string idBN = dtgBM.CurrentRow.Cells[1].Value.ToString();
                string tenBn = dtgBM.CurrentRow.Cells[2].Value.ToString();
                string gioitinh = dtgBM.CurrentRow.Cells[3].Value.ToString();
                string tuoi = dtgBM.CurrentRow.Cells[4].Value.ToString();
                string cv_before = dtgBM.CurrentRow.Cells[5].Value.ToString();
                string tuoinghe = dtgBM.CurrentRow.Cells[6].Value.ToString();
                string ngayPhatHien = dtgBM.CurrentRow.Cells[7].Value.ToString();
                string tenBNN = dtgBM.CurrentRow.Cells[8].Value.ToString();
                string phuongphap = dtgBM.CurrentRow.Cells[9].Value.ToString();
                string tyleLD = dtgBM.CurrentRow.Cells[10].Value.ToString();
                string cvHienNay = dtgBM.CurrentRow.Cells[11].Value.ToString();
                string luuY = dtgBM.CurrentRow.Cells[12].Value.ToString();
                string timeRec = dtgBM.CurrentRow.Cells[13].Value.ToString();

                txtidBN.Text = idBN;
                txtTenBN.Text = tenBn;
                cbGT.Text = gioitinh;
                txtNS.Text = tuoi;
                txtCV_before.Text = cv_before;
                txtTuoi_nghe.Text = tuoinghe;
                dtpPhatHien.Value = DateTime.ParseExact(ngayPhatHien, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                txtTenBNN.Text = tenBNN;
                txtCV_hiennay.Text = cvHienNay;
                txtTyleLD.Text = tyleLD;
                txtPhuongPhap.Text = phuongphap;
                txtLuuY.Text = luuY;

                btnSua.Enabled = true;
                txtidBN.Enabled = false;
            }
        }
        //edit data
        public void edit_data()
        {
            CLASS.benhnhan bn = new CLASS.benhnhan();
            CLASS.bieumau8 bm = new CLASS.bieumau8();

            bn.idBN = int.Parse(txtidBN.Text);
            bn.tenBN = txtTenBN.Text;
            bn.gioitinh = cbGT.Text;
            if (txtNS.Text == string.Empty) { bn.tuoi = 0; } else { bn.tuoi = int.Parse(txtNS.Text); };

            bm.idBN = int.Parse(txtidBN.Text);
            bm.nghe_before = txtCV_before.Text;
            if (txtTuoi_nghe.Text == string.Empty) { bm.tuoiNghe = 0; } else { bm.tuoiNghe = float.Parse(txtTuoi_nghe.Text); };
            bm.ngayPhatHien = dtpPhatHien.Text;
            bm.tenBNN = txtTenBN.Text;
            bm.phuongPhap = txtPhuongPhap.Text;
            bm.tyLyld = txtTyleLD.Text + " %";
            bm.cvHienNay = txtCV_hiennay.Text;
            bm.luuY = txtLuuY.Text;
            bm.timeRec = dtpTo.Text;
            bm.idBN = int.Parse(txtidBN.Text);

            bool kq = BUS.bieumau8BUS.updateDATA(bm, bn);
            if (kq == true)
            {
                getDataSql();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                edit_data();
                MessageBoxEx.Show("Cập nhật dữ liệu thành công!!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

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
        //printer
        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("idBM", typeof(Int16));
            dt.Columns.Add("idBN", typeof(Int16));
            dt.Columns.Add("tenBN", typeof(string));
            dt.Columns.Add("gioitinh", typeof(string));
            dt.Columns.Add("tuoi", typeof(Int16));
            dt.Columns.Add("cv_before", typeof(string));
            dt.Columns.Add("tuoiNghe", typeof(float));
            dt.Columns.Add("ngayPhathien", typeof(string));
            dt.Columns.Add("tenBNN", typeof(string));
            dt.Columns.Add("phuongphap", typeof(string));
            dt.Columns.Add("tyleLD", typeof(string));
            dt.Columns.Add("cvHienNay", typeof(string));
            dt.Columns.Add("luuY", typeof(string));
            dt.Columns.Add("timeRec", typeof(string));


            //add datagridview data to table
            foreach (DataGridViewRow dgv in dtgBM.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value,
                    dgv.Cells[10].Value, dgv.Cells[11].Value, dgv.Cells[12].Value, dgv.Cells[13].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("bieumau8.xml");

            //transefer data to crystalreportviewer
            report.bieumau8 bm = new report.bieumau8();
            bm.SetDataSource(ds);
            PRINTVIEW.phieuCLS form = new PRINTVIEW.phieuCLS();
            form.Text = "DANH SÁCH NGƯỜI LAO ĐỘNG MẮC BỆNH NGHỀ NGHIỆP";
            form.crystalReportViewer1.ReportSource = bm;
            form.ShowDialog();
        }
        //format input textbox
        private void txtidBN_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(getDB._connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT tenBN ,gioitinh ,tuoi FROM benhnhan WHERE idBN = " + txtidBN.Text))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            con.Open();
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                sdr.Read();
                                txtTenBN.Text = sdr["tenBN"].ToString();
                                cbGT.Text = sdr["gioitinh"].ToString();
                                txtNS.Text = sdr["tuoi"].ToString();
                                txtidBN.Enabled = false;
                            }
                            con.Close();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };


            }
        }
        private void txtNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                (e.KeyChar == '.' && (txtNS.Text.Length == 0 || txtNS.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }
        private void txtTuoi_nghe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                (e.KeyChar == '.' && (txtTuoi_nghe.Text.Length == 0 || txtTuoi_nghe.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }
        private void txtTyleLD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                (e.KeyChar == '.' && (txtTyleLD.Text.Length == 0 || txtTyleLD.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }
        private void txtidBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
               (e.KeyChar == '.' && (txtidBN.Text.Length == 0 || txtidBN.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }
        //filter
        private void btnFilter_Click(object sender, EventArgs e)
        {
            /*cbFilter.Items.Add("---Theo tên BN---");
            cbFilter.Items.Add("---Theo Giới Tính---");
            cbFilter.Items.Add("---Theo Tuổi---");
            cbFilter.Items.Add("---Theo Tên BNN---");
            cbFilter.Items.Add("---Theo Tỷ lệ %---");
            cbFilter.Items.Add("---Theo Ngày Tháng---");*/
            int idx = cbFilter.SelectedIndex;
            string cmt = "";
            switch(idx)
            {
                case 0:
                    cmt = "tenBN LIKE N'%" + txtTenBN.Text + "%'";
                    break;
                case 1:
                    cmt = "gioitinh LIKE N'%" + cbGT.Text + "%'";
                    break;
                case 2:
                    cmt = "tuoi = " + txtNS.Text ;
                    break;
                case 3:
                    cmt = "tenBNN LIKE N'%" + txtTenBNN.Text + "%'";
                    break;
                case 4:
                    cmt = "tyleLD LIKE N'%" + txtTyleLD.Text + "%'";
                    break;
                case 5:
                    cmt = "timeRec BETWEEN N'" + dtpFrom.Text + "' AND N'" + dtpTo.Text + "'";
                    break;
            }
            try
            {
                DataTable _dskq = BUS.timkiemBUS.search_by_filter_bm8(cmt);
                dtgBM.DataSource = _dskq;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

        }

        private void dtgBM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
