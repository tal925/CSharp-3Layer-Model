using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Product(int ProductId, string ProductName, Category Category, double Price, int AmountProduct)
    {
        public Product():this(111,"pizzaShamenet", Category.Pizza, 65,5)
        {

        }
    }
}
