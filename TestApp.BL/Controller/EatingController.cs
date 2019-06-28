using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TestApp.BL.Model;

namespace TestApp.BL.Controller
{
    public class EatingController : ControllerBase<Eating>
    {
        private const string FOOD_FILE_NAME = "food.dat";
        private const string EATING_FILE_NAME = "eating.dat";
        private readonly User user;
        public List<Food> Foods { get; }

        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть указан null", nameof(user));

            Foods = GetAllFoods();

            Eating = GetEating();
        }

        //public bool Add(string foodName, double weight)
        //{
        //    var food = Foods.SingleOrDefault(n => n.Name == foodName);
        //    if (Eating != null)
        //    {
        //        Eating.Add(food, weight);
        //        Save();
        //        return true;
        //    }
        //    return false;
        //}

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(n => n.Name == food.ToString());
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return Load().First();
        }

        private List<Food> GetAllFoods()
        {
            return Load().First();
            //var formatter = new BinaryFormatter();
            //try
            //{
            //    using (var fs = new FileStream("users.dat", FileMode.Open, FileAccess.Read))//, FileMode.OpenOrCreate))
            //    {
            //        try
            //        {
            //            if (formatter.Deserialize(fs) is List<Food> food) //проблема дисереализации данных, необходим корректный вывод List<User> users
            //            {
            //                return food; //(List<User>)formatter.Deserialize(fs);
            //            }
            //            else
            //           {
            //               return new List<Food>();
            //            }
            //        }
            //       catch (System.Runtime.Serialization.SerializationException e)
            //        {
            //            return new List<Food>();
            //         }
            //    }
            // }
            //  catch (System.IO.FileNotFoundException e) { return new List<Food>(); }
        }

        private void Save()
        {
            Save();
            //Save(FOOD_FILE_NAME, Foods);
            //Save(EATING_FILE_NAME, Eating);
        }
    }
}
