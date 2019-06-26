using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestApp.BL.Controller
{
    public abstract class ControllerBase
    {
        protected void Save<T>(string fileName, T item)//List<T> item)
        {
            var formatter = new BinaryFormatter();
            using (Stream fs = new FileStream(fileName, FileMode.OpenOrCreate))//FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, item);
            }
        }

        protected T Load <T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            try
            {
                using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))//FileMode.Open, FileAccess.Read))//
                {
                    try
                    {
                        if (formatter.Deserialize(fs) is T list) //проблема дисереализации данных, необходим корректный вывод List<User> users
                        {
                            return list; //(List<User>)formatter.Deserialize(fs);
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                    catch (System.Runtime.Serialization.SerializationException)
                    {
                        return default(T);
                    }
                }
            }
            catch (System.IO.FileNotFoundException) { return default(T); }
        }
    }
}
