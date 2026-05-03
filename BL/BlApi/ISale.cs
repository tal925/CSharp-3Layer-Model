using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlApi
{
    public interface ISale
    {
        int Create(BO.Sale item);
        BO.Sale? Read(int id);
        BO.Sale? Read(Func<BO.Sale, bool>? filter);
        List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null);
        void Update(BO.Sale item);
        void Delete(int id);
        bool IsExist(int id);
    }
}
