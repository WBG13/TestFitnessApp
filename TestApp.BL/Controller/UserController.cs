using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.BL.Model;

namespace TestApp.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Пользователи приложения.
        /// </summary>
        public List<User> Users { get; }
        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }
        /// <summary>
        /// Является ли текущий пользователь новым.
        /// </summary>
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            Users = GetUsersDate();
            CurrentUser = Users.Find(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }
        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns>Список пользователей.</returns>
        private List<User> GetUsersDate()
        {
            return Load<User>() ?? new List<User>();
        }

        public void SetNewUserData(Gender gender, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = gender;
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            Save();
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save(Users);
        }
    }
}
