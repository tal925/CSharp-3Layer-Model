using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DO;

namespace DalApi
{
    public  interface ICrud <T>
    {
        //פונקציות גנריות שקיימות בכל יישות!
        int Create(T item);
        T? Read(Func<T,bool>? filter);
        T? Read(int id);
        List<T> ReadAll(Func<T, bool>? filter = null);
        void Update(T item);
        void Delete(int id);

    }
}
