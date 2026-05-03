using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;

namespace BlImplementation
{
    //החזקת 4 אובייקטים של הממשקים השונים
    internal class Bl : IBL
    {
        public IProduct Product => new ProductImplementation();
        public ICustemer Custemer => new CustemerImplementation();
        public ISale Sale => new SaleImplementation();
        public IOrder Order => new OrderImplementation();

    }
}
