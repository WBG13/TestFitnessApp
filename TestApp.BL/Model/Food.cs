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
        public string Name { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbogydrates { get; }

        /// <summary>
        /// Калории за 100 г. продукта.
        /// </summary>
        public double Calories { get; }

        //private double CaloriesForOneGramm { get { return Calories / 100.0; } } // Приватное свойство
        //private double ProteinsForOneGramm { get { return Proteins / 100.0; } } // Приватное свойство
        //private double FatsForOneGramm { get { return Fats / 100.0; } } // Приватное свойство
        //private double CarbogydratesForOneGramm { get { return Carbogydrates / 100.0; } } // Приватное свойство

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
