
namespace QLNHANVIEN.GUI
{
    partial class Menu
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
            this.btQLNV = new System.Windows.Forms.Button();
            this.btQLCC = new System.Windows.Forms.Button();
            this.btQLCV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENU CHỨC NĂNG";
            // 
            // btQLNV
            // 
            this.btQLNV.Location = new System.Drawing.Point(58, 81);
            this.btQLNV.Name = "btQLNV";
            this.btQLNV.Size = new System.Drawing.Size(126, 38);
            this.btQLNV.TabIndex = 1;
            this.btQLNV.Text = "Quản lý nhân viên";
            this.btQLNV.UseVisualStyleBackColor = true;
            this.btQLNV.Click += new System.EventHandler(this.btQLNV_Click);
            // 
            // btQLCC
            // 
            this.btQLCC.Location = new System.Drawing.Point(207, 81);
            this.btQLCC.Name = "btQLCC";
            this.btQLCC.Size = new System.Drawing.Size(126, 38);
            this.btQLCC.TabIndex = 2;
            this.btQLCC.Text = "Quản lý chấm công";
            this.btQLCC.UseVisualStyleBackColor = true;
            this.btQLCC.Click += new System.EventHandler(this.btQLCC_Click);
            // 
            // btQLCV
            // 
            this.btQLCV.Location = new System.Drawing.Point(358, 79);
            this.btQLCV.Name = "btQLCV";
            this.btQLCV.Size = new System.Drawing.Size(126, 38);
            this.btQLCV.TabIndex = 3;
            this.btQLCV.Text = "Thông tin công việc";
            this.btQLCV.UseVisualStyleBackColor = true;
            this.btQLCV.Click += new System.EventHandler(this.btQLCV_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 196);
            this.Controls.Add(this.btQLCV);
            this.Controls.Add(this.btQLCC);
            this.Controls.Add(this.btQLNV);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btQLNV;
        private System.Windows.Forms.Button btQLCC;
        private System.Windows.Forms.Button btQLCV;
    }
}