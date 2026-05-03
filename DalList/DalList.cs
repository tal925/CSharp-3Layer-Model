using DO;
using DalApi;

namespace Dal
{
    internal sealed class DalList : IDal
    {
        public ICustemer Custemer => new CustemerImplementation();
        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();


        //מכיל את כל האובייקטים של הממשקים השונים, ומחזיר אותם כאשר קוראים להם
        private static readonly DalList instance = new DalList();
        private DalList() { }

        public static DalList Instance
        {
            get { return instance; }
        }




    }
}
