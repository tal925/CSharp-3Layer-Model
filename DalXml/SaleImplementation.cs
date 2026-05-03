using DalApi;
using DalXml;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Globalization;

namespace Dal
{
    internal class SaleImplementation : ISale
    {
        string path = @"..\xml\sales.xml";
        public int Create(Sale item)
        {
            XElement SaleRoot = XElement.Load(path);
            int id = Config.SaleNum;
            XElement s = new XElement("Sale",
                         new XElement("SaleId", id),
                         new XElement("ProductID", item.ProductID),
                         new XElement("MinProductSale", item.MinProductSale),
                         new XElement("SumPriceSale", item.SumPriceSale),
                         new XElement("IfEveryOne", item.IfEveryOne),
                         new XElement("StartrSale", item.StartrSale.ToString("dd/MM/yyyy HH:mm:ss")),
                         new XElement("EndSale", item.EndSale.ToString("dd/MM/yyyy HH:mm:ss")));
            SaleRoot.Add(s);
            SaleRoot.Save(path);
            return id;
        }

        public Sale? Read(int id)
        {
            XElement root = XElement.Load(path);
            XElement? s = root.Elements("Sale").FirstOrDefault(x => (int?)x.Element("SaleId") == id);
            if (s == null)
                return null;
            return new Sale
            {
                SaleId = (int)s.Element("SaleId")!,
                ProductID = (int)s.Element("ProductID")!,
                MinProductSale = (int)s.Element("MinProductSale")!,
                SumPriceSale = (double)s.Element("SumPriceSale")!,
                IfEveryOne = (bool)s.Element("IfEveryOne")!,
                StartrSale = (DateTime)s.Element("StartrSale")!,
                EndSale = (DateTime)s.Element("EndSale")!
            };
        }

        public Sale? Read(Func<Sale, bool> filter)
        {
            return ReadAll().FirstOrDefault(filter);
        }

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
            XElement root = XElement.Load(path);
            var list = root.Elements("Sale").Select(s => new Sale
            {
                SaleId = (int)s.Element("SaleId")!,
                ProductID = (int)s.Element("ProductID")!,
                MinProductSale = (int)s.Element("MinProductSale")!,
                SumPriceSale = (double)s.Element("SumPriceSale")!,
                IfEveryOne = (bool)s.Element("IfEveryOne")!,
                StartrSale = DateTime.ParseExact(s.Element("StartrSale")!.Value, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                EndSale = DateTime.ParseExact(s.Element("EndSale")!.Value, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)
            });

            if (filter == null) return list.ToList();
            return list.Where(filter).ToList();
        }

        public void Update(Sale item)
        {
            XElement root = XElement.Load(path);
            XElement? s = root.Elements("Sale").FirstOrDefault(x => (int?)x.Element("SaleId") == item.SaleId);

            if (s == null) return;

            s.Element("ProductID")!.Value = item.ProductID.ToString();
            s.Element("MinProductSale")!.Value = item.MinProductSale.ToString();
            s.Element("SumPriceSale")!.Value = item.SumPriceSale.ToString();
            s.Element("IfEveryOne")!.Value = item.IfEveryOne.ToString().ToLower();
            s.Element("StartrSale")!.Value = item.StartrSale.ToString("dd/MM/yyyy HH:mm:ss");
            s.Element("EndSale")!.Value = item.EndSale.ToString("dd/MM/yyyy HH:mm:ss"); root.Save(path);
        }
        public void Delete(int id)
        {
            XElement root = XElement.Load(path);
            XElement? s = root.Elements("Sale").FirstOrDefault(x => (int?)x.Element("SaleId") == id);
            if (s != null)
            {
                s.Remove();
                root.Save(path);
            }
        }

    }
}
