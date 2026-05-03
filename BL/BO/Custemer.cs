namespace BO
{
    public class Custemer
    {
        // Property  { get; set; }
        public int? CustemerID { get; set; }
        public string CustemerName { get; set; }
        public string Adress { get; set; }
        public int? Phone { get; set; }

        // הבנאים (Constructors) יכולים להישאר כפי שהם
        public Custemer(int CustemerID, string CustemerName, string Adress, int Phone)
        {
            this.CustemerID = CustemerID;
            this.CustemerName = CustemerName;
            this.Adress = Adress;
            this.Phone = Phone;
        }

        public Custemer() { }

        public override string ToString() => this.ToStringProperty();
    }
}