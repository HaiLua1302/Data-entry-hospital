
namespace PKBNV
{
    partial class nguoiLD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nguoiLD));
            this.cbDT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgLD = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNam = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLoadDT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLD)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDT
            // 
            this.cbDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDT.FormattingEnabled = true;
            this.cbDT.Location = new System.Drawing.Point(79, 15);
            this.cbDT.Name = "cbDT";
            this.cbDT.Size = new System.Drawing.Size(140, 21);
            this.cbDT.TabIndex = 156;
            this.cbDT.SelectedIndexChanged += new System.EventHandler(this.cbDT_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightCyan;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 155;
            this.label1.Text = "Kiểu ĐT :";
            // 
            // dtgLD
            // 
            this.dtgLD.AllowUserToAddRows = false;
            this.dtgLD.BackgroundColor = System.Drawing.Color.Wheat;
            this.dtgLD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dtgLD.Location = new System.Drawing.Point(13, 42);
            this.dtgLD.MultiSelect = false;
            this.dtgLD.Name = "dtgLD";
            this.dtgLD.ReadOnly = true;
            this.dtgLD.RowHeadersVisible = false;
            this.dtgLD.RowHeadersWidth = 30;
            this.dtgLD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLD.Size = new System.Drawing.Size(415, 187);
            this.dtgLD.TabIndex = 157;
            this.dtgLD.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseLeave);
            this.dtgLD.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgLD_CellMouseMove);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IDLD";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "tongLD";
            this.Column2.HeaderText = "Tổng Số LĐ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "tongLDSX";
            this.Column3.HeaderText = "Số LĐ Trực Tiếp SX";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "tongLDTX";
            this.Column4.HeaderText = "Số LĐ Tiếp Xúc Độc Hại";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "nam";
            this.Column5.HeaderText = "Năm";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 70;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnThem.Location = new System.Drawing.Point(240, 235);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(91, 21);
            this.btnThem.TabIndex = 158;
            this.btnThem.Text = "Thêm/Sửa";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnXoa.Location = new System.Drawing.Point(337, 235);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(91, 21);
            this.btnXoa.TabIndex = 159;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(261, 15);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(37, 20);
            this.txtSL.TabIndex = 161;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightCyan;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(225, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 162;
            this.label2.Text = "SL :";
            // 
            // dtpNam
            // 
            this.dtpNam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNam.Location = new System.Drawing.Point(350, 15);
            this.dtpNam.Name = "dtpNam";
            this.dtpNam.Size = new System.Drawing.Size(78, 20);
            this.dtpNam.TabIndex = 166;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightCyan;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(304, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 167;
            this.label3.Text = "Năm :";
            // 
            // btnLoadDT
            // 
            this.btnLoadDT.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnLoadDT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDT.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnLoadDT.Location = new System.Drawing.Point(12, 235);
            this.btnLoadDT.Name = "btnLoadDT";
            this.btnLoadDT.Size = new System.Drawing.Size(91, 21);
            this.btnLoadDT.TabIndex = 168;
            this.btnLoadDT.Text = "Load Data\r\n";
            this.btnLoadDT.UseVisualStyleBackColor = false;
            this.btnLoadDT.Click += new System.EventHandler(this.btnLoadDT_Click);
            // 
            // nguoiLD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(440, 278);
            this.Controls.Add(this.btnLoadDT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpNam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dtgLD);
            this.Controls.Add(this.cbDT);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "nguoiLD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Dữ Liệu";
            this.Load += new System.EventHandler(this.nguoiLD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgLD;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnLoadDT;
    }
}