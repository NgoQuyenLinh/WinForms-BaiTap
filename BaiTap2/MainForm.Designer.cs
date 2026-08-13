namespace BaiTap2
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
            this.gbGioiTinh = new System.Windows.Forms.GroupBox();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.gbMau = new System.Windows.Forms.GroupBox();
            this.btnToMau = new System.Windows.Forms.Button();
            this.rdXanh = new System.Windows.Forms.RadioButton();
            this.rdDo = new System.Windows.Forms.RadioButton();
            this.tbToMau = new System.Windows.Forms.TextBox();
            this.gbGioiTinh.SuspendLayout();
            this.gbMau.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGioiTinh
            // 
            this.gbGioiTinh.Controls.Add(this.rdNu);
            this.gbGioiTinh.Controls.Add(this.rdNam);
            this.gbGioiTinh.Location = new System.Drawing.Point(348, 38);
            this.gbGioiTinh.Name = "gbGioiTinh";
            this.gbGioiTinh.Size = new System.Drawing.Size(200, 100);
            this.gbGioiTinh.TabIndex = 0;
            this.gbGioiTinh.TabStop = false;
            this.gbGioiTinh.Text = "Chọn giới tính";
            // 
            // rdNu
            // 
            this.rdNu.AutoSize = true;
            this.rdNu.Location = new System.Drawing.Point(6, 45);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(39, 17);
            this.rdNu.TabIndex = 1;
            this.rdNu.TabStop = true;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            this.rdNu.CheckedChanged += new System.EventHandler(this.rdNu_CheckedChanged);
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.Checked = true;
            this.rdNam.Location = new System.Drawing.Point(6, 22);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(47, 17);
            this.rdNam.TabIndex = 0;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            this.rdNam.CheckedChanged += new System.EventHandler(this.rdNam_CheckedChanged);
            // 
            // gbMau
            // 
            this.gbMau.Controls.Add(this.btnToMau);
            this.gbMau.Controls.Add(this.rdXanh);
            this.gbMau.Controls.Add(this.rdDo);
            this.gbMau.Location = new System.Drawing.Point(300, 175);
            this.gbMau.Name = "gbMau";
            this.gbMau.Size = new System.Drawing.Size(200, 100);
            this.gbMau.TabIndex = 1;
            this.gbMau.TabStop = false;
            this.gbMau.Text = "Chọn màu";
            // 
            // btnToMau
            // 
            this.btnToMau.Location = new System.Drawing.Point(119, 29);
            this.btnToMau.Name = "btnToMau";
            this.btnToMau.Size = new System.Drawing.Size(75, 23);
            this.btnToMau.TabIndex = 2;
            this.btnToMau.Text = "Tô Màu";
            this.btnToMau.UseVisualStyleBackColor = true;
            this.btnToMau.Click += new System.EventHandler(this.btnToMau_Click);
            // 
            // rdXanh
            // 
            this.rdXanh.AutoSize = true;
            this.rdXanh.Location = new System.Drawing.Point(6, 45);
            this.rdXanh.Name = "rdXanh";
            this.rdXanh.Size = new System.Drawing.Size(74, 17);
            this.rdXanh.TabIndex = 1;
            this.rdXanh.TabStop = true;
            this.rdXanh.Text = "Màu Xanh";
            this.rdXanh.UseVisualStyleBackColor = true;
            // 
            // rdDo
            // 
            this.rdDo.AutoSize = true;
            this.rdDo.Location = new System.Drawing.Point(6, 22);
            this.rdDo.Name = "rdDo";
            this.rdDo.Size = new System.Drawing.Size(63, 17);
            this.rdDo.TabIndex = 0;
            this.rdDo.TabStop = true;
            this.rdDo.Text = "Màu Đỏ";
            this.rdDo.UseVisualStyleBackColor = true;
            // 
            // tbToMau
            // 
            this.tbToMau.Location = new System.Drawing.Point(522, 185);
            this.tbToMau.Multiline = true;
            this.tbToMau.Name = "tbToMau";
            this.tbToMau.Size = new System.Drawing.Size(244, 71);
            this.tbToMau.TabIndex = 2;
            this.tbToMau.TextChanged += new System.EventHandler(this.btnToMau_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbToMau);
            this.Controls.Add(this.gbMau);
            this.Controls.Add(this.gbGioiTinh);
            this.Name = "MainForm";
            this.Text = "Bài tập 2";
            this.gbGioiTinh.ResumeLayout(false);
            this.gbGioiTinh.PerformLayout();
            this.gbMau.ResumeLayout(false);
            this.gbMau.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGioiTinh;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.GroupBox gbMau;
        private System.Windows.Forms.Button btnToMau;
        private System.Windows.Forms.RadioButton rdXanh;
        private System.Windows.Forms.RadioButton rdDo;
        private System.Windows.Forms.TextBox tbToMau;
    }
}

