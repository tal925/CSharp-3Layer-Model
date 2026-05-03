using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BO;

public static class Tools
{
    public static string ToStringProperty<T>(this T obj)
    {
        if (obj == null) return "";

        string result = "";
       
        var properties = obj.GetType().GetProperties();

        foreach (var prop in properties)
        {
            var value = prop.GetValue(obj, null);

            if (value is System.Collections.IEnumerable list && !(value is string))
            {
                result += $"{prop.Name}: [";
                foreach (var item in list)
                {
                    result += $"\n  {item}";
                }
                result += " ]\n";
            }
            else
            {
                result += $"{prop.Name}: {value}\n";
            }
        }

        return result;
    }
    public static BO.Custemer CopyToBO(this DO.Custemer doCust)
    {
        return new BO.Custemer()
        {
            CustemerID = doCust.CustemerID,
            CustemerName = doCust.CustemerName,
            Adress = doCust.Adress,
            Phone = doCust.Phone
        };
    }
    public static DO.Custemer CopyToDO(this BO.Custemer boCust)
    {
        return new DO.Custemer(
            boCust.CustemerID ?? 0, 
            boCust.CustemerName,
            boCust.Adress,
            boCust.Phone?? 0
        );
    }
    public static BO.Product CopyToBO(this DO.Product doProd)
    {
        return new BO.Product()
        {
            ProductId = doProd.ProductId,
            ProductName = doProd.ProductName,
            Category = (BO.Category)doProd.Category,
            Price = doProd.Price,
            AmountProduct = doProd.AmountProduct,
        };
    }
    public static DO.Product CopyToDO(this BO.Product boProd)
    {
        return new DO.Product(
            boProd.ProductId,
            boProd.ProductName,
            (DO.Category)boProd.Category,
            boProd.Price,
            boProd.AmountProduct
        );
    }
    public static BO.Sale CopyToBO(this DO.Sale doSale)
    {
        return new BO.Sale()
        {
            SaleId = doSale.SaleId,
            ProductID = doSale.ProductID,
            MinProductSale = doSale.MinProductSale,
            SumPriceSale = doSale.SumPriceSale,
            IfEveryOne = doSale.IfEveryOne,
            StartrSale = doSale.StartrSale,
            EndSale = doSale.EndSale
        };
    }
    public static DO.Sale CopyToDO(this BO.Sale boSale)
    {
        return new DO.Sale(
            boSale.SaleId,
            boSale.ProductID,
            boSale.MinProductSale,
            boSale.SumPriceSale,
            boSale.IfEveryOne,
            boSale.StartrSale,
            boSale.EndSale
        );
    }
}
