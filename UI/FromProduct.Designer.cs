namespace UI
{
    partial class FromProduct
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
            txtName = new TextBox();
            txtId = new TextBox();
            txtPrice = new TextBox();
            txtCategory = new ComboBox();
            txtStok = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(333, 38);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 0;
            // 
            // txtId
            // 
            txtId.Location = new Point(333, 107);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(333, 176);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 2;
            // 
            // txtCategory
            // 
            txtCategory.FormattingEnabled = true;
            txtCategory.Location = new Point(333, 251);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(125, 28);
            txtCategory.TabIndex = 3;
            txtCategory.SelectedIndexChanged += txtCategory_SelectedIndexChanged;
            // 
            // txtStok
            // 
            txtStok.Location = new Point(333, 324);
            txtStok.Name = "txtStok";
            txtStok.Size = new Size(125, 27);
            txtStok.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(24, 363);
            button1.Name = "button1";
            button1.Size = new Size(125, 39);
            button1.TabIndex = 5;
            button1.Text = "שמור";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(24, 27);
            button2.Name = "button2";
            button2.Size = new Size(125, 38);
            button2.TabIndex = 6;
            button2.Text = "חזרה";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(521, 36);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 7;
            label1.Text = "שם מוצר";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(521, 107);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 8;
            label2.Text = "קוד מוצר";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(545, 179);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 9;
            label3.Text = "מחיר";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(524, 251);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 10;
            label4.Text = "קטגוריה";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(545, 331);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 11;
            label5.Text = "מלאי";
            // 
            // FromProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtStok);
            Controls.Add(txtCategory);
            Controls.Add(txtPrice);
            Controls.Add(txtId);
            Controls.Add(txtName);
            Name = "FromProduct";
            Text = "FormProduct";
            Load += FromProduct_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtId;
        private TextBox txtPrice;
        private ComboBox txtCategory;
        private TextBox txtStok;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}