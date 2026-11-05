namespace Lab_Basic_Command
{
    partial class BillLogForm
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
            this.dgvBills = new System.Windows.Forms.DataGridView();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lbltotalTax = new System.Windows.Forms.Label();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.BillID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Staff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckoutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng hóa đơn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tổng tiền:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng thuế:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tổng giảm giá:";
            // 
            // dgvBills
            // 
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillID,
            this.BillName,
            this.Staff,
            this.TableName,
            this.CheckoutDate,
            this.Amount,
            this.Tax,
            this.Discount,
            this.TotalPay});
            this.dgvBills.Location = new System.Drawing.Point(0, 76);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.Size = new System.Drawing.Size(952, 375);
            this.dgvBills.TabIndex = 4;
            this.dgvBills.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBills_CellContentClick);
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.Location = new System.Drawing.Point(103, 19);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(54, 13);
            this.lblTotalBill.TabIndex = 5;
            this.lblTotalBill.Text = "lblTotalBill";
            // 
            // lblRevenue
            // 
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Location = new System.Drawing.Point(318, 19);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(35, 13);
            this.lblRevenue.TabIndex = 6;
            this.lblRevenue.Text = "label6";
            // 
            // lbltotalTax
            // 
            this.lbltotalTax.AutoSize = true;
            this.lbltotalTax.Location = new System.Drawing.Point(103, 49);
            this.lbltotalTax.Name = "lbltotalTax";
            this.lbltotalTax.Size = new System.Drawing.Size(24, 13);
            this.lbltotalTax.TabIndex = 7;
            this.lbltotalTax.Text = "lblT";
            // 
            // lblTotalDiscount
            // 
            this.lblTotalDiscount.AutoSize = true;
            this.lblTotalDiscount.Location = new System.Drawing.Point(318, 49);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.Size = new System.Drawing.Size(35, 13);
            this.lblTotalDiscount.TabIndex = 8;
            this.lblTotalDiscount.Text = "label8";
            // 
            // BillID
            // 
            this.BillID.DataPropertyName = "ID";
            this.BillID.HeaderText = "Mã hóa đơn";
            this.BillID.Name = "BillID";
            // 
            // BillName
            // 
            this.BillName.DataPropertyName = "BillName";
            this.BillName.HeaderText = "Hóa đơn";
            this.BillName.Name = "BillName";
            // 
            // Staff
            // 
            this.Staff.DataPropertyName = "StaffName";
            this.Staff.HeaderText = "Nhân viên";
            this.Staff.Name = "Staff";
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "TableName";
            this.TableName.HeaderText = "Tên bàn";
            this.TableName.Name = "TableName";
            // 
            // CheckoutDate
            // 
            this.CheckoutDate.DataPropertyName = "CheckoutDate";
            this.CheckoutDate.HeaderText = "Ngày lập";
            this.CheckoutDate.Name = "CheckoutDate";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Tổng tiền";
            this.Amount.Name = "Amount";
            // 
            // Tax
            // 
            this.Tax.DataPropertyName = "TaxAmount";
            this.Tax.HeaderText = "Thuế";
            this.Tax.Name = "Tax";
            // 
            // Discount
            // 
            this.Discount.DataPropertyName = "DiscountAmount";
            this.Discount.HeaderText = "Giảm giá";
            this.Discount.Name = "Discount";
            // 
            // TotalPay
            // 
            this.TotalPay.DataPropertyName = "TotalPay";
            this.TotalPay.HeaderText = "Tổng tiền thanh toán";
            this.TotalPay.Name = "TotalPay";
            // 
            // BillLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 463);
            this.Controls.Add(this.lblTotalDiscount);
            this.Controls.Add(this.lbltotalTax);
            this.Controls.Add(this.lblRevenue);
            this.Controls.Add(this.lblTotalBill);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BillLogForm";
            this.Text = "BillLogForm";
            this.Load += new System.EventHandler(this.BillLogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvBills;
        private System.Windows.Forms.Label lblTotalBill;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lbltotalTax;
        private System.Windows.Forms.Label lblTotalDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Staff;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckoutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPay;
    }
}