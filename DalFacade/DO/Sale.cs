using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Sale(int SaleId,int ProductID,int MinProductSale,double SumPriceSale,bool IfEveryOne,DateTime StartrSale,DateTime EndSale)
    {
        public Sale() : this( 111,123 ,8 ,20.5, true, DateTime.Now, DateTime.Now)
        {
            
        }
    }
}
