namespace UI
{
    partial class FromCustemer
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
            txtId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(306, 66);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 0;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(453, 66);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 1;
            label1.Text = "תעודת זהות";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(506, 133);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 2;
            label2.Text = "שם";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(486, 203);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 3;
            label3.Text = "כתובת";
            // 
            // txtName
            // 
            txtName.Location = new Point(306, 130);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 4;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(306, 200);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 27);
            txtAddress.TabIndex = 5;
            txtAddress.TextChanged += txtAddress_TextChanged;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(306, 276);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 6;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(484, 279);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 8;
            label4.Text = "פלאפון";
            // 
            // button1
            // 
            button1.Location = new Point(359, 348);
            button1.Name = "button1";
            button1.Size = new Size(137, 46);
            button1.TabIndex = 9;
            button1.Text = "שמירה";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FromCustemer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(txtPhone);
            Controls.Add(txtAddress);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtId);
            Name = "FromCustemer";
            Text = "FromCustemer";
            Load += FromCustemer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private Label label4;
        private Button button1;
    }
}