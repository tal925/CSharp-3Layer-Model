using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FromSalesList : Form
    {
        BlApi.IBL bl = BlApi.Factory.Get();
        string placeholderText = "חפש מבצע לפי שם"; public FromSalesList()
        {
            InitializeComponent();
            txtFilterSale.Text = placeholderText;
            txtFilterSale.ForeColor = Color.Gray;
        }
        // פונקציה לטעינת הנתונים ועדכון הטבלה
        private void RefreshData()
        {
            try
            {
                // שליפת כל המבצעים מה-BL ומיון לפי תאריך התחלה
                var salesList = bl.Sale.ReadAll()
                                 .OrderBy(s => s.StartrSale)
                                 .ToList();

                dgvSales.DataSource = salesList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת הנתונים: " + ex.Message);
            }
        }

        private void FromSalesList_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void btnAddSale_Click(object sender, EventArgs e)
        {
            //הצגת הטופס של הוספת מבצע חדש
            FromSale menu = new FromSale();
            menu.ShowDialog();
            RefreshData();
        }

        private void btnUpdateSale_Click(object sender, EventArgs e)
        {
            // בדיקה שנבחרה שורה בטבלה
            if (dgvSales.CurrentRow != null)
            {
                // חילוץ האובייקט של המבצע מהשורה
                BO.Sale selectedSale = (BO.Sale)dgvSales.CurrentRow.DataBoundItem;

                // פתיחת הטופס עם הבנאי שמקבל אובייקט
                FromSale frm = new FromSale(selectedSale);
                frm.ShowDialog();

                // רענון הטבלה כשהטופס נסגר
                RefreshData();
            }
            else
            {
                MessageBox.Show("אנא בחרו מבצע לעדכון מהרשימה");
            }
        }

        private void btnDeleteSale_Click(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow != null)
            {
                // חילוץ המבצע מהשורה שנבחרה
                var sale = dgvSales.CurrentRow.DataBoundItem as BO.Sale;

                var result = MessageBox.Show($"האם למחוק את המבצע: {sale.SaleId}?", "אישור מחיקה", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    bl.Sale.Delete(sale.SaleId);
                    RefreshData();
                }
            }
            else
            {
                MessageBox.Show("בחר מבצע למחיקה מהרשימה");
            }
        }

        private void txtFilterSale_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFilterSale.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filterText) || filterText == placeholderText.ToLower())
            {
                RefreshData();
                return;
            }

            // סינון רק אם באמת הוקלד משהו
            var filteredList = bl.Sale.ReadAll()
                                 .Where(s => s.ProductID.ToString().Contains(filterText))
                                 .ToList();

            dgvSales.DataSource = filteredList;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterSale_Enter(object sender, EventArgs e)
        {
            if (txtFilterSale.Text == placeholderText)
            {
                txtFilterSale.Text = "";
                txtFilterSale.ForeColor = Color.Black;
            }
        }

        private void txtFilterSale_Leave(object sender, EventArgs e)
        {
            // ברגע שהמשתמש יוצא מהתיבה - אם הוא לא כתב כלום, מחזירים את ההסבר
            if (string.IsNullOrWhiteSpace(txtFilterSale.Text))
            {
                txtFilterSale.Text = placeholderText;
                txtFilterSale.ForeColor = Color.Gray;
            }
        }
    }
}
