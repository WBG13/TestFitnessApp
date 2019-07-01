using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.BL.Model
{
    [Serializable]
    public class Food
    {
        #region Свойства
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbogydrates { get; set; }
        /// <summary>
        /// Калории за 100 г. продукта.
        /// </summary>
        public double Calories { get; set; }
        #endregion
        public Food() { }

        public Food(string name) : this (name, 0, 0, 0, 0){}

        public Food(string name, double calories, double proteins, double fats, double carbogydrates)
        {
            //TODO:Проверка
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbogydrates = carbogydrates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
