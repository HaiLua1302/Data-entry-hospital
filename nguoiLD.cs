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
    public partial class nguoiLD : Form
    {
        public nguoiLD()
        {
            InitializeComponent();
        }
        private void nguoiLD_Load(object sender, EventArgs e)
        {
            insert_dt_combobox();
            format_time();
            getdata_SQL();
            hint();
            dtgLD.DefaultCellStyle.ForeColor = Color.Blue;

        }
        // display hint
        public void hint()
        {
            System.Windows.Forms.ToolTip tool = new System.Windows.Forms.ToolTip();
            tool.SetToolTip(btnLoadDT, "Chọn dữ liệu để người lao động để load biểu mẫu");
            int idx = cbDT.SelectedIndex;
            switch(idx)
            {
                case 0:
                    tool.SetToolTip(cbDT, "Tổng Số Người LĐ");
                    break;
                case 1:
                    tool.SetToolTip(cbDT, "Tổng Số Người Trực Tiếp SX");
                    break;
                case 2:
                    tool.SetToolTip(cbDT, "Tổng Số Người Tiếp Xúc Yếu Tố Có Hại");
                    break;
            }
            
        }
        //insert data combobox 
        public void insert_dt_combobox()
        {
            cbDT.Items.Add("Tổng Số Người LĐ");
            cbDT.Items.Add("Tổng Số Người Trực Tiếp SX");
            cbDT.Items.Add("Tổng Số Người Tiếp Xúc Yếu Tố Có Hại");
            cbDT.SelectedIndex = 0;
        }
        //format time
        public void format_time()
        {
            dtpNam.Format = DateTimePickerFormat.Custom;
            dtpNam.CustomFormat = "yyyy";
            dtpNam.ShowUpDown = true;
            dtpNam.Value = DateTime.Now;
        }
        //efect
        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgLD.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dtgLD.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }

        private void dtgLD_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dtgLD.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                dtgLD.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
        //get data sql
        public void getdata_SQL()
        {
            DataTable _dskq = BUS.nguoiLDBUS.getDSKQ_SQL();
            dtgLD.DataSource = _dskq;
        }
        //get data sql duplicate
        public void getdata_SQL_dup()
        {
            DataTable _dskq = BUS.nguoiLDBUS.getDSKQ_SQL_duplicate(int.Parse(dtpNam.Text));
            dtgLD.DataSource = _dskq;
        }

        //tao ham xu ly
        //insert data
        public void insert_DATA()
        {
            CLASS.nguoiLD LD = new CLASS.nguoiLD();
            LD.nam = int.Parse(dtpNam.Text);
            int choice = cbDT.SelectedIndex; ;
            switch(choice)
            {
                case 1:
                    LD.tongLDSX = int.Parse(txtSL.Text);
                    LD.tongLDTX = 0;
                    LD.tongLD = 0;
                    break;
                case 2:
                    LD.tongLDTX = int.Parse(txtSL.Text);
                    LD.tongLDSX = 0;
                    LD.tongLD = 0;
                    break;
                default:
                    LD.tongLD = int.Parse(txtSL.Text);
                    LD.tongLDSX = 0;
                    LD.tongLDTX = 0;
                    break;
            }
            bool kq = BUS.nguoiLDBUS.ThemLD(LD);
            if(kq == true)
            {
                getdata_SQL();
            }
            
        }
        //update data
        public void update_DATA_Duplicate()
        {
            CLASS.nguoiLD LD = new CLASS.nguoiLD();
            LD.nam = int.Parse(dtpNam.Text);
            int choice = cbDT.SelectedIndex;
            string cmt = "";
            switch (choice)
            {
                case 1:
                    cmt = "tongLDSX = " + txtSL.Text + " where nam = " + LD.nam;
                    break;
                case 2:
                    cmt = "tongLDTX = " + txtSL.Text + " where nam = " + LD.nam;
                    break;
                default:
                    cmt = "tongLD = " + txtSL.Text + " where nam = " + LD.nam;
                    break;
            }
            bool kq = BUS.nguoiLDBUS.SuaLD_duplicate(cmt);
            if (kq == true)
            {
                getdata_SQL();
            }

        }
        //delete data
        public void detele_DATA()
        {
            CLASS.nguoiLD LD = new CLASS.nguoiLD();
            LD.idLD = int.Parse(dtgLD.CurrentRow.Cells[0].Value.ToString());
            bool kqLD = BUS.nguoiLDBUS.XoaLD(LD.idLD);
            bool kqBM = BUS.nguoiLDBUS.XoaBM4_LD(LD.idLD);
            if(kqLD == true)
            {
                int check = BUS.timkiemBUS.checkDuplicate_delete(LD.idLD);
                if(check == 0)
                {
                    if (kqBM == true)
                    {
                        getdata_SQL();
                    }
                }
                getdata_SQL();

            }
        }
        //xu ly su kien
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtSL.Text != string.Empty)
            {
                int check = BUS.timkiemBUS.checkDuplicate_LD(int.Parse(dtpNam.Text));
                if(check > 0)
                {
                    DialogResult result = MessageBoxEx.Show("Sửa dữ liệu này sẽ làm ảnh hưởng \nđến thông tin biểu mẫu 4", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if(result == DialogResult.Yes)
                    {
                        try
                        {
                            update_DATA_Duplicate();
                        }
                        catch (Exception ex) { MessageBoxEx.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }          
                   
                }
                else {
                    try
                    {
                        insert_DATA();
                    }
                    catch (Exception ex) { MessageBoxEx.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                   }
            }else
            {
                MessageBoxEx.Show("Số lượng không hợp lệ !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSL.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBoxEx.Show("Xoá dữ liệu người lao động này \nBiểu mẫu liên quan sẽ xoá theo !!!", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes )
            {
                detele_DATA();
            }
        }

        private void btnLoadDT_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            bieumau4 bm = new bieumau4();
            bm.txtIdDATA.Text = dtgLD.CurrentRow.Cells[0].Value.ToString();
            bm.ShowDialog();
           
        }

        private void cbDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tool = new System.Windows.Forms.ToolTip();
            int idx = cbDT.SelectedIndex;
            switch (idx)
            {
                case 0:
                    tool.SetToolTip(cbDT, "Tổng Số Người LĐ");
                    break;
                case 1:
                    tool.SetToolTip(cbDT, "Tổng Số Người Trực Tiếp SX");
                    break;
                case 2:
                    tool.SetToolTip(cbDT, "Tổng Số Người Tiếp Xúc Yếu Tố Có Hại");
                    break;
            }
        }
    }
}
