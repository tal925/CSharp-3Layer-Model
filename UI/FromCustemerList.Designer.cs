namespace UI
{
    partial class FromCustemerList
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
            dgvCustomers = new DataGridView();
            txtFilter = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            label1 = new Label();
            btnShowCustomers_Click = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(23, 47);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.RowTemplate.Height = 29;
            dgvCustomers.Size = new Size(553, 336);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(663, 70);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(125, 27);
            txtFilter.TabIndex = 1;
            txtFilter.TextChanged += txtFilter_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(663, 127);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(125, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "הוסף לקוח";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(663, 189);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(125, 32);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "עדכן לקוח";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(663, 250);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(125, 37);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "מחק לקוח";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(682, 47);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 5;
            label1.Text = "סינון לפי שם";
            // 
            // btnShowCustomers_Click
            // 
            btnShowCustomers_Click.Location = new Point(663, 311);
            btnShowCustomers_Click.Name = "btnShowCustomers_Click";
            btnShowCustomers_Click.Size = new Size(125, 42);
            btnShowCustomers_Click.TabIndex = 6;
            btnShowCustomers_Click.Text = "הצג לקוחות";
            btnShowCustomers_Click.UseVisualStyleBackColor = true;
            btnShowCustomers_Click.Click += btnShowCustomers_Click_Click;
            // 
            // FromCustemerList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnShowCustomers_Click);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtFilter);
            Controls.Add(dgvCustomers);
            Name = "FromCustemerList";
            Text = "FromCustemerList";
            Load += FromCustemerList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCustomers;
        private TextBox txtFilter;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label1;
        private Button btnShowCustomers_Click;
    }
}