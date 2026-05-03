using BlApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class FromProductList : Form
    {
        IBL bl = BlApi.Factory.Get();

        public FromProductList()
        {
            InitializeComponent();
            textBox1.Text = "סנן לפי/קטגוריה";
            textBox1.ForeColor = Color.Gray;
        }

        private void FromProductList_Load(object sender, EventArgs e)
        {
            RefreshData();
        }


        // פונקציית עזר לרענון הטבלה
        private void RefreshData()
        {
            var list = bl.Product.ReadAll()
                        .OrderBy(p => p.ProductId) // ממיין מהקטן לגדול
                        .ToList();

            dataGridView1.DataSource = list;
        }

        private void textBox1_TextChanged_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox1.Text.ToLower();

            if (string.IsNullOrEmpty(filter) || filter == "סנן לפי/קטגוריה")
            {
                RefreshData(); // אם התיבה ריקה, הציג הכל
            }
            else
            {
                // סינון הרשימה הקיימת לפי שם קטגוריה
                var filteredList = bl.Product.ReadAll()
                    .Where(p => p.Category.ToString().ToLower().Contains(filter))
                    .ToList();

                dataGridView1.DataSource = filteredList;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // יצירת מופע חדש של טופס המוצר
            FromProduct frm = new FromProduct();
            frm.ShowDialog();

            // לאחר סגירת הטופס, לקרוא לפונקציית רענון לטבלה
            RefreshData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // בדיקה אם נבחרה שורה בטבלה
            if (dataGridView1.CurrentRow != null)
            {
                // שליפת האובייקט הנבחר
                var selectedProduct = dataGridView1.CurrentRow.DataBoundItem as BO.Product;

                // פתיחת טופס המוצר ושליחת הנתונים לעדכון
                FromProduct frm = new FromProduct(selectedProduct);
                frm.ShowDialog();

                // רענון הטבלה בסיום
                RefreshData();
            }
            else
            {
                MessageBox.Show("אנא בחרו מוצר מהרשימה לעדכון");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // 1. שליפת המוצר הנבחר
                var selectedProduct = dataGridView1.CurrentRow.DataBoundItem as BO.Product;

                // 2. שאלת אישור מהמשתמש 
                var result = MessageBox.Show($"האם אתה בטוח שברצונך למחוק את {selectedProduct.ProductName}?",
                                             "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // 3. ביצוע המחיקה דרך ה-BL
                        bl.Product.Delete(selectedProduct.ProductId);

                        // 4. רענון הטבלה
                        RefreshData();
                        MessageBox.Show("המוצר נמחק בהצלחה");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("שגיאה במחיקה: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("אנא בחרו מוצר למחיקה מהרשימה");
            }
        }

        //כפתור חזרה לתפריט
        private void txtAgain_Click_Click(object sender, EventArgs e)
        {
            this.Close(); // סגירת הטופס
        }
    }
}





