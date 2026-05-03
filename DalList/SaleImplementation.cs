
using DO;
using DalApi;
using System.Reflection;
using Tools;

namespace Dal;
internal class SaleImplementation : ISale
{
    //מימוש של DAL של Sale
    //v
    public int Create(Sale item)
    {
        int newId = DataSource.Config.NextSale;

        Sale s2 = item with { SaleId = newId };

        DataSource.Sales.Add(s2);
        return newId;
    }

    //v
    public Sale? Read(Func<Sale, bool> filter)
    {
        return DataSource.Sales.FirstOrDefault(filter);
    }
    public Sale? Read(int id)
    {
        return DataSource.Sales.FirstOrDefault(s => s != null && s.SaleId == id);
    }


    //v
    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        if (filter == null)
        {
            return new List<Sale>(DataSource.Sales!);
        }
        return DataSource.Sales.Where(filter).ToList();
    }
    //v
    public void Update(Sale item)
    {
        Delete(item.SaleId);
        DataSource.Sales.Add(item);
    }

    //v
    public void Delete(int id)
    {
        Sale? removeSale = DataSource.Sales.FirstOrDefault(s => s.SaleId == id);

        if (removeSale == null)
        {
            LogManager.WriteToLog("delete sale", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            throw new Exception("obj of type sale with this ID dont exists");
        }
        DataSource.Sales.Remove(removeSale);
    }
}
