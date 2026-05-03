using System;
using System.Collections.Generic;
using System.Linq;
using BO;

namespace BlImplementation
{
    public class OrderImplementation : BlApi.IOrder
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        // 1. חיפוש מבצעים מתאימים למוצר בהזמנה
        public void SearchSaleForProduct(BO.ProductInOrder productInOrder, bool IsFavorite)
        {
            var allSales = _dal.Sale.ReadAll();

            var validSales = from s in allSales
                                 // מבצע על המוצר המבוקש + בתוקף + הכמות בהזמנה הגיעה לכמות המינימום
                             where s.ProductID == productInOrder.Id
                             && s.StartrSale <= DateTime.Now
                             && s.EndSale >= DateTime.Now
                             && productInOrder.Amount >= s.MinProductSale
                             // אם לא לקוח מועדף, המבצע חייב להיות מיועד לכולם
                             && (IsFavorite || s.IfEveryOne)
                             // מיון לפי מחיר ליחידה במבצע (מהזול ליקר)
                             orderby s.SumPriceSale
                             select new BO.SaleInProduct(
                                 s.SaleId,
                                 s.MinProductSale,
                                 s.SumPriceSale,
                                 s.IfEveryOne
                             );

            productInOrder.ListSale = validSales.ToList();
        }

        // 2. חישוב מחיר למוצר כולל מימוש מבצעים
        public void CalcTotalPriceForProduct(BO.ProductInOrder product)
        {
            int count = product.Amount;
            double finalPrice = 0;
            List<BO.SaleInProduct> usedSales = new List<BO.SaleInProduct>();

            // עוברים על המבצעים (הם כבר ממוינים לפי כדאיות מ-SearchSaleForProduct)
            foreach (var sale in product.ListSale)
            {
                if (count < sale.AmountForSale)
                    continue;

                // בדיקה כמה פעמים ניתן לנצל את המבצע
                int timesToUse = count / sale.AmountForSale;
                finalPrice += timesToUse * sale.Price;

                // עדכון הכמות שנותרה (שארית)ת
                count %= sale.AmountForSale;

                // שמירת המבצע שמומש
                usedSales.Add(sale);

                if (count == 0)
                    break;
            }

            // הוספת המחיר הבסיסי עבור הכמות שנשארה ללא מבצע
            finalPrice += count * product.BasePrice;

            // עדכון השדות במוצר
            product.ListSale = usedSales;
            product.EndPriceProduct = finalPrice; // שדה ה-TotalPrice של המוצר
        }

        // 3. חישוב הסכום הסופי לכל ההזמנה
        public void CalcTotalPrice(BO.Order order)
        {
            // סיכום המחיר הסופי של כל המוצרים ברשימה
            order.EndPrice = order.ProductInOrder.Sum(item => item.EndPriceProduct);
        }

        // 4. הוספת מוצר להזמנה
        public IEnumerable<BO.SaleInProduct> AddProductToOrder(BO.Order order, int productId, int amount)
        {
            // שליפת המוצר מה-DAL לבדיקת מלאי ומחיר בסיסי
            DO.Product doProd;
            try
            {
                doProd = _dal.Product.Read(productId) ?? throw new BO.BlDoesNotExistException("Product not found");
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException("Product not found", ex);
            }

            // חיפוש המוצר בתוך ההזמנה הקיימת
            var productInOrder = order.ProductInOrder.FirstOrDefault(p => p.Id == productId);

            if (productInOrder != null)
            {
                // אם קיים - עדכון כמות ובדיקת מלאי
                if (doProd.AmountProduct < productInOrder.Amount + amount)
                    throw new BO.BlInvalidDataException("Not enough items in stock");

                productInOrder.Amount += amount;
            }
            else
            {
                // אם חדש - בדיקת מלאי והוספה
                if (doProd.AmountProduct < amount)
                    throw new BO.BlInvalidDataException("Not enough items in stock");

                productInOrder = new BO.ProductInOrder
                {
                    Id = productId,
                    NameProduct = doProd.ProductName,
                    BasePrice = doProd.Price,
                    Amount = amount,
                    ListSale = new List<BO.SaleInProduct>()
                    
                };
                order.ProductInOrder.Add(productInOrder);
            }

            // ביצוע שרשרת החישובים לפי ההוראות
            SearchSaleForProduct(productInOrder, true); 
            CalcTotalPriceForProduct(productInOrder);
            CalcTotalPrice(order);

            return productInOrder.ListSale;
        }

        // 5. ביצוע ההזמנה הסופי (עדכון מלאי ב-DAL)
        public void DoOrder(BO.Order order)
        {
            foreach (var item in order.ProductInOrder)
            {
                DO.Product doProd = _dal.Product.Read(item.Id) ?? throw new BO.BlDoesNotExistException("Product error");

                // יצירת אובייקט מעודכן עם מלאי מופחת
                DO.Product updatedProd = doProd with { AmountProduct = doProd.AmountProduct - item.Amount };

                _dal.Product.Update(updatedProd);
            }
        }
    }
}
