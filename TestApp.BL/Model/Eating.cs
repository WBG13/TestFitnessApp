using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Создание еды для определенного пользователя.
        /// </summary>
        /// <param name="user"></param>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть null", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Добавление еды с определенными параметрами.
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
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
