
using DalApi;
using DO;
using System.Data;
using System.Reflection;
using Tools;

namespace Dal;

internal class CustemerImplementation : ICustemer
{//v
    public int Create(Custemer item)
    {
        //בודק שהID לא קיים בכל הלקוחות הקיימים אם קיים זורק שגיאה
        if (DataSource.Custemers.Any(c => c.CustemerID == item.CustemerID))
            throw new Exception($"Customer with Barcode {item.CustemerID} already exists.");
        //אחרת מוסיף לקוח חדש
        DataSource.Custemers.Add(item);
        LogManager.WriteToLog("create custemer", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
        return item.CustemerID;
    }

    //v
    public Custemer? Read(Func<Custemer, bool>? filter)
    {
        //מחזיר את הלקוח הספציפי לפי הפילטר שהתקבל
        return DataSource.Custemers.FirstOrDefault(filter);
    }
    public Custemer? Read(int id)
    {
        return DataSource.Custemers.FirstOrDefault(c => c != null && c.CustemerID == id);
    }


    //v
    public List<Custemer> ReadAll(Func<Custemer, bool>? filter = null)
    {
        
        if (filter == null)
        {
            return new List<Custemer>(DataSource.Custemers!);
        }
        return DataSource.Custemers.Where(filter).ToList();
    }


    //v
    public void Update(Custemer item)
    {
        Delete(item.CustemerID);
        DataSource.Custemers.Add(item);
    }
    public void Delete(int id)
    {
        //בדיקה שID שקיבלתי אינו קיים אם ריק מחזיר שגיאה אחרת מוחק אותו מהרשימה
        Custemer? removeCustemer = DataSource.Custemers.FirstOrDefault(c => c.CustemerID == id);
        if (removeCustemer == null)
        {
            LogManager.WriteToLog("delete custemer", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name);
            throw new Exception("obj of type custemer with this ID dont exists");
        }
        DataSource.Custemers.Remove(removeCustemer);
    }
}
