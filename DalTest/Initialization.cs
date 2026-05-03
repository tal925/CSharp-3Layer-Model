using DO;
using DalApi;

namespace DalTest;

public static  class Initialization
{
    private static IDal s_dal;


    public static List<int> productCode = new List<int>();
    //אתחול ויצירה של רשימות למוצר
    private static void CreateProducts()
    {
        productCode.Add(s_dal.Product.Create(new Product(0, "PastaShamenet", Category.Pasta, 45, 20)));
        productCode.Add(s_dal.Product.Create(new Product(0, "saled_", Category.Salad, 50, 10)));
        productCode.Add(s_dal.Product.Create(new Product(0, "Coffe", Category.Beverage, 10, 30)));
        productCode.Add(s_dal.Product.Create(new Product(0, "Cake", Category.Desert, 30, 50)));
        productCode.Add(s_dal.Product.Create(new Product(0, "TastyPasta", Category.Pasta, 60, 60)));
    }
    //אתחול ויצירה של רשימות מבצעים
    private static void CreateSales()
    {
        s_dal.Sale.Create(new Sale(0, productCode[0], 3, 110, true, DateTime.Now, DateTime.Now.AddDays(3)));
        s_dal.Sale.Create(new Sale(0, productCode[1], 2, 90, false, DateTime.Now, DateTime.Now.AddDays(10)));
        s_dal.Sale.Create(new Sale(0, productCode[2], 4, 35, true, DateTime.Now, DateTime.Now.AddDays(7)));
        s_dal.Sale.Create(new Sale(0, productCode[3], 2, 50, false, DateTime.Now, DateTime.Now.AddDays(5)));
        s_dal.Sale.Create(new Sale(0, productCode[4], 5, 270, false, DateTime.Now, DateTime.Now.AddDays(14)));
    }
    //אתחול ויצירה של רשימות לקוחות
    private static void CreateCustemers()
    {
        s_dal.Custemer.Create(new Custemer(326458495, "Avram", "jerusalem", 0548597494));
        s_dal.Custemer.Create(new Custemer(741852963, "Shoshana", "BB", 0538597494));
        s_dal.Custemer.Create(new Custemer(789456123, "NOA", "Modiin", 0525697494));
        s_dal.Custemer.Create(new Custemer(321654987, "Gadi", "BB", 0508597494));
        s_dal.Custemer.Create(new Custemer(021356874, "RUT", "jerusalem", 0548562494));
    }

    //קריאה לשלושת הפונקציות
    public static void Initialize()
    {
        s_dal = DalApi.Factory.Get;

        CreateProducts();
        CreateSales();
        CreateCustemers();
    }
}
