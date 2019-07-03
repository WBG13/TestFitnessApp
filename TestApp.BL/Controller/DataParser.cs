using System;
using System.Globalization;
using TestApp.BL.Model;

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
                if (inputedValue.Length > 0 && inputedValue != null)
                {
                    return inputedValue;
                }
                else
                {
                    Console.WriteLine($"{LanguageFormatter.Text("ShortInput")}.");
                }
            }
        }

        public DateTime ParseDateTime(string value)
        {
            while (true)
            {
                Console.WriteLine($"{LanguageFormatter.BuildString("Input", value)} (dd.mm.yyyy):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine($"{LanguageFormatter.Text("IncorrectFormat")}.");
                }
            }
        }

        public double ParseDouble(string name)
        {
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
                    Console.WriteLine($"{LanguageFormatter.Text("IncorrectFormat")}:"); 
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
                    Console.WriteLine($"Invalid input");
                }
            }
        }

        public Gender ParseGender()
        {
            while (true)
            {
                Console.WriteLine(($"{LanguageFormatter.Text("InputGender")}"));
                string value = LanguageFormatter.Text(Console.ReadLine());
                if (value == "M" || value == "W")
                {
                    return new Gender(value);
                }
                else
                {
                    Console.WriteLine($"Invalid input");
                }
            }
        }
    }
}
