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
    public partial class FromSale : Form
    {
        BlApi.IBL bl = BlApi.Factory.Get();
        bool isUpdate = false;
        int currentSaleId = 0; // משתנה שישמור את ה-ID בשקט בצד
        int currentProductId = 0;
        public FromSale()
        {
            InitializeComponent();
            isUpdate = false; // מצב הוספה
        }
        public FromSale(BO.Sale sale)
        {
            InitializeComponent();
            isUpdate = true; // מצב עדכון
            currentSaleId = sale.SaleId; // שומרים את ה-ID של המבצע שנבחר לעדכון
            currentProductId = sale.ProductID; // שומרים את ה-ID של המוצר שנבחר לעדכון
            // מילוי הפקדים בנתונים שהגיעו
            txtDiscount.Text = sale.MinProductSale.ToString();
            txtSumPrice.Text = sale.SumPriceSale.ToString();
            chkIfEveryOne.Checked = sale.IfEveryOne;
            dtpStartDate.Value = sale.StartrSale;
            dtpEndDate.Value = sale.EndSale;
        }

        private void txtSaleId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FromSale_Load(object sender, EventArgs e)
        {
            // טעינת רשימת המוצרים מה-BL
            var products = bl.Product.ReadAll().ToList();

            cmbProducts.ValueMember = "ProductID";     // הקוד המספרי
            cmbProducts.DisplayMember = "ProductName"; // השם שרואים
            cmbProducts.DataSource = products;    // מה הערך שנשמר (הקוד)

            // אם אנחנו במצב עדכון, נבחר את המוצר המתאים
            if (isUpdate)
            {
                cmbProducts.SelectedValue = currentProductId;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveSale_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. בדיקה שבאמת נבחר מוצר מהרשימה והערך הוא מספר
                if (cmbProducts.SelectedValue == null || !(cmbProducts.SelectedValue is int))
                {
                    MessageBox.Show("נא לבחור מוצר תקין מהרשימה");
                    return;
                }

                // 2. ניסיון המרה בטוח של המחיר
                string priceText = txtSumPrice.Text.Replace(".", ",");
                if (!double.TryParse(priceText, out double finalPrice))
                {
                    MessageBox.Show("המחיר שהוזן אינו תקין");
                    return;
                }

                // 3. ניסיון המרה בטוח של הכמות
                if (!int.TryParse(txtDiscount.Text, out int minProduct))
                {
                    // אם ההמרה נכשלה, אפשר לקבוע ברירת מחדל או להציג שגיאה
                    minProduct = 1;
                }

                // 4. יצירת האובייקט רק אחרי שווידאנו שהכל תקין
                BO.Sale s = new BO.Sale()
                {
                    SaleId = isUpdate ? currentSaleId : 0,
                    ProductID = (int)cmbProducts.SelectedValue,
                    MinProductSale = minProduct,
                    SumPriceSale = finalPrice,
                    IfEveryOne = chkIfEveryOne.Checked,
                    StartrSale = dtpStartDate.Value.Date,
                    EndSale = dtpEndDate.Value.Date
                };

                // 5. שמירה
                if (isUpdate)
                {
                    bl.Sale.Update(s);
                    MessageBox.Show("המבצע עודכן בהצלחה!");
                }
                else
                {
                    bl.Sale.Create(s);
                    MessageBox.Show("המבצע נוסף בהצלחה!");
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בלתי צפויה: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // סגירת הטופס ללא שמירה
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
