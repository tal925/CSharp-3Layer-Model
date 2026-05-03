using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int ProductID { get; set; }
        public int MinProductSale { get; set; }
        public double SumPriceSale { get; set; }
        public bool IfEveryOne {  get; set; }
        public DateTime StartrSale { get; set; }
        public DateTime EndSale  { get; set; }

        public Sale(int SaleId, int ProductID, int MinProductSale, double SumPriceSale, bool IfEveryOne, DateTime StartrSale, DateTime EndSale)
        {
            this.SaleId = SaleId;
            this.ProductID = ProductID;
            this.MinProductSale = MinProductSale;
            this.SumPriceSale = SumPriceSale;
            this.IfEveryOne = IfEveryOne;
        }
        public Sale() { }

        public override string ToString() => this.ToStringProperty();
    }
}



