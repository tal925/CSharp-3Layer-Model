using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SaleInProduct
    {
        public int IdSale;
        public int AmountForSale;
        public double Price;
        public bool IfEvreyOne;

      public SaleInProduct(int IdSale, int AmountForSale, double Price, bool IfEvreyOne) 
      { 
            this.IdSale = IdSale;
            this.AmountForSale = AmountForSale;
            this.Price = Price;
            this.IfEvreyOne = IfEvreyOne;
      }
    }
}
