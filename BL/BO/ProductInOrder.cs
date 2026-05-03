namespace BO
{
    public class ProductInOrder
    {
        //Properties
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public double BasePrice { get; set; }
        public int Amount { get; set; }
        public List<SaleInProduct> ListSale { get; set; } = new List<SaleInProduct>();
        public double EndPriceProduct { get; set; }

        // בנאי (Constructor)
        public ProductInOrder(int id, string nameProduct, double basePrice, int amount, double endPriceProduct)
        {
            Id = id;
            NameProduct = nameProduct;
            BasePrice = basePrice;
            Amount = amount;
            EndPriceProduct = endPriceProduct;
        }

        public ProductInOrder() { }
    }
}