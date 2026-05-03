using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Custemer(int CustemerID,string CustemerName,string Adress,int Phone)
    {
        public Custemer(int V, string custemerName) : this(329429203, "Yeal", "Rashbi", 0548597494) { }
        public Custemer() : this(0, "", "", 0) { }

    }

}
