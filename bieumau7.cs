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
    public partial class bieumau7 : Form
    {
        public bieumau7()
        {
            InitializeComponent();
        }

        private void bieumau7_Load(object sender, EventArgs e)
        {
            formatNam();
            getDataSql();
            getNhombenh();
            insert_dt_cb();

            btnSua.Enabled = false;
            txtmaBenh.Text = "";
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
        //insert data combobox
        public void insert_dt_cb()
        {
            cbTK.Items.Add("---Theo Bệnh---");
            cbTK.Items.Add("---Theo Ngày Tháng---");
            cbTK.SelectedIndex = 0;
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

        //get value cbtenbenh to textbox maBenh
        private void cbTenBenh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmaBenh.Text = cbTenBenh.SelectedValue.ToString();
        }

        //get data from sql
        public void getDataSql()
        {
            DataTable _dskq = BUS.bieumau7BUS.getDSKQ_SQL();
            dtgBM.DataSource = _dskq;
        }
        //refresh
        private void btnMoi_Click(object sender, EventArgs e)
        {
            formatNam();
            getDataSql();
            cbTenBenh.SelectedIndex = 0;
            txtN_kham.Text = "";
            txtSL_kham.Text = "";
            txtN_cd.Text = "";
            txtSL_cd.Text = "";
            txtN_gd.Text = "";
            txtSL_gd.Text = "";
            txtN_5.Text = "";
            txtSL_5.Text = "";
            txtN_5_31.Text = "";
            txtSL_5_31.Text = "";
            txtN_31.Text = "";
            txtSL_31.Text = "";
            btnSua.Enabled = false;
            cbTenBenh.Enabled = true;
        }
        //insert database
        public void insert_data()
        {
            CLASS.bieumau7 bm = new CLASS.bieumau7();
            bm.ngaythang = dtpTo.Text;
            bm.maBenh = txtmaBenh.Text;
            if (txtSL_kham.Text == string.Empty) { bm.sl_kham = 0; } else { bm.sl_kham = int.Parse(txtSL_kham.Text); };
            if (txtN_kham.Text == string.Empty) { bm.sln_kham = 0; } else { bm.sln_kham = int.Parse(txtN_kham.Text); };
            if (txtN_cd.Text == string.Empty) { bm.sln_cd = 0; } else { bm.sln_cd = int.Parse(txtN_cd.Text); };
            if (txtSL_cd.Text == string.Empty) { bm.sl_cd = 0; } else { bm.sl_cd = int.Parse(txtSL_cd.Text); };
            if (txtN_gd.Text == string.Empty) { bm.sln_gd = 0; } else { bm.sln_gd = int.Parse(txtN_gd.Text); };
            if (txtSL_gd.Text == string.Empty) { bm.sl_gd = 0; } else { bm.sl_gd = int.Parse(txtSL_gd.Text); };
            if (txtN_5.Text == string.Empty) { bm.sln_15 = 0; } else { bm.sln_15 = int.Parse(txtN_5.Text); };
            if (txtSL_5.Text == string.Empty) { bm.sl_15 = 0; } else { bm.sl_15 = int.Parse(txtSL_5.Text); };
            if (txtN_5_31.Text == string.Empty) { bm.sln_15_31 = 0; } else { bm.sln_15_31 = int.Parse(txtN_5_31.Text); };
            if (txtSL_5_31.Text == string.Empty) { bm.sl_15_31 = 0; } else { bm.sl_15_31 = int.Parse(txtSL_5_31.Text); };
            if (txtN_31.Text == string.Empty) { bm.sln_31 = 0; } else { bm.sln_31 = int.Parse(txtN_31.Text); };
            if (txtSL_31.Text == string.Empty) { bm.sl_31 = 0; } else { bm.sl_31 = int.Parse(txtSL_31.Text); };

            bool kq = BUS.bieumau7BUS.insertDATA(bm);
            if(kq == true)
            {
                getDataSql();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            CLASS.bieumau7 bm = new CLASS.bieumau7();
            bm.ngaythang = dtpTo.Text;
            bm.maBenh = txtmaBenh.Text;
            int check = BUS.timkiemBUS.checkDuplicate_bm7(bm);
            if(txtmaBenh.Text != string.Empty)
            {
                if(check == 0)
                {
                    try { 
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
                    MessageBox.Show("Dữ liệu này đã có ,\nVui lòng chọn và sửa !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else { MessageBox.Show("Tên bệnh không hợp lệ !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cbTenBenh.Focus(); };
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idx = dtgBM.CurrentRow.Index;
            if (dtgBM.Rows[idx].Cells[0].Value.ToString() != "")
            {
                int idBM = int.Parse(dtgBM.Rows[idx].Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show("Xác nhận xóa KQ?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {

                    bool kq = BUS.bieumau7BUS.deleteDATA(idBM);
                    if (kq == true)
                    {
                        try
                        {
                            MessageBoxEx.Show("Đã xóa kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getDataSql();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); };
                    }
                    else { MessageBoxEx.Show("Không thể xoá kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                }
            }
            else { MessageBoxEx.Show("Không tìm thấy KQ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void dtgBM_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgBM.SelectedCells.Count > 0)
            {
                string idMB = dtgBM.CurrentRow.Cells[0].Value.ToString();
                string tenBenh = dtgBM.CurrentRow.Cells[1].Value.ToString();
                string ngayThang = dtgBM.CurrentRow.Cells[2].Value.ToString();

                string sl_kham = dtgBM.CurrentRow.Cells[3].Value.ToString();
                string sln_kham = dtgBM.CurrentRow.Cells[4].Value.ToString();

                string sl_cd = dtgBM.CurrentRow.Cells[5].Value.ToString();
                string sln_cd = dtgBM.CurrentRow.Cells[6].Value.ToString();

                string sl_gd = dtgBM.CurrentRow.Cells[7].Value.ToString();
                string sln_gd = dtgBM.CurrentRow.Cells[8].Value.ToString();

                string sl_5 = dtgBM.CurrentRow.Cells[9].Value.ToString();
                string sln_5 = dtgBM.CurrentRow.Cells[10].Value.ToString();

                string sl_5_31 = dtgBM.CurrentRow.Cells[11].Value.ToString();
                string sln_5_31 = dtgBM.CurrentRow.Cells[12].Value.ToString();

                string sl_31 = dtgBM.CurrentRow.Cells[13].Value.ToString();
                string sln_31 = dtgBM.CurrentRow.Cells[13].Value.ToString();

                cbTenBenh.Text = tenBenh;
                dtpTo.Value = DateTime.ParseExact(ngayThang, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                txtN_kham.Text = sln_kham;
                txtSL_kham.Text = sl_kham;

                txtN_cd.Text = sln_cd;
                txtSL_cd.Text = sl_cd;

                txtN_gd.Text = sln_gd;
                txtSL_gd.Text = sl_gd;

                txtN_5.Text = sln_5;
                txtSL_5.Text = sl_5;

                txtN_5_31.Text = sln_5_31;
                txtSL_5_31.Text = sl_5_31;

                txtN_31.Text = sln_31;
                txtSL_31.Text = sl_31;
            }
            btnSua.Enabled = true;
            cbTenBenh.Enabled = false;

        }
        //edit data
        public void edit_data()
        {

            CLASS.bieumau7 bm = new CLASS.bieumau7();
            bm.ngaythang = dtpTo.Text;
            bm.idBM7 = int.Parse(dtgBM.CurrentRow.Cells[0].Value.ToString());
            if (txtSL_kham.Text == string.Empty) { bm.sl_kham = 0; } else { bm.sl_kham = int.Parse(txtSL_kham.Text); };
            if (txtN_kham.Text == string.Empty) { bm.sln_kham = 0; } else { bm.sln_kham = int.Parse(txtN_kham.Text); };
            if (txtN_cd.Text == string.Empty) { bm.sln_cd = 0; } else { bm.sln_cd = int.Parse(txtN_cd.Text); };
            if (txtSL_cd.Text == string.Empty) { bm.sl_cd = 0; } else { bm.sl_cd = int.Parse(txtSL_cd.Text); };
            if (txtN_gd.Text == string.Empty) { bm.sln_gd = 0; } else { bm.sln_gd = int.Parse(txtN_gd.Text); };
            if (txtSL_gd.Text == string.Empty) { bm.sl_gd = 0; } else { bm.sl_gd = int.Parse(txtSL_gd.Text); };
            if (txtN_5.Text == string.Empty) { bm.sln_15 = 0; } else { bm.sln_15 = int.Parse(txtN_5.Text); };
            if (txtSL_5.Text == string.Empty) { bm.sl_15 = 0; } else { bm.sl_15 = int.Parse(txtSL_5.Text); };
            if (txtN_5_31.Text == string.Empty) { bm.sln_15_31 = 0; } else { bm.sln_15_31 = int.Parse(txtN_5_31.Text); };
            if (txtSL_5_31.Text == string.Empty) { bm.sl_15_31 = 0; } else { bm.sl_15_31 = int.Parse(txtSL_5_31.Text); };
            if (txtN_31.Text == string.Empty) { bm.sln_31 = 0; } else { bm.sln_31 = int.Parse(txtN_31.Text); };
            if (txtSL_31.Text == string.Empty) { bm.sl_31 = 0; } else { bm.sl_31 = int.Parse(txtSL_31.Text); };

            bool kq = BUS.bieumau7BUS.updateDATA(bm);
            if (kq == true)
            {
                getDataSql();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtmaBenh.Text != string.Empty)
            {
                try {
                    edit_data();
                    MessageBox.Show("Sửa Thành Công !!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSua.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { MessageBox.Show("Tên bệnh không hợp lệ !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); cbTenBenh.Focus(); };
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
        //tim kiem
        public void search_data()
        {
            int idx = cbTK.SelectedIndex;
            string cmt = "";
            switch(idx)
            {
                case 0:
                    cmt = "bm7.maBenh = '" + txtmaBenh.Text + "'";
                    break;
                case 1:
                    cmt = "ngaythang BETWEEN N'" + dtpFrom.Text + "' And N'" + dtpTo.Text + "'";
                    break;
            }
            DataTable _dskq = BUS.timkiemBUS.getDSKQ_condition_BM7(cmt);
            dtgBM.DataSource = _dskq;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                search_data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("idBM", typeof(Int16));
            dt.Columns.Add("tenBenh", typeof(string));
            dt.Columns.Add("ngaythang", typeof(string));
            dt.Columns.Add("sl_kham", typeof(Int16));
            dt.Columns.Add("sln_kham", typeof(Int16));
            dt.Columns.Add("sl_cd", typeof(Int16));
            dt.Columns.Add("sln_cd", typeof(Int16));
            dt.Columns.Add("sl_gd", typeof(Int16));
            dt.Columns.Add("sln_gd", typeof(Int16));
            dt.Columns.Add("sl_5", typeof(Int16));
            dt.Columns.Add("sln_5", typeof(Int16));
            dt.Columns.Add("sl_5_31", typeof(Int16));
            dt.Columns.Add("sln_5_31", typeof(Int16));
            dt.Columns.Add("sl_31", typeof(Int16));
            dt.Columns.Add("sln_31", typeof(Int16));


            //add datagridview data to table
            foreach (DataGridViewRow dgv in dtgBM.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value,
                    dgv.Cells[10].Value, dgv.Cells[11].Value, dgv.Cells[12].Value, dgv.Cells[13].Value, dgv.Cells[14].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("bieumau7.xml");

            //transefer data to crystalreportviewer
            report.bieumau7 bm = new report.bieumau7();
            bm.SetDataSource(ds);
            PRINTVIEW.phieuCLS form = new PRINTVIEW.phieuCLS();
            form.Text = "THEO DÕI BỆNH NGHỀ NGHIỆP";
            form.crystalReportViewer1.ReportSource = bm;
            form.ShowDialog();
        }
    }
}
