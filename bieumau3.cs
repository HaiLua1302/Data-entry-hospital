using CrystalDecisions.CrystalReports.Engine;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PKBNV
{
    public partial class bieumau3 : Form
    {
        public bieumau3()
        {
            InitializeComponent();
        }

        private void bieumau3_Load(object sender, EventArgs e)
        {
            getNhombenh();
            formatNam();
            getDataSql();
            hint();
            dtgBM.DefaultCellStyle.ForeColor = Color.Blue;
            txtmaBenh.Text = "";
            btnSua.Enabled = false;
        }
        // display hint
        public void hint()
        {
            System.Windows.Forms.ToolTip tool = new System.Windows.Forms.ToolTip();
            tool.SetToolTip(btnFilter, "Chọn năm để tìm dữ liệu.");
        }
        //format nam
        public void formatNam()
        {
            dtpNam.Format = DateTimePickerFormat.Custom;
            dtpNam.CustomFormat = "yyyy";
            dtpNam.ShowUpDown = true;
            dtpNam.Value = DateTime.Now;
        }
        //color move cell datagridview
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        //get data from sql
        public void getDataSql()
        {
            DataTable _dskq = BUS.bieumau3BUS.getDSBM();
            dtgBM.DataSource = _dskq;
        }

        //get data from sql duplicate
        public void getDataSql_duplicate()
        {
            CLASS.bieumau3 bm = new CLASS.bieumau3();
            bm.maBenh = txtmaBenh.Text;
            bm.nam = int.Parse(dtpNam.Text);
            DataTable _dskq = BUS.bieumau3BUS.getDSBM_duplicate(bm);
            dtgBM.DataSource = _dskq;
        }
        //get data from sql filter
        public void getDataSql_filter()
        {
            CLASS.bieumau3 bm = new CLASS.bieumau3();
            bm.nam = int.Parse(dtpNam.Text);
            DataTable _dskq = BUS.bieumau3BUS.getDSBM_filter(bm);
            dtgBM.DataSource = _dskq;
        }
        //ham them
        public void themDoiTuong()
        {
            CLASS.bieumau3 bm = new CLASS.bieumau3();
            bm.maBenh = txtmaBenh.Text;
            bm.nam = int.Parse(dtpNam.Text);
            if (txtT1.Text == string.Empty) { bm.thang1 = 0 ; } else { bm.thang1 = int.Parse(txtT1.Text);};
            if (txtT2.Text == string.Empty) { bm.thang2 = 0 ; } else { bm.thang2 = int.Parse(txtT2.Text);};
            if (txtT3.Text == string.Empty) { bm.thang3 = 0 ; } else { bm.thang3 = int.Parse(txtT3.Text);};
            if (txtT4.Text == string.Empty) { bm.thang4 = 0 ; } else { bm.thang4 = int.Parse(txtT4.Text);};
            if (txtT5.Text == string.Empty) { bm.thang5 = 0 ; } else { bm.thang5 = int.Parse(txtT5.Text);};
            if (txtT6.Text == string.Empty) { bm.thang6 = 0 ; } else { bm.thang6 = int.Parse(txtT6.Text);};
            if (txtT7.Text == string.Empty) { bm.thang7 = 0 ; } else { bm.thang7 = int.Parse(txtT7.Text);};
            if (txtT8.Text == string.Empty) { bm.thang8 = 0 ; } else { bm.thang8 = int.Parse(txtT8.Text);};
            if (txtT9.Text == string.Empty) { bm.thang9 = 0 ; } else { bm.thang9 = int.Parse(txtT9.Text);};
            if (txtT10.Text == string.Empty) { bm.thang10 = 0 ; } else { bm.thang10 = int.Parse(txtT10.Text);};
            if (txtT11.Text == string.Empty) { bm.thang11 = 0 ; } else { bm.thang11 = int.Parse(txtT11.Text);};
            if (txtT12.Text == string.Empty) { bm.thang12 = 0 ; } else { bm.thang12 = int.Parse(txtT12.Text);};
            bm.tongNam = bm.thang1 + bm.thang2 + bm.thang3 + bm.thang4 + bm.thang5 + bm.thang6 +
                bm.thang7 + bm.thang8 + bm.thang9 + bm.thang10 + bm.thang11 + bm.thang12;
            bool kq = BUS.bieumau3BUS.ThemBM(bm);
            if (kq == true)
            {
                getDataSql();
            }
            else
            {
                MessageBoxEx.Show("Thêm dữ liệu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        //cap nhat
        public void capnhatBM()
        {
            CLASS.bieumau3 bm = new CLASS.bieumau3();
            bm.maBenh = txtmaBenh.Text;
            bm.nam = int.Parse(dtpNam.Text);
            bm.idBM3 = int.Parse(dtgBM.CurrentRow.Cells[0].Value.ToString());
            if (txtT1.Text == string.Empty) { bm.thang1 = 0; } else { bm.thang1 = int.Parse(txtT1.Text); };
            if (txtT2.Text == string.Empty) { bm.thang2 = 0; } else { bm.thang2 = int.Parse(txtT2.Text); };
            if (txtT3.Text == string.Empty) { bm.thang3 = 0; } else { bm.thang3 = int.Parse(txtT3.Text); };
            if (txtT4.Text == string.Empty) { bm.thang4 = 0; } else { bm.thang4 = int.Parse(txtT4.Text); };
            if (txtT5.Text == string.Empty) { bm.thang5 = 0; } else { bm.thang5 = int.Parse(txtT5.Text); };
            if (txtT6.Text == string.Empty) { bm.thang6 = 0; } else { bm.thang6 = int.Parse(txtT6.Text); };
            if (txtT7.Text == string.Empty) { bm.thang7 = 0; } else { bm.thang7 = int.Parse(txtT7.Text); };
            if (txtT8.Text == string.Empty) { bm.thang8 = 0; } else { bm.thang8 = int.Parse(txtT8.Text); };
            if (txtT9.Text == string.Empty) { bm.thang9 = 0; } else { bm.thang9 = int.Parse(txtT9.Text); };
            if (txtT10.Text == string.Empty) { bm.thang10 = 0; } else { bm.thang10 = int.Parse(txtT10.Text); };
            if (txtT11.Text == string.Empty) { bm.thang11 = 0; } else { bm.thang11 = int.Parse(txtT11.Text); };
            if (txtT12.Text == string.Empty) { bm.thang12 = 0; } else { bm.thang12 = int.Parse(txtT12.Text); };
            bm.tongNam = bm.thang1 + bm.thang2 + bm.thang3 + bm.thang4 + bm.thang5 + bm.thang6 +
                bm.thang7 + bm.thang8 + bm.thang9 + bm.thang10 + bm.thang11 + bm.thang12;
            bool kq = BUS.bieumau3BUS.SuaBM(bm);
            if (kq == true)
            {
                getDataSql_duplicate();
            }
            else
            {
                MessageBoxEx.Show("Sửa dữ liệu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbTenBenh.SelectedIndex != 0)
            {
                int kqCheck = BUS.timkiemBUS.checkDuplicateBM3(txtmaBenh.Text, dtpNam.Text);
                if (kqCheck > 0)
                {
                    MessageBoxEx.Show("Dữ liệu "+cbTenBenh.Text+" năm "+dtpNam.Text+" đã có! Vui lòng chọn và sửa.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getDataSql_duplicate();
                    try
                    {
                        capnhatBM();
                     }
                     catch (Exception Ex) { MessageBoxEx.Show(Ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    try
                    {
                        themDoiTuong();
                    }
                    catch (Exception Ex) { MessageBoxEx.Show(Ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
               
            } else {
                cbTenBenh.Focus();
                MessageBoxEx.Show("Chưa nhập thông tin bệnh", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
        }

        private void cbThang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //get value cbtenbenh to textbox maBenh
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmaBenh.Text = cbTenBenh.SelectedValue.ToString();    
        }

        //get value from datagrid view into field
        private void dtgBM_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if(dtgBM.SelectedCells.Count > 0)
            {
                string tenBenh = dtgBM.CurrentRow.Cells[17].Value.ToString();
                string t1 = dtgBM.CurrentRow.Cells[1].Value.ToString();
                string t2 = dtgBM.CurrentRow.Cells[2].Value.ToString();
                string t3 = dtgBM.CurrentRow.Cells[3].Value.ToString();
                string t4 = dtgBM.CurrentRow.Cells[4].Value.ToString();
                string t5 = dtgBM.CurrentRow.Cells[5].Value.ToString();
                string t6 = dtgBM.CurrentRow.Cells[6].Value.ToString();
                string t7 = dtgBM.CurrentRow.Cells[7].Value.ToString();
                string t8 = dtgBM.CurrentRow.Cells[8].Value.ToString();
                string t9 = dtgBM.CurrentRow.Cells[9].Value.ToString();
                string t10 = dtgBM.CurrentRow.Cells[10].Value.ToString();
                string t11 = dtgBM.CurrentRow.Cells[11].Value.ToString();
                string t12 = dtgBM.CurrentRow.Cells[12].Value.ToString();
                string nam = dtgBM.CurrentRow.Cells[13].Value.ToString();
                //MessageBoxEx.Show(dtgBM.CurrentRow.Cells[14].Value.ToString()+ dtgBM.CurrentRow.Cells[15].Value.ToString()+ dtgBM.CurrentRow.Cells[16].Value.ToString(), "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNam.Value = DateTime.ParseExact(nam, "yyyy", CultureInfo.InvariantCulture);
                cbTenBenh.Text = tenBenh;
                txtT1.Text = t1;
                txtT2.Text = t2;
                txtT3.Text = t3;
                txtT4.Text = t4;
                txtT5.Text = t5;
                txtT6.Text = t6;
                txtT7.Text = t7;
                txtT8.Text = t8;
                txtT9.Text = t9;
                txtT10.Text = t10;
                txtT11.Text = t11;
                txtT12.Text = t12;

            }
            btnSua.Enabled = true;
            cbTenBenh.Enabled = false;
            dtpNam.Enabled = false;
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            try { getDataSql();
                txtT1.Text = "";
                txtT2.Text = "";
                txtT3.Text = "";
                txtT4.Text = "";
                txtT5.Text = "";
                txtT6.Text = "";
                txtT7.Text = "";
                txtT8.Text = "";
                txtT9.Text = "";
                txtT10.Text = "";
                txtT11.Text = "";
                txtT12.Text = "";
                txtmaBenh.Text = "";
                cbTenBenh.SelectedIndex = 0;
                formatNam();
                btnSua.Enabled = false;
                cbTenBenh.Enabled = true;
                dtpNam.Enabled = true;
            } catch (Exception ex) { MessageBoxEx.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try {
                capnhatBM();
                getDataSql_duplicate();
                MessageBoxEx.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }catch (Exception ex) { MessageBoxEx.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

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

                    bool kq = BUS.bieumau3BUS.XoaBM(idBM);
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

        //xuat excel
        private void copyAlltoClipboard()
        {
            dtgBM.SelectAll();
            DataObject dataObj = dtgBM.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        //xoá đối tượng
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
        //dem stt
        private void dtgBM_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        //tìm kiếm
        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                getDataSql_filter();
            }
            catch (Exception ex) { MessageBoxEx.Show(ex.Message + "Không Tìm Thấy!!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

       

      

        private void btnIn_Click(object sender, EventArgs e)
        {/*
            int count = dtgBM.Rows.Count;
            string nam = dtgBM.Rows[0].Cells[13].Value.ToString();
            int temp = 0;
            for (int i = 0; i < count;i++)
            {
                if( dtgBM.Rows[i].Cells[13].Value.ToString() != nam )
                {
                    temp++;
                }
            }
            if(temp > 0)
            { MessageBoxEx.Show("Chọn năm cần in", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
               
            }*/
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("idBM", typeof(Int16));
            dt.Columns.Add("T1", typeof(Int16));
            dt.Columns.Add("T2", typeof(Int16));
            dt.Columns.Add("T3", typeof(Int16));
            dt.Columns.Add("T4", typeof(Int16));
            dt.Columns.Add("T5", typeof(Int16));
            dt.Columns.Add("T6", typeof(Int16));
            dt.Columns.Add("T7", typeof(Int16));
            dt.Columns.Add("T8", typeof(Int16));
            dt.Columns.Add("T9", typeof(Int16));
            dt.Columns.Add("T10", typeof(Int16));
            dt.Columns.Add("T11", typeof(Int16));
            dt.Columns.Add("T12", typeof(Int16));
            dt.Columns.Add("nam", typeof(Int16));
            dt.Columns.Add("tong", typeof(Int16));
            dt.Columns.Add("timeREC", typeof(string));
            dt.Columns.Add("maBenh", typeof(string));
            dt.Columns.Add("tenBenh", typeof(string));


            //add datagridview data to table
            foreach (DataGridViewRow dgv in dtgBM.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value, dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value,
                    dgv.Cells[10].Value, dgv.Cells[11].Value, dgv.Cells[12].Value, dgv.Cells[13].Value, dgv.Cells[14].Value, dgv.Cells[15].Value, dgv.Cells[16].Value, dgv.Cells[17].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("bieumau3.xml");

            //transefer data to crystalreportviewer
            string path = Directory.GetCurrentDirectory().ToString() + @"\report\bieumau3.rpt";
            ReportDocument report = new ReportDocument();
            report.Load(path);
            report.SetDataSource(ds);
            PRINTVIEW.phieuCLS form = new PRINTVIEW.phieuCLS();
            form.Text = "TÌNH HÌNH BỆNH TẬT TRONG THỜI GIAN BÁO CÁO";
            form.crystalReportViewer1.ReportSource = report;
            form.ShowDialog();
        }

        private void txtT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtT1.Text.Length == 0 || txtT1.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtT2.Text.Length == 0 || txtT2.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtT3.Text.Length == 0 || txtT3.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtT4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtT4.Text.Length == 0 || txtT4.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtT5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtT5.Text.Length == 0 || txtT5.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtT6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtT6.Text.Length == 0 || txtT6.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtT7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtT7.Text.Length == 0 || txtT7.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtT8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtT8.Text.Length == 0 || txtT8.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtT9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtT9.Text.Length == 0 || txtT9.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtT10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtT10.Text.Length == 0 || txtT10.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtT11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtT11.Text.Length == 0 || txtT11.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtT12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtT12.Text.Length == 0 || txtT12.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void dtpNam_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
