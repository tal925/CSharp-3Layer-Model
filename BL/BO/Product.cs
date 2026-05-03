namespace BO
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public int AmountProduct { get; set; }

        public Product() { } // בנאי ריק

        public Product(int productId, string name, Category category, double price, int amount)
        {
            ProductId = productId;
            ProductName = name;
            Category = category;
            Price = price;
            AmountProduct = amount;
        }

        public override string ToString() => this.ToStringProperty();
    }
}