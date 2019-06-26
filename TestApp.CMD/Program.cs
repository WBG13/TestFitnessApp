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
            if (userController.IsNewUser)
            {
                Console.WriteLine("������� ���:");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("���");
                var height = ParseDouble("����");
                userController.SetNewUserData(name, gender, birthDate, weight, height);

            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("��� �� ������ �������?");
            Console.WriteLine("E - ������� ����� ����.");
            var key = Console.ReadKey();

            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
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

        private static DateTime ParseDateTime() {
            while (true)
            {
                Console.WriteLine("������� ���� �������� (dd.mm.yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("�� ������ ������ ����.");
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