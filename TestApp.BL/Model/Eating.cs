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
        #region Свойства
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime Moment { get; set; }
        /// <summary>
        /// Список употребляемой еды.
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }
        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }
        #endregion
        public Eating() { }

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
