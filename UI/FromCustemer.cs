using BlApi;

namespace UI
{
    public partial class FromCustemer : Form
    {
        // 1. הגדירי משתנה ברמת המחלקה שישמור את הלקוח שאנחנו עורכים
        
        private IBL myBll;
        private BO.Custemer _customer; // משתנה לשמירת הלקוח שאנחנו עובדים עליו
        private bool isUpdate = false; // האם אנחנו בעריכה או הוספה?

        // 2. הבנאי הקיים (להוספת לקוח חדש - הכל ריק)
        
        public FromCustemer()
        {
            InitializeComponent();
            myBll = Factory.Get();
            _customer = new BO.Custemer(); // יוצרים אובייקט חדש
        }

        public FromCustemer(BO.Custemer customer)
        {
            InitializeComponent();
            myBll = Factory.Get();
            _customer = customer;
            isUpdate = true;

            // ממלאים את השדות בפרטי הלקוח הקיים
            txtId.Text = _customer.CustemerID.ToString();
            txtName.Text = _customer.CustemerName;
            txtAddress.Text = _customer.Adress;
            txtPhone.Text = _customer.Phone.ToString();

            // מונעים עריכה של ה-ID כדי שלא ישנו מפתח ראשי
            txtId.Enabled = false;
        }
        // 3. בנאי חדש (לעריכת לקוח קיים - מעבירים אובייקט)
        //public FromCustemer(BO.Custemer customer)
        //{
        //    InitializeComponent();
        //    _currentCustomer = customer; // שומרים את הלקוח שהועבר

        //    // כאן את ממלאת את השדות בטופס בנתונים של הלקוח
        //    // החליפי את שמות השדות (txt...) בשמות האמיתיים שיש לך בטופס
        //    // txtName.Text = _currentCustomer.Name;
        //    // txtId.Text = _currentCustomer.Id.ToString();
        //}

        private void FromCustemer_Load(object sender, EventArgs e)
        {
            // אם את רוצה לעשות פעולות כשהטופס נטען
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. בדיקת תקינות בסיסית (Validation)
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("נא למלא את כל השדות!");
                return; // עוצרים את הפעולה
            }

            // 2. המרה בטוחה (TryParse)
            // בודקים אם ההמרה הצליחה, אם לא - מציגים הודעה ולא מנסים לעדכן
            if (!int.TryParse(txtId.Text, out int id) || !int.TryParse(txtPhone.Text, out int phone))
            {
                MessageBox.Show("שדות תעודת זהות וטלפון חייבים להכיל מספרים בלבד.");
                return;
            }

            try
            {
                // 3. עדכון האובייקט (משתמשים במשתנים המומרים שכבר יש לנו)
                _customer.CustemerID = id;
                _customer.CustemerName = txtName.Text;
                _customer.Adress = txtAddress.Text;
                _customer.Phone = phone;

                // 4. פעולת ה-BLL
                if (isUpdate)
                {
                    myBll.Custemer.Update(_customer);
                }
                else
                {
                    myBll.Custemer.Create(_customer);
                }

                // 5. סגירה
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // ה-catch הזה נועד לשגיאות שבאמת לא צפינו (כמו בעיית תקשורת עם ה-DAL)
                MessageBox.Show("שגיאה בלתי צפויה: " + ex.Message);
            }
        }
    }
    }
