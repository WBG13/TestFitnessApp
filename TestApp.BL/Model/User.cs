﻿using System;

namespace TestApp.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// Пол.
        /// </summary>
        
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>

        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес.
        /// </summary>

        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>

        public double Height { get; set; }

        //DateTime nowDate = DateTime.Today;
        //int age = nowDate.Year - BirthDate.Year;
        //if(BirthDate > nowDate.AddYears(-age)) age--;

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string name, 
                    Gender gender,
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Пол пользователя не может быть пустым или null.");
            }
            if (birthDate < DateTime.Parse("01.01.1900") || BirthDate>= DateTime.Now)
            {
                throw new ArgumentNullException("Невозможная дата рождения.", nameof(birthDate.ToString));
            }
            if(weight <= 0)
            {
                throw new ArgumentNullException("Вес пользователя не может быть меньше либо равен нулю.", nameof(Weight.ToString));
            }
            if(height <= 0)
            {
                throw new ArgumentNullException("Рост пользователя не может быть меньше либо равен нулю.", nameof(Height.ToString));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(userName));
            }
            this.Name = userName;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}