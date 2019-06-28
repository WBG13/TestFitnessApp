using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestApp.BL.Controller
{
    public interface IDataSaver <T> where T : class
    {
        void Save(T item);
        List<T> Load();
    }
}