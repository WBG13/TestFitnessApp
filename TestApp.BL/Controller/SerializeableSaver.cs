using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestApp.BL.Controller
{
    class SerializeableSaver : IDataSaver
    {
        public void Save<T>(List<T> item) where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;
            using (Stream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        public List<T> Load <T>() where T : class
        {
        var formatter = new BinaryFormatter();
        var fileName = typeof(T).Name;
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                try
                {
                    if (fs.Length > 0 && formatter.Deserialize(fs) is List<T> items)
                    {
                        return items;
                    }
                    else
                    {
                        return new List<T>();
                    }
                }
                catch (System.Runtime.Serialization.SerializationException)
                {
                    return new List<T>();
                }
            }
        }
    }
}
