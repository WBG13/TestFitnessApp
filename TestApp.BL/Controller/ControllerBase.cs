using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestApp.BL.Controller
{
    public abstract class ControllerBase <T> where T: class
    {
        protected IDataSaver<T> manager = new SerializeDataSaver<T>();

        protected void Save(T item)
        {
            manager.Save(item);
        }

        protected List<T> Load()
        {
            return manager.Load();
        }
    }
}
