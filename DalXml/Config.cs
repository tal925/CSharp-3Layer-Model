
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DalXml
{
    internal static class Config
    {
        private static string dataConfig = "data-config";

        public static int ProductNum
        {
            get
            {
                string path = @"..\xml\data-config.xml";
                XElement root = XElement.Load(path);
                int currentId = int.Parse(root.Element("ProductNum").Value);
                root.Element("ProductNum").Value = (currentId + 1).ToString();
                root.Save(path);
                return currentId;
            }
        }

        public static int SaleNum
        {
            get
            {
                string path = @"..\xml\data-config.xml";
                XElement root = XElement.Load(path);
                int currentId = int.Parse(root.Element("SaleNum").Value);
                root.Element("SaleNum").Value = (currentId + 1).ToString();
                root.Save(path);
                return currentId;
            }
        }
    }
}