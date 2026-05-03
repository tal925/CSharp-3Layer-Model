namespace UI
{
    partial class FromSalesList
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
            label1 = new Label();
            dgvSales = new DataGridView();
            txtFilterSale = new TextBox();
            btnAddSale = new Button();
            btnUpdateSale = new Button();
            btnDeleteSale = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(358, 9);
            label1.Name = "label1";
            label1.Size = new Size(145, 20);
            label1.TabIndex = 0;
            label1.Text = "ניהול מבצעים והנחות";
            // 
            // dgvSales
            // 
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.Location = new Point(12, 50);
            dgvSales.Name = "dgvSales";
            dgvSales.RowHeadersWidth = 51;
            dgvSales.RowTemplate.Height = 29;
            dgvSales.Size = new Size(587, 342);
            dgvSales.TabIndex = 1;
            // 
            // txtFilterSale
            // 
            txtFilterSale.Location = new Point(637, 101);
            txtFilterSale.Name = "txtFilterSale";
            txtFilterSale.Size = new Size(136, 27);
            txtFilterSale.TabIndex = 2;
            txtFilterSale.Text = "חפש מבצע לפי שם";
            txtFilterSale.TextChanged += txtFilterSale_TextChanged;
            txtFilterSale.Enter += txtFilterSale_Enter;
            txtFilterSale.Leave += txtFilterSale_Leave;
            // 
            // btnAddSale
            // 
            btnAddSale.Location = new Point(637, 154);
            btnAddSale.Name = "btnAddSale";
            btnAddSale.Size = new Size(136, 29);
            btnAddSale.TabIndex = 3;
            btnAddSale.Text = "צור מבצע חדש";
            btnAddSale.UseVisualStyleBackColor = true;
            btnAddSale.Click += btnAddSale_Click;
            // 
            // btnUpdateSale
            // 
            btnUpdateSale.Location = new Point(637, 208);
            btnUpdateSale.Name = "btnUpdateSale";
            btnUpdateSale.Size = new Size(136, 29);
            btnUpdateSale.TabIndex = 4;
            btnUpdateSale.Text = "ערוך מבצע נבחר";
            btnUpdateSale.UseVisualStyleBackColor = true;
            btnUpdateSale.Click += btnUpdateSale_Click;
            // 
            // btnDeleteSale
            // 
            btnDeleteSale.Location = new Point(637, 260);
            btnDeleteSale.Name = "btnDeleteSale";
            btnDeleteSale.Size = new Size(136, 29);
            btnDeleteSale.TabIndex = 5;
            btnDeleteSale.Text = "בטל מבצע";
            btnDeleteSale.UseVisualStyleBackColor = true;
            btnDeleteSale.Click += btnDeleteSale_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(29, 398);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(136, 29);
            btnBack.TabIndex = 6;
            btnBack.Text = "חזרה לתפריט";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // FromSalesList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnDeleteSale);
            Controls.Add(btnUpdateSale);
            Controls.Add(btnAddSale);
            Controls.Add(txtFilterSale);
            Controls.Add(dgvSales);
            Controls.Add(label1);
            Name = "FromSalesList";
            Text = "FromSalesList";
            Load += FromSalesList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvSales;
        private TextBox txtFilterSale;
        private Button btnAddSale;
        private Button btnUpdateSale;
        private Button btnDeleteSale;
        private Button btnBack;
    }
}