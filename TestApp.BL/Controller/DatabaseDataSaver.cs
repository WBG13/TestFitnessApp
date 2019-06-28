using System;
using TestApp.BL.Model;
using System.Linq;
using System.Collections.Generic;

namespace TestApp.BL.Controller
{
    class DatabaseDataSaver<T> : IDataSaver<T> where T : class
    {
        public List<T> Load()
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(l => true).ToList();
                return result;
            }
        }

        public void Save(T item)
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }
    }
}
