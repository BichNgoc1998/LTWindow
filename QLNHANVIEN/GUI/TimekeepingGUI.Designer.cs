﻿
namespace QLNHANVIEN.GUI
{
    partial class TimekeepingGUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMa = new System.Windows.Forms.TextBox();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.dgvTimekeeping = new System.Windows.Forms.DataGridView();
            this.cbTinhtrang = new System.Windows.Forms.ComboBox();
            this.btThem = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.dtNgay = new System.Windows.Forms.Label();
            this.dtNgaychc = new System.Windows.Forms.DateTimePicker();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimekeeping)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHẤM CÔNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã NV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên NV";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tình trạng";
            // 
            // tbMa
            // 
            this.tbMa.Location = new System.Drawing.Point(119, 60);
            this.tbMa.Name = "tbMa";
            this.tbMa.Size = new System.Drawing.Size(200, 20);
            this.tbMa.TabIndex = 4;
            // 
            // tbTen
            // 
            this.tbTen.Location = new System.Drawing.Point(119, 91);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(200, 20);
            this.tbTen.TabIndex = 5;
            // 
            // dgvTimekeeping
            // 
            this.dgvTimekeeping.AllowUserToAddRows = false;
            this.dgvTimekeeping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimekeeping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvTimekeeping.Location = new System.Drawing.Point(57, 192);
            this.dgvTimekeeping.Name = "dgvTimekeeping";
            this.dgvTimekeeping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimekeeping.Size = new System.Drawing.Size(437, 112);
            this.dgvTimekeeping.TabIndex = 6;
            this.dgvTimekeeping.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimekeeping_CellContentClick);
            // 
            // cbTinhtrang
            // 
            this.cbTinhtrang.FormattingEnabled = true;
            this.cbTinhtrang.Location = new System.Drawing.Point(119, 122);
            this.cbTinhtrang.Name = "cbTinhtrang";
            this.cbTinhtrang.Size = new System.Drawing.Size(200, 21);
            this.cbTinhtrang.TabIndex = 7;
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(419, 57);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(75, 23);
            this.btThem.TabIndex = 8;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btSua
            // 
            this.btSua.Location = new System.Drawing.Point(419, 91);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(75, 23);
            this.btSua.TabIndex = 9;
            this.btSua.Text = "Cập nhật";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(419, 123);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(75, 23);
            this.btXoa.TabIndex = 10;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(419, 154);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 11;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // dtNgay
            // 
            this.dtNgay.AutoSize = true;
            this.dtNgay.Location = new System.Drawing.Point(54, 159);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(32, 13);
            this.dtNgay.TabIndex = 12;
            this.dtNgay.Text = "Ngày";
            // 
            // dtNgaychc
            // 
            this.dtNgaychc.Location = new System.Drawing.Point(119, 156);
            this.dtNgaychc.Name = "dtNgaychc";
            this.dtNgaychc.Size = new System.Drawing.Size(200, 20);
            this.dtNgaychc.TabIndex = 13;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã nhân viên";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên nhân viên";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tình trạng";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ngày";
            this.Column4.Name = "Column4";
            // 
            // TimekeepingGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 326);
            this.Controls.Add(this.dtNgaychc);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.cbTinhtrang);
            this.Controls.Add(this.dgvTimekeeping);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.tbMa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TimekeepingGUI";
            this.Text = "TimekeepingGUI";
            this.Load += new System.EventHandler(this.TimekeepingGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimekeeping)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMa;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.DataGridView dgvTimekeeping;
        private System.Windows.Forms.ComboBox cbTinhtrang;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Label dtNgay;
        private System.Windows.Forms.DateTimePicker dtNgaychc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}