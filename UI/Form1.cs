namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FromManagerMenu managerMenu = new FromManagerMenu(); // יוצר מסך מנהל חדש
            managerMenu.Show(); // מציג אותו
            this.Hide(); // מסתיר את מסך התפריט הראשי
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CashierForm cashierForm = new CashierForm(); // יוצר מסך קופאי חדש
            cashierForm.Show(); // מציג אותו
            this.Hide(); // מסתיר את מסך התפריט הראשי
        }
    }
}
