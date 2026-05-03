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
    public partial class FromManagerMenu : Form
    {
        public FromManagerMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // יצירת מופע של המסך החדש
            FromCustemerList menu = new FromCustemerList();
            // הצגת המסך
            menu.ShowDialog();
            //הסתרת המסך הנוכחי
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // יצירת מופע של המסך החדש
            FromSalesList menu = new FromSalesList();
            // הצגת המסך
            menu.ShowDialog();
            //הסתרת המסך הנוכחי
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // יצירת מופע של המסך החדש
           FromProductList menu = new FromProductList();
            // הצגת המסך
            menu.ShowDialog();
            //הסתרת המסך הנוכחי
            this.Hide();
        }
    }
}
