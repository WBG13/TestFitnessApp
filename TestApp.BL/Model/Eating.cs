using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.BL.Model
{
    [Serializable]
    /// <summary>
    /// Прием пищи.
    /// </summary>
    public class Eating
    {
        public DateTime Moment { get; }

        public Dictionary<Food, double> Foods { get; }

        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть null", nameof(user)); // провекрка на null;
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var foodProduct = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (foodProduct == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[foodProduct] += 1;
            }
        }

    }
}
