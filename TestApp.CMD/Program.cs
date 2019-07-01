using TestApp.BL.Controller;
using System;
using TestApp.BL.Model;
using System.Globalization;
using System.Resources;

namespace TestApp.CMD
{
    class Program
    {
        public static void Main(string[] args)
        {
            var parser = new DataParser();
            CultureInfo culture = parser.ParseCulture();
            var resourceManager = new ResourceManager("TestApp.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));
            //Console.WriteLine(resourceManager.GetString("EnterName", culture));

            //var name = Console.ReadLine();


            var name = parser.ParseString(resourceManager.GetString("Name", culture));
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                var gender = parser.ParseString("пол");
                var birthDate = parser.ParseDateTime("дату рождения");
                var weight = parser.ParseDouble("вес");
                var height = parser.ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотети сделать?");
                Console.WriteLine("E - ввессти прием пищи.");
                Console.WriteLine("A - ввести упражнение.");
                Console.WriteLine("Q - для выхода из порграммы.");
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating(parser);
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise(parser);
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                    default: break;
                }
                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise(DataParser parser)
        {
            var name = parser.ParseString("название упражнения");
            var energy = parser.ParseDouble("расход энергии в минуту");
            var begin = parser.ParseDateTime("начало упражнений");
            var finish = parser.ParseDateTime("завершение упражнения");
            var activity = new Activity(name, energy);
            return (begin, finish, activity);
        }

        private static (Food Food, double Weight) EnterEating(DataParser parser)
        {
            var productName = parser.ParseString("имя продукта");
            var calories = parser.ParseDouble("калории");
            var prots = parser.ParseDouble("протеины");
            var fats = parser.ParseDouble("жиры");
            var carbs = parser.ParseDouble("углеводы");
            var weight = parser.ParseDouble("вес порции");
            Food product = new Food(productName, calories, prots, fats, carbs);

            return (Food: product, Weight: weight); 
        }
    }
}