using System.Collections.Generic;
using System.Linq;
using TestApp.BL.Model;

namespace TestApp.BL.Controller
{
    public class EatingController : ControllerBase
    {
        //private const string FOOD_FILE_NAME = "food.dat";
        //private const string EATING_FILE_NAME = "eating.dat";

        private readonly User user;

        public List<Food> Foods { get; }

        public Eating Eating { get; }

        public EatingController(User user)
        {
            Foods = GetAllFoods();
            Eating = GetEating();
        }

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
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>() { Eating});
        }
    }
}
