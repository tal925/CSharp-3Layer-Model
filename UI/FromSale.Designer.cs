namespace UI
{
    partial class FromSale
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
            label2 = new Label();
            txtMinProduct = new TextBox();
            txtDiscount = new Label();
            dtpStartDate = new DateTimePicker();
            dtpStar = new Label();
            label3 = new Label();
            dtpEndDate = new DateTimePicker();
            btnSaveSale = new Button();
            btnCancel = new Button();
            chkIfEveryOne = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            txtSumPrice = new TextBox();
            cmbProducts = new ComboBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(427, 121);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 2;
            label2.Text = "קוד מוצר";
            // 
            // txtMinProduct
            // 
            txtMinProduct.Location = new Point(252, 163);
            txtMinProduct.MaxLength = 2;
            txtMinProduct.Name = "txtMinProduct";
            txtMinProduct.Size = new Size(125, 27);
            txtMinProduct.TabIndex = 4;
            // 
            // txtDiscount
            // 
            txtDiscount.AutoSize = true;
            txtDiscount.Location = new Point(427, 170);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(94, 20);
            txtDiscount.TabIndex = 5;
            txtDiscount.Text = "כמות מינימום";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(127, 289);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(250, 27);
            dtpStartDate.TabIndex = 6;
            // 
            // dtpStar
            // 
            dtpStar.AutoSize = true;
            dtpStar.Location = new Point(406, 289);
            dtpStar.Name = "dtpStar";
            dtpStar.Size = new Size(103, 20);
            dtpStar.TabIndex = 7;
            dtpStar.Text = "תאריך התחלה";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(427, 337);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 8;
            label3.Text = "תאריך סיום";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(127, 337);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(250, 27);
            dtpEndDate.TabIndex = 9;
            // 
            // btnSaveSale
            // 
            btnSaveSale.Location = new Point(163, 389);
            btnSaveSale.Name = "btnSaveSale";
            btnSaveSale.Size = new Size(94, 29);
            btnSaveSale.TabIndex = 12;
            btnSaveSale.Text = "שמור";
            btnSaveSale.UseVisualStyleBackColor = true;
            btnSaveSale.Click += btnSaveSale_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(52, 389);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "ביטול";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // chkIfEveryOne
            // 
            chkIfEveryOne.AutoSize = true;
            chkIfEveryOne.Location = new Point(368, 215);
            chkIfEveryOne.Name = "chkIfEveryOne";
            chkIfEveryOne.Size = new Size(153, 24);
            chkIfEveryOne.TabIndex = 14;
            chkIfEveryOne.Text = "האם ההנחה לכולם";
            chkIfEveryOne.UseVisualStyleBackColor = true;
            chkIfEveryOne.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(547, 46);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(427, 253);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 16;
            label4.Text = "מחיר מבצע";
            // 
            // txtSumPrice
            // 
            txtSumPrice.Location = new Point(252, 253);
            txtSumPrice.Name = "txtSumPrice";
            txtSumPrice.Size = new Size(125, 27);
            txtSumPrice.TabIndex = 17;
            // 
            // cmbProducts
            // 
            cmbProducts.FormattingEnabled = true;
            cmbProducts.Location = new Point(226, 121);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(151, 28);
            cmbProducts.TabIndex = 18;
            cmbProducts.SelectedIndexChanged += cmbProducts_SelectedIndexChanged;
            // 
            // FromSale
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbProducts);
            Controls.Add(txtSumPrice);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(chkIfEveryOne);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveSale);
            Controls.Add(dtpEndDate);
            Controls.Add(label3);
            Controls.Add(dtpStar);
            Controls.Add(dtpStartDate);
            Controls.Add(txtDiscount);
            Controls.Add(txtMinProduct);
            Controls.Add(label2);
            Name = "FromSale";
            Text = "FromSale";
            Load += FromSale_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtMinProduct;
        private Label txtDiscount;
        private DateTimePicker dtpStartDate;
        private Label dtpStar;
        private Label label3;
        private DateTimePicker dtpEndDate;
        private Button btnSaveSale;
        private Button btnCancel;
        private CheckBox chkIfEveryOne;
        private Label label5;
        private Label label4;
        private TextBox txtSumPrice;
        private ComboBox cmbProducts;
    }
}