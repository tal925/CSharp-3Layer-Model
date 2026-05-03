using System;
using System.Windows.Forms;
using BlApi;

namespace UI
{
    public partial class FromProduct : Form
    {
        // יצירת מופע של השכבה העסקית
        IBL bl = BlApi.Factory.Get();
        BO.Product? currentProduct = null;

        // בנאי להוספת מוצר חדש
        public FromProduct()
        {
            InitializeComponent();
            InitializeFormLogic();
        }

        // בנאי לעריכת מוצר קיים (אופציונלי)
        public FromProduct(BO.Product product)
        {
            InitializeComponent();
            this.currentProduct = product;
            InitializeFormLogic();

            // מילוי הנתונים הקיימים בתיבות
            txtId.Text = product.ProductId.ToString();
            txtName.Text = product.ProductName;
            txtPrice.Text = product.Price.ToString();
            txtStok.Text = product.AmountProduct.ToString();
            txtCategory.SelectedItem = product.Category;
        }

        // פונקציית עזר להגדרות התחלתיות של הטופס
        private void InitializeFormLogic()
        {
            // טעינת הקטגוריות ל-ComboBox
            txtCategory.DataSource = Enum.GetValues(typeof(BO.Category));

            // הגנה על ה-ID בעריכה (אם רוצים למנוע שינוי מזהה)
            if (currentProduct != null)
            {
                txtId.Enabled = false;
            }
        }

        private void FromProduct_Load(object sender, EventArgs e)
        {
            // ממלא את ה-ComboBox בכל הערכים הקיימים ב-Enum של הקטגוריות
            txtCategory.DataSource = Enum.GetValues(typeof(BO.Category));
        }

        // כפתור שמירה
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // בדיקות תקינות פשוטות
                if (string.IsNullOrWhiteSpace(txtName.Text) || txtCategory.SelectedItem == null)
                {
                    MessageBox.Show("נא למלא את כל השדות.");
                    return;
                }

                BO.Product p = new BO.Product()
                {
                    ProductId = int.Parse(txtId.Text),
                    ProductName = txtName.Text,
                    Price = double.Parse(txtPrice.Text),
                    AmountProduct = int.Parse(txtStok.Text),
                    Category = (BO.Category)txtCategory.SelectedItem
                };

                if (currentProduct == null)
                {
                    // הוספה
                    bl.Product.Create(p);
                    MessageBox.Show("המוצר נוסף בהצלחה!");
                }
                else
                {
                    // עדכון
                    bl.Product.Update(p);
                    MessageBox.Show("המוצר עודכן בהצלחה!");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בשמירה: " + ex.Message);
            }
        }

        // כפתור ביטול/חזרה
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FromProduct_Load_1(object sender, EventArgs e)
        {

        }
    }
}