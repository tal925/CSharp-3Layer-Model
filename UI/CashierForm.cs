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


namespace UI
{
    public partial class CashierForm : Form
    {
        // משתנה ה-BL שלך (ההזרקה לממשק)
        // תבדקי מה השם של הממשק הראשי שלך (בדרך כלל IBl או IBlApi)
        private BlApi.IBL _bl = BlApi.Factory.Get();
        private BO.Order _currentOrder = new BO.Order();
        private BindingList<BO.ProductInOrder> _productsBindingList;
        public CashierForm()
        {
            InitializeComponent();

            dgvOrder.AllowUserToAddRows = false;

            // התיקון: בדיקה ואתחול של הרשימה אם היא ריקה
            if (_currentOrder.ProductInOrder == null)
            {
                _currentOrder.ProductInOrder = new List<BO.ProductInOrder>();
            }

            // עכשיו זה בטוח לעבוד, כי הרשימה כבר קיימת בזיכרון
            _productsBindingList = new BindingList<BO.ProductInOrder>(_currentOrder.ProductInOrder);
            dgvOrder.DataSource = _productsBindingList;
        }
        private void UpdateOrderUI()
        {
            RefreshOrderGrid();

            // כאן הקוד שחישב את הסכום והציג ב-Label
            double total = _currentOrder.ProductInOrder.Sum(p => p.EndPriceProduct * p.Amount);
            lblTotal.Text = "סכום כולל: " + total.ToString("C");
        }

        // פונקציה שמטפלת בהוספת מוצר
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. בדיקת קלט עבור קוד מוצר
                if (!int.TryParse(txtProductCode.Text, out int productId))
                {
                    MessageBox.Show("נא להזין קוד מוצר מספרי.");
                    return;
                }

                // 2. בדיקת קלט עבור כמות
                // מוודאים שהמשתמש הזין מספר ושהוא גדול מ-0
                if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("נא להזין כמות תקינה (מספר חיובי).");
                    return;
                }

                // 3. קריאה למתודה ב-BL עם הכמות שהמשתמש בחר
                _bl.Order.AddProductToOrder(_currentOrder, productId, quantity);

                // 4. עדכון הממשק
                RefreshOrderGrid();

                // עדכון הסכום הכולל
                lblTotal.Text = $"סה\"כ לתשלום: {_currentOrder.EndPrice} ₪";

                // ניקוי השדות למוצר הבא
                txtProductCode.Clear();
                txtQuantity.Text = "1"; // ברירת מחדל נוחה
                txtProductCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה: {ex.Message}");
            }
        }

        // פונקציה שמציגה את מצב ההזמנה הנוכחי (חלק מהדרישות)
        private void RefreshOrderGrid()
        {
            _productsBindingList.ResetBindings();

            // אם אין מוצרים ברשימה - נסתיר את הטבלה, אם יש - נציג אותה
            dgvOrder.Visible = (_productsBindingList.Count > 0);

            // עדכון הסכום
            lblTotal.Text = $"סה\"כ לתשלום: {_currentOrder.EndPrice} ₪";
        }

        // פונקציה לסיום הזמנה (DoOrder)
        private void btnDoOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            // 1. הגנה: בדיקה אם יש בכלל מוצרים בהזמנה
            if (_currentOrder.ProductInOrder == null || _currentOrder.ProductInOrder.Count == 0)
            {
                MessageBox.Show("לא ניתן לבצע הזמנה ריקה. נא להוסיף מוצרים.");
                return;
            }

            try
            {
                // 2. קריאה ל-BL לביצוע ההזמנה
                // וודאי שאת קוראת לפונקציה הנכונה מה-Interface הנכון
                _bl.Order.DoOrder(_currentOrder);

                MessageBox.Show("ההזמנה בוצעה בהצלחה!");

                // 3. איפוס להזמנה חדשה
                // יוצרים אובייקט חדש לגמרי כדי שההזמנה הקודמת לא תישמר בזיכרון
                _currentOrder = new BO.Order();

                // אתחול רשימת המוצרים באובייקט החדש (אם צריך)
                _currentOrder.ProductInOrder = new List<BO.ProductInOrder>();

                // 4. רענון ממשק
                RefreshOrderGrid(); // פונקציה שמעדכנת את ה-DataGridView
                UpdateOrderUI();    // פונקציה שמעדכנת את הסכום הכולל ל-0

                txtProductCode.Focus();
            }
            catch (Exception ex)
            {
                // אם ה-BL זרק שגיאה (למשל: מוצר אזל מהמלאי), כאן היא תוצג
                MessageBox.Show("שגיאה בסיום הזמנה: " + ex.Message);
            }
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("אנא בחר מוצר מהטבלה לעדכון.");
                return;
            }

            var selectedProduct = (BO.ProductInOrder)dgvOrder.SelectedRows[0].DataBoundItem;

            // פתיחת תיבת קלט (Microsoft.VisualBasic)
            string input = Microsoft.VisualBasic.Interaction.InputBox("הזן כמות חדשה:", "עדכון כמות", selectedProduct.Amount.ToString());

            if (int.TryParse(input, out int newQuantity) && newQuantity > 0)
            {
                // עדכון הכמות באובייקט
                selectedProduct.Amount = newQuantity;

                // עדכון המחיר של המוצר לפי הכמות החדשה
                _bl.Order.CalcTotalPriceForProduct(selectedProduct);  // חישוב מחדש של המחיר הסופי של המוצר

                // חשוב: להודיע לטבלה שהנתונים השתנו
                _productsBindingList.ResetBindings();

                // רענון הסכום בתצוגה
                RefreshOrderGrid();  // עדכון סכום כולל

                // עדכון הסכום הכללי של ההזמנה
                UpdateOrderUI();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // בדיקה שבאמת נבחרה שורה
            if (dgvOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("אנא בחר מוצר מהטבלה למחיקה.");
                return;
            }

            // הודעת אישור
            DialogResult result = MessageBox.Show("האם את בטוחה שברצונך למחוק את המוצר מההזמנה?",
                                                  "אישור מחיקה",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            // אם המשתמש לחץ על "Yes"
            if (result == DialogResult.Yes)
            {
                // שליפת המוצר מהשורה הנבחרת
                var selectedProduct = (BO.ProductInOrder)dgvOrder.SelectedRows[0].DataBoundItem;

                // הסרה מהרשימה המקושרת
                _productsBindingList.Remove(selectedProduct);

                // רענון התצוגה
                RefreshOrderGrid();
            }
        }
    }
}

