using System;
using System.Globalization;

namespace TestApp.BL.Controller
{
    public class DataParser
    {
        private LanguageFormatter LanguageFormatter { get; set; }

        public DataParser() { }

        public void SetLanguageFormatter(LanguageFormatter languageFormatter)
        {
            LanguageFormatter = languageFormatter;
        }
        public string ParseString(string value)
        {
            while (true)
            {
                Console.WriteLine($"{LanguageFormatter.BuildString("Input", value)}:");
                var inputedValue = Console.ReadLine();
                if (inputedValue.Length > 1 && inputedValue != null)
                {
                    return inputedValue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{LanguageFormatter.BuildString("ShortInput", value)}.");
                }
            }
        }

        public DateTime ParseDateTime(string value)
        {
            value = LanguageFormatter.Text(value);
            while (true)
            {
                Console.WriteLine($"{LanguageFormatter.BuildString("Input", value)} (dd.mm.yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{LanguageFormatter.BuildString("IncorrectFormat", value)}.");
                }
            }
        }

        public double ParseDouble(string name)
        {
            name = LanguageFormatter.Text(name);
            double value;
            while (true)
            {
                Console.WriteLine($"{LanguageFormatter.BuildString("Input", name)} :");
                if (double.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{LanguageFormatter.BuildString("IncorrectFormat", name)}:"); 
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
                    Console.WriteLine($"Invalid input");
                }
            }
        }
    }
}
