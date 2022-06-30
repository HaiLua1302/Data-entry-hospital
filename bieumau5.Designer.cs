
namespace PKBNV
{
    partial class bieumau5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bieumau5));
            this.dtgBM = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpTimeRec = new System.Windows.Forms.DateTimePicker();
            this.btnExcel = new System.Windows.Forms.Button();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbTenBenh = new System.Windows.Forms.ComboBox();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtmaBenh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnMoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenBN = new System.Windows.Forms.TextBox();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbGT = new System.Windows.Forms.ComboBox();
            this.txtTuoiNghe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKhuVuc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTinhTrang = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhuongPhap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLuuY = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.cbKieuIn = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBM)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgBM
            // 
            this.dtgBM.AllowUserToAddRows = false;
            this.dtgBM.BackgroundColor = System.Drawing.Color.Wheat;
            this.dtgBM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dtgBM.Location = new System.Drawing.Point(22, 113);
            this.dtgBM.Name = "dtgBM";
            this.dtgBM.RowHeadersWidth = 30;
            this.dtgBM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBM.Size = new System.Drawing.Size(937, 335);
            this.dtgBM.TabIndex = 118;
            this.dtgBM.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBM_CellDoubleClick);
            this.dtgBM.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBM_CellMouseLeave);
            this.dtgBM.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgBM_CellMouseMove);
            this.dtgBM.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgBM_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IDBN";
            this.Column1.HeaderText = "idBN";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "tenBN";
            this.Column2.HeaderText = "Tên BN";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "tuoi";
            this.Column3.HeaderText = "Tuổi";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 40;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "gioitinh";
            this.Column4.HeaderText = "GT";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "tuoinghe";
            this.Column5.HeaderText = "Tuổi Nghề";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 50;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "tenBenh";
            this.Column6.HeaderText = "Tên bệnh";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "tinhTrang";
            this.Column7.HeaderText = "Tình trạng";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "phuongPhap";
            this.Column8.HeaderText = "Phương Pháp";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "khuvuc";
            this.Column9.HeaderText = "Khu vực";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 90;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "luuY";
            this.Column10.HeaderText = "Lưu Ý";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 80;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "timeRec";
            this.Column11.HeaderText = "timeRec";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // dtpTimeRec
            // 
            this.dtpTimeRec.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTimeRec.Location = new System.Drawing.Point(863, 34);
            this.dtpTimeRec.Name = "dtpTimeRec";
            this.dtpTimeRec.Size = new System.Drawing.Size(96, 20);
            this.dtpTimeRec.TabIndex = 116;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnExcel.Location = new System.Drawing.Point(856, 455);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(100, 23);
            this.btnExcel.TabIndex = 110;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "T12";
            this.Column19.HeaderText = "T12";
            this.Column19.Name = "Column19";
            this.Column19.Width = 40;
            // 
            // cbTenBenh
            // 
            this.cbTenBenh.FormattingEnabled = true;
            this.cbTenBenh.Location = new System.Drawing.Point(147, 34);
            this.cbTenBenh.Name = "cbTenBenh";
            this.cbTenBenh.Size = new System.Drawing.Size(233, 21);
            this.cbTenBenh.TabIndex = 117;
            this.cbTenBenh.SelectedIndexChanged += new System.EventHandler(this.cbTenBenh_SelectedIndexChanged);
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "tongNam";
            this.Column16.HeaderText = "Tổng";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 50;
            // 
            // groupPanel1
            // 
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(-5, 0);
            this.groupPanel1.Name = "groupPanel1";
            // 
            // 
            // 
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "timeRec";
            this.Column18.HeaderText = "timeRec";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            // 
            // txtmaBenh
            // 
            this.txtmaBenh.Enabled = false;
            this.txtmaBenh.Location = new System.Drawing.Point(96, 34);
            this.txtmaBenh.Name = "txtmaBenh";
            this.txtmaBenh.Size = new System.Drawing.Size(45, 20);
            this.txtmaBenh.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightCyan;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 114;
            this.label2.Text = "Loại Bệnh :";
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnIn.Location = new System.Drawing.Point(198, 455);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(100, 23);
            this.btnIn.TabIndex = 111;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnSua.Enabled = false;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSua.Location = new System.Drawing.Point(737, 455);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 23);
            this.btnSua.TabIndex = 108;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "nam";
            this.Column17.HeaderText = "Năm";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 50;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnXoa.Location = new System.Drawing.Point(616, 455);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 23);
            this.btnXoa.TabIndex = 109;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnThem.Location = new System.Drawing.Point(868, 86);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(91, 21);
            this.btnThem.TabIndex = 107;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnFilter.Location = new System.Drawing.Point(156, 86);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(91, 21);
            this.btnFilter.TabIndex = 113;
            this.btnFilter.Text = "Tìm";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnMoi
            // 
            this.btnMoi.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoi.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnMoi.Location = new System.Drawing.Point(491, 455);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(100, 23);
            this.btnMoi.TabIndex = 112;
            this.btnMoi.Text = "Mới";
            this.btnMoi.UseVisualStyleBackColor = false;
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightCyan;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 119;
            this.label1.Text = "Tên BN :";
            // 
            // txtTenBN
            // 
            this.txtTenBN.Location = new System.Drawing.Point(97, 6);
            this.txtTenBN.Name = "txtTenBN";
            this.txtTenBN.Size = new System.Drawing.Size(208, 20);
            this.txtTenBN.TabIndex = 120;
            // 
            // txtTuoi
            // 
            this.txtTuoi.Location = new System.Drawing.Point(471, 6);
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.Size = new System.Drawing.Size(55, 20);
            this.txtTuoi.TabIndex = 122;
            this.txtTuoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTuoi_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightCyan;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(393, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 121;
            this.label3.Text = "Năm Sinh :";
            // 
            // cbGT
            // 
            this.cbGT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGT.FormattingEnabled = true;
            this.cbGT.Location = new System.Drawing.Point(311, 6);
            this.cbGT.Name = "cbGT";
            this.cbGT.Size = new System.Drawing.Size(69, 21);
            this.cbGT.TabIndex = 123;
            // 
            // txtTuoiNghe
            // 
            this.txtTuoiNghe.Location = new System.Drawing.Point(471, 34);
            this.txtTuoiNghe.Name = "txtTuoiNghe";
            this.txtTuoiNghe.Size = new System.Drawing.Size(55, 20);
            this.txtTuoiNghe.TabIndex = 125;
            this.txtTuoiNghe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTuoiNghe_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightCyan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(393, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 124;
            this.label4.Text = "Tuổi Nghề :";
            // 
            // txtKhuVuc
            // 
            this.txtKhuVuc.Location = new System.Drawing.Point(607, 6);
            this.txtKhuVuc.Name = "txtKhuVuc";
            this.txtKhuVuc.Size = new System.Drawing.Size(352, 20);
            this.txtKhuVuc.TabIndex = 127;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightCyan;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(529, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 126;
            this.label5.Text = "Khu vực :";
            // 
            // cbTinhTrang
            // 
            this.cbTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTinhTrang.FormattingEnabled = true;
            this.cbTinhTrang.Location = new System.Drawing.Point(607, 34);
            this.cbTinhTrang.Name = "cbTinhTrang";
            this.cbTinhTrang.Size = new System.Drawing.Size(128, 21);
            this.cbTinhTrang.TabIndex = 128;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightCyan;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(529, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 129;
            this.label6.Text = "Tình Trạng :";
            // 
            // txtPhuongPhap
            // 
            this.txtPhuongPhap.Location = new System.Drawing.Point(96, 60);
            this.txtPhuongPhap.Name = "txtPhuongPhap";
            this.txtPhuongPhap.Size = new System.Drawing.Size(430, 20);
            this.txtPhuongPhap.TabIndex = 131;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightCyan;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(6, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 130;
            this.label7.Text = "Phương Pháp ;";
            // 
            // txtLuuY
            // 
            this.txtLuuY.Location = new System.Drawing.Point(607, 60);
            this.txtLuuY.Name = "txtLuuY";
            this.txtLuuY.Size = new System.Drawing.Size(352, 20);
            this.txtLuuY.TabIndex = 133;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightCyan;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(529, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 132;
            this.label8.Text = "Lưu Ý :";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(752, 34);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(96, 20);
            this.dtpFrom.TabIndex = 134;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightCyan;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(850, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 135;
            this.label9.Text = "-";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(22, 86);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(128, 21);
            this.cbFilter.TabIndex = 136;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // cbKieuIn
            // 
            this.cbKieuIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKieuIn.FormattingEnabled = true;
            this.cbKieuIn.Location = new System.Drawing.Point(22, 456);
            this.cbKieuIn.Name = "cbKieuIn";
            this.cbKieuIn.Size = new System.Drawing.Size(170, 21);
            this.cbKieuIn.TabIndex = 137;
            // 
            // bieumau5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(968, 486);
            this.Controls.Add(this.cbKieuIn);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.txtLuuY);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPhuongPhap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbTinhTrang);
            this.Controls.Add(this.txtKhuVuc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTuoiNghe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbGT);
            this.Controls.Add(this.txtTuoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTenBN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgBM);
            this.Controls.Add(this.dtpTimeRec);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.cbTenBenh);
            this.Controls.Add(this.txtmaBenh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnMoi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "bieumau5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ BỆNH MÃN TÍNH";
            this.Load += new System.EventHandler(this.bieumau5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgBM;
        private System.Windows.Forms.DateTimePicker dtpTimeRec;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.ComboBox cbTenBenh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.TextBox txtmaBenh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenBN;
        private System.Windows.Forms.TextBox txtTuoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbGT;
        private System.Windows.Forms.TextBox txtTuoiNghe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKhuVuc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTinhTrang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhuongPhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLuuY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.ComboBox cbKieuIn;
    }
}