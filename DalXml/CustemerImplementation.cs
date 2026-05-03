using DalApi;
using DO;
using System.Xml.Serialization; 

namespace Dal
{
    internal class CustemerImplementation : ICustemer
    {
        string path = @"..\xml\custemers.xml";
        private List<Custemer> Load()
        {
            if (!File.Exists(path)) return new List<Custemer>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Custemer>));
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return (List<Custemer>)serializer.Deserialize(stream)!;
            }
        }
        private void Save(List<Custemer> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Custemer>));
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(stream, list);
            }
        }

        public int Create(Custemer item)
        {
            var list = Load();
            list.Add(item);
            Save(list);
            return item.CustemerID;
        }

        public List<Custemer> ReadAll(Func<Custemer, bool>? filter = null)
        {
            var list = Load();
            return filter == null ? list : list.Where(filter).ToList();
        }

        public Custemer? Read(int id) => Load().FirstOrDefault(c => c.CustemerID == id);

        public Custemer? Read(Func<Custemer, bool>? filter) => Load().FirstOrDefault(filter!);

        public void Update(Custemer item)
        {
            var list = Load();
            int index = list.FindIndex(c => c.CustemerID == item.CustemerID);
            if (index == -1) return;
            list[index] = item;
            Save(list);
        }

        public void Delete(int id)
        {
            var list = Load();
            list.RemoveAll(c => c.CustemerID == id);
            Save(list);
        }
    }
}