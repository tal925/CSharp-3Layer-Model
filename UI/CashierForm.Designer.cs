namespace UI
{
    partial class CashierForm
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
            txtProductCode = new TextBox();
            btnAdd = new Button();
            dgvOrder = new DataGridView();
            lblTotal = new Label();
            btnFinish = new Button();
            label1 = new Label();
            label2 = new Label();
            txtQuantity = new TextBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrder).BeginInit();
            SuspendLayout();
            // 
            // txtProductCode
            // 
            txtProductCode.Location = new Point(582, 35);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(125, 27);
            txtProductCode.TabIndex = 0;
            txtProductCode.TextChanged += txtProductCode_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(575, 132);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(206, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "הוסף להזמנה";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvOrder
            // 
            dgvOrder.BackgroundColor = SystemColors.ControlLightLight;
            dgvOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrder.Location = new Point(2, 12);
            dgvOrder.Name = "dgvOrder";
            dgvOrder.RowHeadersWidth = 51;
            dgvOrder.RowTemplate.Height = 29;
            dgvOrder.Size = new Size(545, 386);
            dgvOrder.TabIndex = 2;
            dgvOrder.CellContentClick += dgvOrder_CellContentClick;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(608, 189);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(142, 20);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "להצגת הסכום הכולל";
            lblTotal.Click += lblTotal_Click;
            // 
            // btnFinish
            // 
            btnFinish.Location = new Point(575, 364);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(206, 52);
            btnFinish.TabIndex = 4;
            btnFinish.Text = "סיים הזמנה";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += btnFinish_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(713, 42);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 5;
            label1.Text = ":קוד מוצר";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(732, 88);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 6;
            label2.Text = "כמות";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(582, 85);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(125, 27);
            txtQuantity.TabIndex = 7;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(575, 234);
            button1.Name = "button1";
            button1.Size = new Size(206, 51);
            button1.TabIndex = 8;
            button1.Text = "עדכן כמות מוצר";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(575, 291);
            button2.Name = "button2";
            button2.Size = new Size(206, 49);
            button2.TabIndex = 9;
            button2.Text = "מחיקת מוצר";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // CashierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtQuantity);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnFinish);
            Controls.Add(lblTotal);
            Controls.Add(dgvOrder);
            Controls.Add(btnAdd);
            Controls.Add(txtProductCode);
            Name = "CashierForm";
            Text = "CashierForm";
            ((System.ComponentModel.ISupportInitialize)dgvOrder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtProductCode;
        private Button btnAdd;
        private DataGridView dgvOrder;
        private Label lblTotal;
        private Button btnFinish;
        private Label label1;
        private Label label2;
        private TextBox txtQuantity;
        private Button button1;
        private Button button2;
    }
}