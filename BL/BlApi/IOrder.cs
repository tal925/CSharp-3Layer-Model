using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlApi
{
    public interface IOrder
    {
        public IEnumerable<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int amount);
        public void CalcTotalPriceForProduct(BO.ProductInOrder product);
        public void CalcTotalPrice(BO.Order order);
        public void DoOrder(BO.Order order);
        public void SearchSaleForProduct(BO.ProductInOrder productInOrder, bool IsFavorite);
    }
}
