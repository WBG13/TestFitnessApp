using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TestApp.BL.Model;

namespace TestApp.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";
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
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersDate();

            //foreach (User t in Users) {
            //    Console.WriteLine($"_____________________________");
            //    Console.WriteLine($"Изъят пользователь = {t.Name}");
            //    Console.WriteLine($"Изъят возраст = {t.Age}");
            //    Console.WriteLine($"Изъят пол = {t.Gender}");
            //    Console.WriteLine($"Изъят рост = {t.Height}");
            //    Console.WriteLine($"Изъят вес = {t.Weight}");
            //    Console.WriteLine($"_____________________________");
            //}

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                //Save();
            }
        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns>Список пользователей.</returns>
        private List<User> GetUsersDate()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();

            //var formatter = new BinaryFormatter();

            //stream = new FileStream(@"E:\ExampleNew.txt", FileMode.Open, FileAccess.Read);
            //Tutorial objnew = (Tutorial)formatter.Deserialize(stream);
            //try {
            //    using (var fs = new FileStream("users.dat", FileMode.Open, FileAccess.Read))//, FileMode.OpenOrCreate))
            //     {
            //        try
            //        {
            //            if (formatter.Deserialize(fs) is List<User> users) //проблема дисереализации данных, необходим корректный вывод List<User> users
            //            {
            //                return users; //(List<User>)formatter.Deserialize(fs);
            //            }
            //            else
            //            {
            //                return new List<User>();
            //            }
            //        }
            //        catch (System.Runtime.Serialization.SerializationException e)
            //        {
            //            return new List<User>();
            //        }
            //    }
            //} catch (System.IO.FileNotFoundException e) { return new List<User>(); }
        }

        public void SetNewUserData(string userName, string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //TODO: Проверка 
            //CurrentUser.Name = userName;
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            //Users.Add(CurrentUser);
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
            //var formatter = new BinaryFormatter();

            //using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            //using (Stream fs = new FileStream("users.dat", FileMode.Create, FileAccess.Write))
            //{

            //    foreach (User t in Users)
            //    {
            //        Console.WriteLine($">_____________________________");
            //        Console.WriteLine($"Изъят пользователь = {t.Name}");
            //        Console.WriteLine($"Изъят возраст = {t.Age}");
            //        Console.WriteLine($"Изъят пол = {t.Gender}");
            //        Console.WriteLine($"Изъят рост = {t.Height}");
            //        Console.WriteLine($"Изъят вес = {t.Weight}");
            //        Console.WriteLine($">_____________________________");
            //    }

            //    formatter.Serialize(fs, Users);
            //}
            
            //Tutorial obj = new Tutorial();
            //obj.ID = 1;
            //obj.Name = ".Net";

            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream(@"E:\ExampleNew.txt", FileMode.Create, FileAccess.Write);

            //formatter.Serialize(stream, obj);
            //stream.Close();

            //stream = new FileStream(@"E:\ExampleNew.txt", FileMode.Open, FileAccess.Read);
            //Tutorial objnew = (Tutorial)formatter.Deserialize(stream);
        }
    }
}
