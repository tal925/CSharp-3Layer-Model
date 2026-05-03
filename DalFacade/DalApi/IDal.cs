using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    //אינטרפייס שמכיל את 3 האנטרפייסים 
    public interface IDal
    {
        ICustemer Custemer {  get; }
        ISale Sale { get; }
        IProduct Product { get; }

    }
}
