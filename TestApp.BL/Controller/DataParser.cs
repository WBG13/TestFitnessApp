using System;
using System.Globalization;

namespace TestApp.BL.Controller
{
    public class DataParser
    {
        public string ParseString(string value)
        {
            while (true)
            {
                Console.WriteLine($"Введите {value}:");
                var inputedValue = Console.ReadLine();
                if (inputedValue.Length > 1 || inputedValue != null)

                {
                    return inputedValue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Введенные данные не могут быть короче двух символов или равны null. Введено {value}.");
                }
            }
        }

        public DateTime ParseDateTime(string value)
        {
            while (true)
            {
                Console.WriteLine($"Введите {value} (dd.mm.yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Не верный формат {value}.");
                }
            }
        }

        public double ParseDouble(string name)
        {
            double value;
            while (true)
            {
                Console.WriteLine($"Введите {name}:");
                if (double.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Не верный формат {name}:");
                }
            }
        }

        public CultureInfo ParseCulture()
        {
            while (true)
            {
                Console.WriteLine($"Enter language (ru or us):");
                string values = Console.ReadLine();
                if (values == "ru")
                {
                    return CultureInfo.CreateSpecificCulture("ru-ru");
                } 
                else if(values == "us")
                {
                    return CultureInfo.CreateSpecificCulture("en-us");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Не верный ввод:");
                }
            }
        }
    }
}
