using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestApp.BL.Controller
{
    class SerializeDataSaver<T> : IDataSaver<T> where T : class
    {
        public void Save(T item)
        {
            var fileName = typeof(T) + ".dat";
            var formatter = new BinaryFormatter();
            using (Stream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        public List<T> Load()
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T) + ".dat";
            try
            {
                using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    try
                    {
                        if (formatter.Deserialize(fs) is List<T> list) //проблема дисереализации данных, необходим корректный вывод List<User> users
                        {
                            return list;
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
            catch (System.IO.FileNotFoundException) { return default(T); }
        }
    }
}
