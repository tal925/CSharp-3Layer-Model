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
    public partial class FromCustemerList : Form
    {
        private IBL myBll;
        public FromCustemerList()
        {
            InitializeComponent();
            myBll = Factory.Get();
        }

        private void RefreshGrid()
        {
            // במקום לנקות שורות ידנית, פשוט מושכים שוב את הרשימה ומעדכנים את המקור
            dgvCustomers.DataSource = myBll.Custemer.ReadAll().ToList();
        }

        //private void FormCustomerList_Load(object sender, EventArgs e)
        //{
        //    var list = myBll.Custemer.ReadAll();

        //    // בדיקה מהירה: כמה פריטים הגיעו?
        //    int count = list != null ? list.Count() : 0;
        //    MessageBox.Show("מספר לקוחות שנמצאו: " + count);

        //    dgvCustomers.DataSource = list;
        //}
        private void FromCustemerList_Load(object sender, EventArgs e)
        {
            try
            {
                dgvCustomers.Visible = false; // הגריד מוסתר בהתחלה
                var list = myBll.Custemer.ReadAll();
                int count = list?.Count() ?? 0;

                if (list != null && count > 0)
                {
                    // 1. נקה עמודות קיימות מה-Designer כדי למנוע התנגשות
                    dgvCustomers.Columns.Clear();

                    // 2. תן לגריד לייצר עמודות אוטומטית לפי המאפיינים של האובייקט
                    dgvCustomers.AutoGenerateColumns = true;

                    // 3. הצג את הנתונים
                    dgvCustomers.DataSource = list.ToList();
                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("שגיאה בטעינת נתונים: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new FromCustemer(); // בנאי ריק להוספה
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // רענון הרשימה לאחר שהמשתמש שמר
                dgvCustomers.DataSource = myBll.Custemer.ReadAll();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // בדיקה: האם הגריד מוסתר?
            if (!dgvCustomers.Visible)
            {
                dgvCustomers.Visible = true; // נציג אותו
                RefreshGrid(); // נטען נתונים
                //MessageBox.Show("הרשימה הוצגה. אנא בחר לקוח מהרשימה ולאחר מכן לחץ שוב על 'עדכון'.");
                return; // יוצאים מהפונקציה ומחכים שהמשתמש ילחץ שוב
            }

            // אם הגענו לכאן, סימן שהגריד כבר היה גלוי, אז אפשר לבדוק בחירה
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                var selectedCustomer = (BO.Custemer)dgvCustomers.SelectedRows[0].DataBoundItem;
                var editForm = new FromCustemer(selectedCustomer);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid(); // רענון אחרי עדכון
                }
            }
            else
            {
                MessageBox.Show("נא לבחור לקוח מהטבלה כדי לעדכן.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // שלב 1: בדיקה אם הגריד נסתר
            if (!dgvCustomers.Visible)
            {
                // אם הוא נסתר - רק נציג אותו ונטען נתונים, ולא נבצע כלום מעבר לזה.
                dgvCustomers.Visible = true;
                RefreshGrid();
                return; // עוצרים כאן! המשתמש ילחץ שוב אחרי שיבחר שורה.
            }

            // שלב 2: אם הגענו לכאן, הגריד כבר גלוי. נבדוק אם נבחרה שורה.
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                var selectedCustomer = (BO.Custemer)dgvCustomers.SelectedRows[0].DataBoundItem;

                // אישור מחיקה מהמשתמש
                var result = MessageBox.Show($"האם אתה בטוח שברצונך למחוק את {selectedCustomer.CustemerName}?",
                                             "אישור מחיקה",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // ביצוע המחיקה
                        myBll.Custemer.Delete(selectedCustomer.CustemerID.Value);

                        // רענון כדי לראות שהשורה נעלמה
                        RefreshGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("שגיאה במחיקה: " + ex.Message);
                    }
                }
            }
            else
            {
                // שלב 3: רק אם הגריד גלוי ועדיין לא נבחרה שורה - נציג הודעה
                MessageBox.Show("נא לבחור לקוח מהטבלה כדי למחוק.");
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            // שומרים את מה שהמשתמש הקליד
            string searchText = txtFilter.Text;

            // משתמשים בפונקציה ReadAll עם פילטר
            // אנחנו מבקשים ממנה להביא רק לקוחות שהשם שלהם מכיל את מה שהוקלד
            var filteredList = myBll.Custemer.ReadAll(c => c.CustemerName.Contains(searchText));

            // מעדכנים את הטבלה בתוצאות המסוננות
            dgvCustomers.DataSource = filteredList.ToList();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnShowCustomers_Click_Click(object sender, EventArgs e)
        {
            dgvCustomers.Visible = true; // חושפים את הגריד
            RefreshGrid(); // טוענים את הנתונים
        }
    }
}

