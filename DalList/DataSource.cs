

using DO;

namespace Dal;

internal static class DataSource
{
    internal static List<Product?> Products = new List<Product?>();
    internal static List<Custemer?> Custemers = new List<Custemer?>();
    internal static List<Sale?> Sales = new List<Sale?>();

    internal static class Config
    {
        //מזהה רץ מבצע
        internal const int StartSale = 20;

        private static int IndexSale = StartSale;
        internal static int NextSale
        {
            get => IndexSale++;
        }

        //מזהה רץ מוצר
        internal const int StartProduct = 8;
        private static int IndexProduct = StartProduct;
        internal static int NextProduct
        {
            get => IndexProduct++;
        }
    }
}
