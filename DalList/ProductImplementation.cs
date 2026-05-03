using DO;
using DalApi;
using System.Reflection;
using Tools;

namespace Dal;

internal class ProductImplementation : IProduct
{

    //מימוש של DAL של מוצר, כל הפונקציות מתבצעות על רשימת המוצרים ב DataSource
    //v
    public int Create(Product item)
    {
        int newId = DataSource.Products.Count == 0 ? DataSource.Config.StartProduct
        : DataSource.Products.Max(p => p.ProductId) + 1;
        Product p2 = item with { ProductId = newId };
        DataSource.Products.Add(p2);
        LogManager.WriteToLog("create product", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
        return newId;
    }

    //v
    public Product? Read(Func<Product, bool> filter)
    {
        return DataSource.Products.FirstOrDefault(filter);
    }
    public Product? Read(int id)
    {
        return DataSource.Products.FirstOrDefault(p => p != null && p.ProductId == id);
    }

    //v
    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        if (filter == null)
        {
            return new List<Product>(DataSource.Products!);
        }
        return DataSource.Products.Where(filter).ToList();
    }

    //v
    public void Update(Product item)
    {
        Delete(item.ProductId);
        DataSource.Products.Add(item);
    }

    //v
    public void Delete(int id)
    {
        Product? removeProduct = DataSource.Products.FirstOrDefault(p => p.ProductId == id);
        if (removeProduct == null)
        {
            LogManager.WriteToLog("delete sale", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            throw new Exception("obj of type product with this ID dont exists");
        }
        DataSource.Products.Remove(removeProduct);
    }
}