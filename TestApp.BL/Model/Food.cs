using System;

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
        /// <summary>
        /// Создание еды на основе имени с нудевыми параметрами.
        /// </summary>
        /// <param name="name"></param>
        public Food(string name) : this (name, 0, 0, 0, 0){}
        /// <summary>
        /// Создание новой еды с параметрами.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="calories"></param>
        /// <param name="proteins"></param>
        /// <param name="fats"></param>
        /// <param name="carbogydrates"></param>
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
