using System;
using System.Collections.Generic;

namespace TestApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        #region Свойства
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название упражнения.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список упражнений.
        /// </summary>
        public virtual ICollection<Exercise> Exercises { get; set; }
        /// <summary>
        /// Количество сжигаемых калорий в минуту.
        /// </summary>
        public double CaloriesPerMinute { get; set; }
        #endregion

        public Activity() { }

        /// <summary>
        /// Создание упражнения.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="caloriesPerMinute"></param>
        public Activity(string name, double caloriesPerMinute)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}