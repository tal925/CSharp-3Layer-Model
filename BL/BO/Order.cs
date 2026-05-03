using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
        public bool IsFavoraite;
        public List<ProductInOrder> ProductInOrder;
        public double EndPrice;

        public Order(bool IsFavoraite, double EndPrice)
        { 
            this.IsFavoraite = IsFavoraite;
            this.EndPrice = EndPrice;
        }
        public Order()
        {
            
        }
    }
}
