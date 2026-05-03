using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;


namespace BlApi
{
    public interface ICustemer
    {
        int Create(Custemer item);
        Custemer? Read(int id);
        Custemer? Read(Func<Custemer, bool>? filter = null);
        List<Custemer?> ReadAll(Func<Custemer,bool>? filter = null);
        void Update(Custemer item);
        void Delete(int id);
        bool IsExist(int id);

    }
}
