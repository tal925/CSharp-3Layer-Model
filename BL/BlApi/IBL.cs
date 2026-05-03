using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBL
    {
        public ICustemer Custemer { get; }
        public IProduct Product { get; }
        public ISale Sale { get; }
        public IOrder Order { get; }
         
    }
}
