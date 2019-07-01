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
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var culture2 = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("TestApp.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture2));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("������� ���:");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("���� ��������");
                var weight = ParseDouble("���");
                var height = ParseDouble("����");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("��� �� ������ �������?");
                Console.WriteLine("E - ������� ����� ����.");
                Console.WriteLine("A - ������ ����������.");
                Console.WriteLine("Q - ��� ������ �� ���������.");
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} � {item.Start.ToShortTimeString()} �� {item.Finish.ToShortTimeString()}");
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

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("������� �������� ����������:");
            var name = Console.ReadLine();
            var energy = ParseDouble("������ ������� � ������");
            var begin = ParseDateTime("������ ����������");
            var finish = ParseDateTime("���������� ����������");
            var activity = new Activity(name, energy);
            return (begin, finish, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("������� ��� ��������:");
            var productName = Console.ReadLine();

            var calories = ParseDouble("�������");
            var prots = ParseDouble("��������");
            var fats = ParseDouble("����");
            var carbs = ParseDouble("��������");
            var weight = ParseDouble("��� ������");
            Food product = new Food(productName, calories, prots, fats, carbs);

            return (Food: product, Weight: weight); 
        }

        private static DateTime ParseDateTime(string value) {
            while (true)
            {
                Console.WriteLine($"������� {value} (dd.mm.yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine($"�� ������ ������ {value}.");
                }
            }
        }

        private static double ParseDouble(string name)
        {
            double value;
            while (true)
            {
                Console.WriteLine($"������� {name}:");
                if (double.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"�� ������ ������ {name}:");
                }
            }
        }
    }
}