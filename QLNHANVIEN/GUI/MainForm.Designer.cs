
namespace QLNHANVIEN.GUI
{
    partial class MainForm
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
            this.gbNhanvien = new System.Windows.Forms.GroupBox();
            this.btExit_1 = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btNew = new System.Windows.Forms.Button();
            this.btFile = new System.Windows.Forms.Button();
            this.cbPhong = new System.Windows.Forms.ComboBox();
            this.cbBang = new System.Windows.Forms.ComboBox();
            this.dtNgcap = new System.Windows.Forms.DateTimePicker();
            this.dtNgsinh = new System.Windows.Forms.DateTimePicker();
            this.gbGioitinh = new System.Windows.Forms.GroupBox();
            this.cbFemale = new System.Windows.Forms.RadioButton();
            this.cbMale = new System.Windows.Forms.RadioButton();
            this.tbSdt = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbDiachi = new System.Windows.Forms.TextBox();
            this.tbCccd = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.gbNhanvien.SuspendLayout();
            this.gbGioitinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // gbNhanvien
            // 
            this.gbNhanvien.Controls.Add(this.btExit_1);
            this.gbNhanvien.Controls.Add(this.btDelete);
            this.gbNhanvien.Controls.Add(this.btEdit);
            this.gbNhanvien.Controls.Add(this.btNew);
            this.gbNhanvien.Controls.Add(this.btFile);
            this.gbNhanvien.Controls.Add(this.cbPhong);
            this.gbNhanvien.Controls.Add(this.cbBang);
            this.gbNhanvien.Controls.Add(this.dtNgcap);
            this.gbNhanvien.Controls.Add(this.dtNgsinh);
            this.gbNhanvien.Controls.Add(this.gbGioitinh);
            this.gbNhanvien.Controls.Add(this.tbSdt);
            this.gbNhanvien.Controls.Add(this.tbEmail);
            this.gbNhanvien.Controls.Add(this.tbDiachi);
            this.gbNhanvien.Controls.Add(this.tbCccd);
            this.gbNhanvien.Controls.Add(this.tbName);
            this.gbNhanvien.Controls.Add(this.tbId);
            this.gbNhanvien.Controls.Add(this.label11);
            this.gbNhanvien.Controls.Add(this.label10);
            this.gbNhanvien.Controls.Add(this.label9);
            this.gbNhanvien.Controls.Add(this.label8);
            this.gbNhanvien.Controls.Add(this.label7);
            this.gbNhanvien.Controls.Add(this.label6);
            this.gbNhanvien.Controls.Add(this.label5);
            this.gbNhanvien.Controls.Add(this.label4);
            this.gbNhanvien.Controls.Add(this.label3);
            this.gbNhanvien.Controls.Add(this.label2);
            this.gbNhanvien.Controls.Add(this.label1);
            this.gbNhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNhanvien.Location = new System.Drawing.Point(34, 23);
            this.gbNhanvien.Name = "gbNhanvien";
            this.gbNhanvien.Size = new System.Drawing.Size(524, 372);
            this.gbNhanvien.TabIndex = 2;
            this.gbNhanvien.TabStop = false;
            this.gbNhanvien.Text = "THÔNG TIN NHÂN VIÊN";
            // 
            // btExit_1
            // 
            this.btExit_1.Location = new System.Drawing.Point(425, 343);
            this.btExit_1.Name = "btExit_1";
            this.btExit_1.Size = new System.Drawing.Size(75, 23);
            this.btExit_1.TabIndex = 27;
            this.btExit_1.Text = "Thoát";
            this.btExit_1.UseVisualStyleBackColor = true;
            this.btExit_1.Click += new System.EventHandler(this.btExit_1_Click);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(311, 343);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 26;
            this.btDelete.Text = "Xóa";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btEdit
            // 
            this.btEdit.Location = new System.Drawing.Point(203, 343);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(75, 23);
            this.btEdit.TabIndex = 25;
            this.btEdit.Text = "Sửa";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btNew
            // 
            this.btNew.Location = new System.Drawing.Point(98, 343);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(75, 23);
            this.btNew.TabIndex = 24;
            this.btNew.Text = "Thêm";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // btFile
            // 
            this.btFile.Location = new System.Drawing.Point(379, 171);
            this.btFile.Name = "btFile";
            this.btFile.Size = new System.Drawing.Size(79, 21);
            this.btFile.TabIndex = 23;
            this.btFile.Text = "Chọn hình";
            this.btFile.UseVisualStyleBackColor = true;
            this.btFile.Click += new System.EventHandler(this.btFile_Click);
            // 
            // cbPhong
            // 
            this.cbPhong.FormattingEnabled = true;
            this.cbPhong.Location = new System.Drawing.Point(98, 302);
            this.cbPhong.Name = "cbPhong";
            this.cbPhong.Size = new System.Drawing.Size(198, 21);
            this.cbPhong.TabIndex = 21;
            // 
            // cbBang
            // 
            this.cbBang.FormattingEnabled = true;
            this.cbBang.Location = new System.Drawing.Point(98, 275);
            this.cbBang.Name = "cbBang";
            this.cbBang.Size = new System.Drawing.Size(198, 21);
            this.cbBang.TabIndex = 20;
            // 
            // dtNgcap
            // 
            this.dtNgcap.Location = new System.Drawing.Point(98, 138);
            this.dtNgcap.Name = "dtNgcap";
            this.dtNgcap.Size = new System.Drawing.Size(198, 20);
            this.dtNgcap.TabIndex = 19;
            // 
            // dtNgsinh
            // 
            this.dtNgsinh.Location = new System.Drawing.Point(98, 80);
            this.dtNgsinh.Name = "dtNgsinh";
            this.dtNgsinh.Size = new System.Drawing.Size(198, 20);
            this.dtNgsinh.TabIndex = 18;
            // 
            // gbGioitinh
            // 
            this.gbGioitinh.Controls.Add(this.cbFemale);
            this.gbGioitinh.Controls.Add(this.cbMale);
            this.gbGioitinh.Location = new System.Drawing.Point(98, 162);
            this.gbGioitinh.Name = "gbGioitinh";
            this.gbGioitinh.Size = new System.Drawing.Size(198, 23);
            this.gbGioitinh.TabIndex = 17;
            this.gbGioitinh.TabStop = false;
            // 
            // cbFemale
            // 
            this.cbFemale.AutoSize = true;
            this.cbFemale.Location = new System.Drawing.Point(94, 6);
            this.cbFemale.Name = "cbFemale";
            this.cbFemale.Size = new System.Drawing.Size(39, 17);
            this.cbFemale.TabIndex = 1;
            this.cbFemale.TabStop = true;
            this.cbFemale.Text = "Nữ";
            this.cbFemale.UseVisualStyleBackColor = true;
            // 
            // cbMale
            // 
            this.cbMale.AutoSize = true;
            this.cbMale.Location = new System.Drawing.Point(0, 6);
            this.cbMale.Name = "cbMale";
            this.cbMale.Size = new System.Drawing.Size(47, 17);
            this.cbMale.TabIndex = 0;
            this.cbMale.TabStop = true;
            this.cbMale.Text = "Nam";
            this.cbMale.UseVisualStyleBackColor = true;
            // 
            // tbSdt
            // 
            this.tbSdt.Location = new System.Drawing.Point(98, 246);
            this.tbSdt.Name = "tbSdt";
            this.tbSdt.Size = new System.Drawing.Size(198, 20);
            this.tbSdt.TabIndex = 16;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(98, 219);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(198, 20);
            this.tbEmail.TabIndex = 15;
            // 
            // tbDiachi
            // 
            this.tbDiachi.Location = new System.Drawing.Point(98, 193);
            this.tbDiachi.Name = "tbDiachi";
            this.tbDiachi.Size = new System.Drawing.Size(198, 20);
            this.tbDiachi.TabIndex = 14;
            // 
            // tbCccd
            // 
            this.tbCccd.Location = new System.Drawing.Point(98, 109);
            this.tbCccd.Name = "tbCccd";
            this.tbCccd.Size = new System.Drawing.Size(198, 20);
            this.tbCccd.TabIndex = 13;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(98, 52);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(198, 20);
            this.tbName.TabIndex = 12;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(98, 24);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(198, 20);
            this.tbId.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 302);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Phòng ban";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Bằng cấp";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Số điện thoại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Địa chỉ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Giới tính";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày cấp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "CCCD/CMND";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ và tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nhân viên";
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column4,
            this.Column12,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dgvEmployee.Location = new System.Drawing.Point(12, 413);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployee.Size = new System.Drawing.Size(1142, 119);
            this.dgvEmployee.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã nhân viên";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Họ và tên";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ngày sinh";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "CCCD/CMND";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Ngày cấp";
            this.Column6.Name = "Column6";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Giới tính";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Hình ảnh";
            this.Column12.Name = "Column12";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Địa chỉ";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Email";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Số điện thoại";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Bằng cấp";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Phòng ban";
            this.Column11.Name = "Column11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(566, 342);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 538);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvEmployee);
            this.Controls.Add(this.gbNhanvien);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbNhanvien.ResumeLayout(false);
            this.gbNhanvien.PerformLayout();
            this.gbGioitinh.ResumeLayout(false);
            this.gbGioitinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNhanvien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtNgcap;
        private System.Windows.Forms.DateTimePicker dtNgsinh;
        private System.Windows.Forms.GroupBox gbGioitinh;
        private System.Windows.Forms.RadioButton cbFemale;
        private System.Windows.Forms.RadioButton cbMale;
        private System.Windows.Forms.TextBox tbSdt;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbDiachi;
        private System.Windows.Forms.TextBox tbCccd;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btExit_1;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.Button btFile;
        private System.Windows.Forms.ComboBox cbPhong;
        private System.Windows.Forms.ComboBox cbBang;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Label label12;
    }
}