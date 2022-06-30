using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dapper;
using DevComponents.DotNetBar;

namespace PKBNV
{
    public partial class pkCLS : Form
    {
        public pkCLS()
        {
            InitializeComponent();
        }
        private void pkCLS_Load(object sender, EventArgs e)
        {       
            try
            {
                formatDate();
                getDSKQ();
                getPB();
                getChucDanh();
                getGT();
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }

        }
        //do du lieu vao cbPB
        public void getPB()
        {
            List<CLASS.phongban> _dspb = BUS.pbBUS.getPB();
            cbKP.DataSource = _dspb;
            cbKP.DisplayMember = "tenPB";
            cbKP.ValueMember = "idPB";
        }
        //do du lieu vao cbCD
        public void getChucDanh()
        {
            List<CLASS.chucdanh> _dscd = BUS.chucdanhBUS.getChucDanh();
            cbCD.DataSource = _dscd;
            cbCD.DisplayMember = "tenCD";
            cbCD.ValueMember = "idCD";
        }
        //do du lieu vao cbGT
        public void getGT()
        {
            cbGT.Items.Add("Nữ");
            cbGT.Items.Add("Nam");
            cbGT.SelectedIndex = 1;

        }
        //do du lieu vao datagridview
        public void getDSKQ()
        {
            DataTable _dskq = BUS.kqBUS.getDSKQ();
            dtgPKBNV.DataSource = _dskq;
        }
        //format date 
        public void formatDate()
        {
            dtpNhap.Format = DateTimePickerFormat.Custom;
            dtpNhap.CustomFormat = "dd-MM-yyyy";
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "dd-MM-yyyy";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "dd-MM-yyyy";


        }
        //color mouse move datagridview
        private void dtgPKBNV_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgPKBNV.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                dtgPKBNV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
        private void dtgPKBNV_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgPKBNV.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dtgPKBNV.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }
        //dem stt datagrid view
        private void dtgPKBNV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }

        }
        //them nhan vien
        public void themNhanVien()
        {
            string getidPB = BUS.pbBUS.LayidPBtuTenPB(cbKP.Text);
           // MessageBox.Show(idPB);
            CLASS.nhanvien nv = new CLASS.nhanvien();
                      
            nv.idPB = getidPB;
            nv.chucvu = cbCD.Text;
            nv.tenNV = txtHT.Text;
            nv.gtNV = cbGT.Text;
            nv.tuoiNV = int.Parse(txtTuoiNV.Text);
            nv.ngaynhap = dtpNhap.Text;

            try
            {
                bool kq = BUS.nhanvienBUS.ThemNhanVien(nv);
                if (kq == true)
                {
                    MessageBoxEx.Show("Thêm thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getDSKQ();
                }
                else
                {
                    MessageBoxEx.Show("Thêm thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }


        }
        //them phieu
        public void themPKCLS()
        {
            CLASS.kqKTCLS pk = new CLASS.kqKTCLS();
            pk.chieucao = txtCC.Text;
            pk.cannang = txtCN.Text;
            pk.BMI = txtBMI.Text;
            pk.mach = txtMach.Text;
            pk.huyetAp = txtHA.Text;
            pk.theLuc = txtKL.Text;
            pk.noiK = txtNoi.Text;
            pk.ngoaiK = txtNgoai.Text;
            pk.phuK = txtPhuK.Text;
            pk.TMH = txtTMH.Text;
            pk.daLieu = txtDL.Text;
            pk.RHM = txtRHM.Text;
            pk.ptTBMau = txtPTTB.Text;
            pk.ptNTieu = txtPTNT.Text;
            pk.duongHuyet = txtDuongH.Text;
            pk.sgot = txtSGOT.Text;
            pk.sgpt = txtSGPT.Text;
            pk.ure = txtUre.Text;
            pk.creatinin = txtCreatinin.Text;
            pk.xQuang = txtXQ.Text;
            pk.sieuAm = txtSieuA.Text;
            pk.plSK = txtPLSK.Text;
            pk.kL = txtKL.Text;
            pk.ghiChu = txtGhiChu.Text;
            //pk.idNV = int.Parse(DB.pkbnvDB.idNVlast());
            //MessageBox.Show(DB.pkbnvDB.idNVlast());
            bool kq = BUS.kqBUS.themPKB(pk);
            if (kq == true)
            {
                getDSKQ();
            }
            else
            {
                MessageBoxEx.Show("Thêm phiếu khám thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //xoa nhan vien va xoa phieu
        private void btnXoa_Click(object sender, EventArgs e)
        {

            int idx = dtgPKBNV.CurrentRow.Index;
            if (dtgPKBNV.Rows[idx].Cells[1].Value.ToString() != "")
            {
                int idNV = int.Parse(dtgPKBNV.Rows[idx].Cells[0].Value.ToString());
                int idPKT = int.Parse(dtgPKBNV.Rows[idx].Cells[1].Value.ToString());
                DialogResult result = MessageBox.Show("Xác nhận xóa KQ?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (result == DialogResult.Yes)
                {
                    bool kq;
                    try
                    {
                        kq = BUS.kqBUS.xoaPKTNV(idPKT);
                        if (kq == true)
                        {
                            MessageBoxEx.Show("Đã xóa kết quả!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult resultNV = MessageBox.Show("Xác nhận xóa Nhân Viên?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                            if (resultNV == DialogResult.Yes)
                            {
                                bool kqNV;
                                try
                                {
                                    kqNV = BUS.nhanvienBUS.XoaNhanVien(idNV);
                                    if (kqNV == true)
                                    {
                                        MessageBoxEx.Show("Đã xóa Nhân Viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        getDSKQ();
                                    }
                                    else
                                        MessageBoxEx.Show("Xóa Nhân Viên thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                catch (Exception Ex) { MessageBox.Show(Ex.Message); }
                            }
                            getDSKQ();
                        }
                        else
                        {
                            MessageBoxEx.Show("Xóa kết quả thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DialogResult resultNV = MessageBox.Show("Xác nhận xóa Nhân Viên?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                            if (resultNV == DialogResult.Yes)
                            {
                                bool kqNV;
                                try
                                {
                                    kqNV = BUS.nhanvienBUS.XoaNhanVien(idNV);
                                    if (kq == true)
                                    {
                                        MessageBoxEx.Show("Đã xóa Nhân Viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        getDSKQ();
                                    }
                                    else
                                        MessageBoxEx.Show("Xóa Nhân Viên thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                catch (Exception Ex) { MessageBox.Show(Ex.Message); }

                            }
                        }
                    }
                    catch (Exception Ex) { MessageBox.Show(Ex.Message); }

                }

            }
            else
            {
                MessageBoxEx.Show("Không tìm thấy KQ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                int idNV = int.Parse(dtgPKBNV.Rows[idx].Cells[0].Value.ToString());
                DialogResult resultNV = MessageBox.Show("Xác nhận xóa Nhân Viên?!!!", "Cảnh Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                if (resultNV == DialogResult.Yes)
                {
                    bool kqNV;
                    try
                    {
                        kqNV = BUS.nhanvienBUS.XoaNhanVien(idNV);
                        if (kqNV == true)
                        {
                            MessageBoxEx.Show("Đã xóa Nhân Viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getDSKQ();
                        }
                        else
                            MessageBoxEx.Show("Xóa Nhân Viên thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception Ex) { MessageBox.Show(Ex.Message); }

                }
            };

        }
        //sua nhan vien va sua phieu
        public void suaNhanVien()
        {
            CLASS.nhanvien nv = new CLASS.nhanvien();
            CLASS.kqKTCLS pk = new CLASS.kqKTCLS();

           

            int idx = dtgPKBNV.CurrentRow.Index;
            string idPB = BUS.pbBUS.LayidPBtuTenPB(cbKP.Text);
            nv.idPB = idPB;
            nv.idNV = int.Parse(dtgPKBNV.Rows[idx].Cells[0].Value.ToString());
            nv.chucvu = cbCD.Text;
            nv.tenNV = txtHT.Text;
            nv.gtNV = cbGT.SelectedItem.ToString();
            nv.tuoiNV = int.Parse(txtTuoiNV.Text);
            nv.ngaynhap = dtpNhap.Text;

            pk.chieucao = txtCC.Text;
            pk.cannang = txtCN.Text;
            pk.BMI = txtBMI.Text;
            pk.mach = txtMach.Text;
            pk.huyetAp = txtHA.Text;
            pk.theLuc = txtKL.Text;
            pk.noiK = txtNoi.Text;
            pk.ngoaiK = txtNgoai.Text;
            pk.phuK = txtPhuK.Text;
            pk.mat = txtMat.Text;
            pk.TMH = txtTMH.Text;
            pk.daLieu = txtDL.Text;
            pk.RHM = txtRHM.Text;
            pk.ptTBMau = txtPTTB.Text;
            pk.ptNTieu = txtPTNT.Text;
            pk.duongHuyet = txtDuongH.Text;
            pk.sgot = txtSGOT.Text;
            pk.sgpt = txtSGPT.Text;
            pk.ure = txtUre.Text;
            pk.creatinin = txtCreatinin.Text;
            pk.xQuang = txtXQ.Text;
            pk.sieuAm = txtSieuA.Text;
            pk.plSK = txtPLSK.Text;
            pk.kL = txtKL.Text;
            pk.ghiChu = txtGhiChu.Text;
            pk.idNV = int.Parse(dtgPKBNV.Rows[idx].Cells[0].Value.ToString());

            if (dtgPKBNV.Rows[idx].Cells[1].Value.ToString() == string.Empty)
            {
                try
                {
                    bool kq = BUS.nhanvienBUS.SuaNhanVien(nv);
                    bool kq1 = BUS.kqBUS.themPKBcoIDNV(pk);
                    if (kq == true)
                    {
                        { if (kq1 == true) { getDSKQ(); } else { MessageBoxEx.Show("Thêm phiếu khám thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); } }
                        MessageBoxEx.Show("Sửa đối tượng thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getDSKQ();
                    }
                    else
                    {
                        MessageBoxEx.Show("Sửa đối tượng thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else
            {
                pk.idPKT = int.Parse(dtgPKBNV.Rows[idx].Cells[1].Value.ToString());
                try
                {
                    bool kq = BUS.nhanvienBUS.SuaNhanVien(nv);
                    bool kq1 = BUS.kqBUS.suaPKB(pk);
                    if (kq == true)
                    {
                        { if (kq1 == true) { getDSKQ(); } else { MessageBoxEx.Show("Sửa phiếu khám thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); } }
                        MessageBoxEx.Show("Sửa đối tượng thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getDSKQ();
                    }
                    else
                    {
                        MessageBoxEx.Show("Sửa đối tượng thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
        //goi ham sua nhan vien vao 
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            if (cbKP.SelectedIndex != 0)
            {
                if (cbCD.SelectedIndex != 0)
                {
                    if (txtHT.Text != "")
                    {
                        if (txtHT.Text.Length >= 2 && txtHT.Text.Length <= 20)
                        {

                            suaNhanVien();
                            //suaPKCLS();

                        }
                        else
                        {
                            MessageBoxEx.Show("Họ tên không hợp lệ !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtHT.Focus();
                            btnEdit.Enabled = true;
                        };
                    }
                    else
                    {
                        MessageBoxEx.Show("Họ tên không được để trống !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtHT.Focus();
                        btnEdit.Enabled = true;
                    };
                }
                else
                {
                    MessageBoxEx.Show("Chưa chọn chức vụ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbCD.Focus();
                    btnEdit.Enabled = true;
                };
            }
            else
            {
                MessageBoxEx.Show("Chưa chọn phòng ban!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbKP.Focus();
                btnEdit.Enabled = true;
            };
        }
        //cap nhat lai du lieu
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            getDSKQ();
        }
        //lay du lieu tu datagridview qua form nhap
        private void dtgPKBNV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                btnEdit.Enabled = true;
                int idx = dtgPKBNV.CurrentRow.Index;
                string tenNV = dtgPKBNV.Rows[idx].Cells[2].Value.ToString();
                string gtNV = dtgPKBNV.Rows[idx].Cells[3].Value.ToString();
                string tenPB = dtgPKBNV.Rows[idx].Cells[4].Value.ToString();
                string tuoiNV = dtgPKBNV.Rows[idx].Cells[5].Value.ToString();
                string chucVu = dtgPKBNV.Rows[idx].Cells[6].Value.ToString();
                string kl = dtgPKBNV.Rows[idx].Cells[7].Value.ToString();
                string ghichu = dtgPKBNV.Rows[idx].Cells[8].Value.ToString();
                string chieucao = dtgPKBNV.Rows[idx].Cells[10].Value.ToString();
                string cannang = dtgPKBNV.Rows[idx].Cells[11].Value.ToString();
                string BMI = dtgPKBNV.Rows[idx].Cells[12].Value.ToString();
                string mach = dtgPKBNV.Rows[idx].Cells[13].Value.ToString();
                string huyetAp = dtgPKBNV.Rows[idx].Cells[14].Value.ToString();
                string theLuc = dtgPKBNV.Rows[idx].Cells[15].Value.ToString();
                string noiK = dtgPKBNV.Rows[idx].Cells[16].Value.ToString();
                string ngoaiK = dtgPKBNV.Rows[idx].Cells[17].Value.ToString();
                string phuK = dtgPKBNV.Rows[idx].Cells[18].Value.ToString();
                string mat = dtgPKBNV.Rows[idx].Cells[19].Value.ToString();
                string TMH = dtgPKBNV.Rows[idx].Cells[20].Value.ToString();
                string daLieu = dtgPKBNV.Rows[idx].Cells[21].Value.ToString();
                string RHM = dtgPKBNV.Rows[idx].Cells[22].Value.ToString();
                string ptTBMau = dtgPKBNV.Rows[idx].Cells[23].Value.ToString();
                string ptNTieu = dtgPKBNV.Rows[idx].Cells[24].Value.ToString();
                string duongHuyet = dtgPKBNV.Rows[idx].Cells[25].Value.ToString();
                string sgot = dtgPKBNV.Rows[idx].Cells[26].Value.ToString();
                string sgpt = dtgPKBNV.Rows[idx].Cells[27].Value.ToString();
                string ure = dtgPKBNV.Rows[idx].Cells[28].Value.ToString();
                string creatinin = dtgPKBNV.Rows[idx].Cells[29].Value.ToString();
                string xQuang = dtgPKBNV.Rows[idx].Cells[30].Value.ToString();
                string sieuAm = dtgPKBNV.Rows[idx].Cells[31].Value.ToString();
                string plSK = dtgPKBNV.Rows[idx].Cells[32].Value.ToString();
                if (gtNV == "Nữ")
                {
                    cbGT.SelectedIndex = 0;
                }
                else { cbGT.SelectedIndex = 1; }

                txtHT.Text = tenNV;
                cbKP.Text = tenPB;
                cbCD.Text = chucVu;
                txtTuoiNV.Text = tuoiNV;
                txtKL.Text = kl;
                txtCC.Text = chieucao;
                txtCN.Text = cannang;
                txtBMI.Text = BMI;
                txtTL.Text = theLuc;
                txtMach.Text = mach;
                txtHA.Text = huyetAp;
                txtMat.Text = mat;
                txtTMH.Text = TMH;
                txtRHM.Text = RHM;
                txtDL.Text = daLieu;
                txtNoi.Text = noiK;
                txtNgoai.Text = ngoaiK;
                txtPhuK.Text = phuK;
                txtXQ.Text = xQuang;
                txtSieuA.Text = sieuAm;
                txtPLSK.Text = plSK;
                txtPTTB.Text = ptTBMau;
                txtDuongH.Text = duongHuyet;
                txtPTNT.Text = ptNTieu;
                txtSGOT.Text = sgot;
                txtSGPT.Text = sgpt;
                txtUre.Text = ure;
                txtCreatinin.Text = creatinin;
                txtGhiChu.Text = ghichu;

                tabNhapNV.SelectedIndex = 0;
            } catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        //luu du lieu vao database
        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            if (cbKP.SelectedIndex != 0)
            {
                if (cbCD.SelectedIndex != 0)
                {
                    if (txtHT.Text != "")
                    {
                        if (txtHT.Text.Length >= 2 && txtHT.Text.Length <= 20)
                        {
                            int tuoiNV = int.Parse(txtTuoiNV.Text);
                            int currentYear = int.Parse(DateTime.Now.Year.ToString());
                            if (txtTuoiNV.Text.Length == 4 && tuoiNV >= 1920 && tuoiNV <= currentYear && txtTuoiNV.Text != "")
                            {
                                themNhanVien();
                                themPKCLS();
                            }
                            else
                            {
                                MessageBoxEx.Show("Tuổi không hợp lệ !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtTuoiNV.Focus();
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show("Họ tên không hợp lệ !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtHT.Focus();
                        };
                    }
                    else
                    {
                        MessageBoxEx.Show("Họ tên không được để trống !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtHT.Focus();
                    };
                }
                else
                {
                    MessageBoxEx.Show("Chưa chọn chức vụ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbCD.Focus();
                };
            }
            else
            {
                MessageBoxEx.Show("Chưa chọn phòng ban!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbKP.Focus();
            };
        }
        //print to crytal report
        private void btnPrnt_Click(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("idNV", typeof(Int16));
            dt.Columns.Add("idPKL", typeof(Int16));
            dt.Columns.Add("tenNV", typeof(string));
            dt.Columns.Add("gtNV", typeof(string));
            dt.Columns.Add("tenPB", typeof(string));
            dt.Columns.Add("tuoiNV", typeof(Int16));
            dt.Columns.Add("chucvu", typeof(string));
            dt.Columns.Add("kL", typeof(string));
            dt.Columns.Add("ghichu", typeof(string));
            dt.Columns.Add("ngaynhap", typeof(string));
            dt.Columns.Add("chieucao", typeof(Int16));
            dt.Columns.Add("cannang", typeof(Int16));
            dt.Columns.Add("BMI", typeof(Int16));
            dt.Columns.Add("mach", typeof(string));
            dt.Columns.Add("huyetAp", typeof(string));
            dt.Columns.Add("theLuc", typeof(string));
            dt.Columns.Add("noiK", typeof(string));
            dt.Columns.Add("ngoaiK", typeof(string));
            dt.Columns.Add("phuK", typeof(string));
            dt.Columns.Add("mat", typeof(string));
            dt.Columns.Add("TMH", typeof(string));
            dt.Columns.Add("daLieu", typeof(string));
            dt.Columns.Add("RHM", typeof(string));
            dt.Columns.Add("ptTBMau", typeof(string));
            dt.Columns.Add("ptNTieu", typeof(string));
            dt.Columns.Add("duongHuyet", typeof(string));
            dt.Columns.Add("sgot", typeof(string));
            dt.Columns.Add("sgpt", typeof(string));
            dt.Columns.Add("ure", typeof(string));
            dt.Columns.Add("creatinin", typeof(string));
            dt.Columns.Add("xQuang", typeof(string));
            dt.Columns.Add("sieuAm", typeof(string));
            dt.Columns.Add("plSK", typeof(string));

            //add datagridview data to table
            foreach (DataGridViewRow dgv in dtgPKBNV.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value, dgv.Cells[6].Value,
                    dgv.Cells[7].Value, dgv.Cells[8].Value, dgv.Cells[9].Value, dgv.Cells[10].Value, dgv.Cells[11].Value, dgv.Cells[12].Value, dgv.Cells[13].Value,
                    dgv.Cells[14].Value, dgv.Cells[15].Value, dgv.Cells[16].Value, dgv.Cells[17].Value, dgv.Cells[18].Value, dgv.Cells[19].Value, dgv.Cells[20].Value,
                    dgv.Cells[21].Value, dgv.Cells[22].Value, dgv.Cells[23].Value, dgv.Cells[24].Value, dgv.Cells[25].Value, dgv.Cells[26].Value, dgv.Cells[27].Value, dgv.Cells[28].Value,
                    dgv.Cells[29].Value, dgv.Cells[30].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("NV_PKCLS.xml");

            //transefer data to crystalreportviewer
            report.nv_pkbls cr = new report.nv_pkbls();
            cr.SetDataSource(ds);
            PRINTVIEW.phieuCLS form = new PRINTVIEW.phieuCLS();
            form.crystalReportViewer1.ReportSource = cr;
            form.ShowDialog();

        }
        //copy datagridview to clipboard
        private void copyAlltoClipboard()
        {
            dtgPKBNV.SelectAll();
            DataObject dataObj = dtgPKBNV.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        //export excel
        private void btnExpExcel_Click(object sender, EventArgs e)
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
        //clear content
        private void btnNew_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            cbKP.SelectedIndex = 0;
            cbCD.SelectedIndex = 0;
            cbGT.SelectedIndex = 0;
            txtHT.Text = "";
            cbKP.Text = "";
            cbCD.Text = "";
            txtKL.Text = "";
            txtCC.Text = "";
            txtCN.Text = "";
            txtBMI.Text = "";
            txtTL.Text = "";
            txtMach.Text = "";
            txtHA.Text = "";
            txtMat.Text = "";
            txtTMH.Text = "";
            txtRHM.Text = "";
            txtDL.Text = "";
            txtNoi.Text = "";
            txtNgoai.Text = "";
            txtPhuK.Text = "";
            txtXQ.Text = "";
            txtSieuA.Text = "";
            txtPLSK.Text = "";
            txtPTTB.Text = "";
            txtDuongH.Text = "";
            txtPTNT.Text = "";
            txtSGOT.Text = "";
            txtSGPT.Text = "";
            txtUre.Text = "";
            txtCreatinin.Text = "";
            txtGhiChu.Text = "";
        }
        //get ten khi click len textbox tim kiem
        private void dtgPKBNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgPKBNV.SelectedCells.Count > 0) // make sure user select at least 1 row 
            {
                string tenNV = dtgPKBNV.CurrentRow.Cells[2].Value.ToString();
                txtHTTK.Text = tenNV;
            }
        }
        //tim kiem theo ten
        public void timkiemTENNV()
        {
            string tenNVTK = txtHTTK.Text;
            DataTable _dskqTK = BUS.timkiemBUS.getDSKQ(tenNVTK);
            dtgPKBNV.DataSource = _dskqTK;
        }
        //goi ham tim kiem
        private void btnTimK_Click(object sender, EventArgs e)
        {
            if (txtHTTK.Text != string.Empty)
            {
                try
                {
                    timkiemTENNV();
                }
                catch (Exception ex)
                { MessageBoxEx.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBoxEx.Show("Tìm kiếm thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHTTK.Focus();
            }
        }

        //loc theo ngay
        public void searchByDate()
        {
            string from = dtpFrom.Text;
            string to = dtpTo.Text;
            DataTable _dskqTK = BUS.timkiemBUS.getDSKQbyDate(from, to);
            dtgPKBNV.DataSource = _dskqTK;
        }
        //goi ham loc
        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                searchByDate();
            }
            catch (Exception ex)
            { MessageBoxEx.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        //next pass
        private void txtCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                 (e.KeyChar == '.' && (txtCC.Text.Length == 0 || txtCC.Text.IndexOf('.') != -1))))
                e.Handled = true;

        }

        private void txtCN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                (e.KeyChar == '.' && (txtCN.Text.Length == 0 || txtCN.Text.IndexOf('.') != -1))))
                e.Handled = true;

        }

        private void cbCD_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                if (cbCD.SelectedIndex == 0)
                {
                    errorProvider1.SetError(cbCD, "Chưa chọn chức danh!!");
                    cbCD.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                    this.SelectNextControl((Control)sender, true, true, true, true);
                    txtHT.Focus();
                }
            }

        }

        private void cbKP_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                if (cbKP.SelectedIndex == 0)
                {
                    errorProvider1.SetError(cbKP, "Chưa chọn khoa phòng!!");
                    cbKP.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                    this.SelectNextControl((Control)sender, true, true, true, true);
                    cbCD.Focus();
                }
            }
        }

        private void txtHT_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                if (string.IsNullOrWhiteSpace(txtHT.Text))
                {
                    errorProvider1.SetError(txtHT, "Nhập tên!!");
                    txtHT.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                    this.SelectNextControl((Control)sender, true, true, true, true);
                    cbGT.Focus();
                }

            }
        }

        private void cbGT_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtTuoiNV.Focus();
            }

        }

        private void txtTuoiNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                (e.KeyChar == '.' && (txtCC.Text.Length == 0 || txtCC.Text.IndexOf('.') != -1))))
                e.Handled = true;
           
        }

        private void txtCC_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                if (string.IsNullOrWhiteSpace(txtCC.Text))
                { txtCC.Text = "0"; };
            }

        }

        private void txtCN_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                if (string.IsNullOrWhiteSpace(txtCN.Text))
                {
                    this.SelectNextControl((Control)sender, true, true, true, true);
                    txtCN.Text = "0"; txtBMI.Text = "0";
                    txtCN.Focus();
                }

                else
                {
                    double FirstNumber = Convert.ToDouble(txtCC.Text);
                    double second = Convert.ToDouble(txtCN.Text);
                    this.SelectNextControl((Control)sender, true, true, true, true);
                    double BMI = second / ((FirstNumber / 100) * (FirstNumber / 100));

                    if (BMI < 19 & cbGT.SelectedIndex == 1)
                    { txtTL.Text = "Underweight"; }
                    if (BMI >= 19 & BMI <= 24 & cbGT.SelectedIndex == 1)
                    { txtTL.Text = "Normal"; }
                    if (BMI > 24 & cbGT.SelectedIndex == 1)
                    { txtTL.Text = "Overweight"; }

                    if (BMI < 20 & cbGT.SelectedIndex == 0)
                    { txtTL.Text = "Underweight"; }
                    if (BMI >= 20 & BMI <= 25 & cbGT.SelectedIndex == 0)
                    { txtTL.Text = "Normal"; }
                    if (BMI > 25 & cbGT.SelectedIndex == 0)
                    { txtTL.Text = "Overweight"; }

                    txtBMI.Text = Convert.ToString(BMI);
                    txtMach.Focus();
                }

            }

        }

        private void txtMach_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtHA.Focus();
            }

        }

        private void txtHA_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtMat.Focus();
            }

        }

        private void txtMat_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                if (string.IsNullOrWhiteSpace(txtMat.Text))
                { txtMat.Text = "bt"; }
                this.SelectNextControl((Control)sender, true, true, true, true);

            }

        }

        private void txtTMH_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {

                if (string.IsNullOrWhiteSpace(txtTMH.Text))
                { txtTMH.Text = "bt"; }
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private void txtRHM_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {

                if (string.IsNullOrWhiteSpace(txtRHM.Text))
                { txtRHM.Text = "bt"; }
                this.SelectNextControl((Control)sender, true, true, true, true);

            }

        }

        private void txtDL_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                if (string.IsNullOrWhiteSpace(txtDL.Text))
                { txtDL.Text = "bt"; }
                txtNoi.Focus();
            }

        }

        private void txtNoi_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {

                if (string.IsNullOrWhiteSpace(txtNoi.Text))
                { txtNoi.Text = "bt"; }
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private void txtNgoai_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {

                if (string.IsNullOrWhiteSpace(txtNgoai.Text))
                { txtNgoai.Text = "bt"; }
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private void txtPhuK_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {

                if (string.IsNullOrWhiteSpace(txtPhuK.Text))
                { txtPhuK.Text = "bt"; }
                this.SelectNextControl((Control)sender, true, true, true, true);

            }

        }

        private void txtTuoiNV_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtCC.Focus();
            }

        }

        private void txtXQ_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {

                if (string.IsNullOrWhiteSpace(txtXQ.Text))
                { txtXQ.Text = "bt"; }
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private void txtSieuA_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                if (string.IsNullOrWhiteSpace(txtSieuA.Text))
                { txtSieuA.Text = "bt"; }
                txtPTTB.Focus();
            }

        }

        private void txtPTTB_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private void txtDuongH_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private void txtPTNT_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtSGOT.Focus();
            }

        }

        private void txtSGOT_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtSGPT.Focus();
            }

        }

        private void txtSGPT_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtUre.Focus();
            }

        }

        private void txtUre_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtCreatinin.Focus();
            }

        }

        private void txtCreatinin_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtKL.Focus();
            }

        }

        private void txtKL_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                if (string.IsNullOrWhiteSpace(txtKL.Text))
                { txtKL.Text = "Đủ sức khoẻ"; }
                this.SelectNextControl((Control)sender, true, true, true, true);
                txtGhiChu.Focus();
            }

        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                btnLuu.Focus();
            }

        }

        private void tabPKB_Click(object sender, EventArgs e)
        {

        }

        private void txtBMI_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

