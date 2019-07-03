using System;
using System.Resources;
using TestApp.BL.Model;

namespace TestApp.BL.Controller
{
    public class MessageInteractionController
    {
        DataParser parser;
        UserController userController;
        EatingController eatingController;
        ExerciseController exerciseController;
        LanguageFormatter languageFormatter;

        public void InitialiseData(ResourceManager resourceManager)
        {
            parser = new DataParser();
            languageFormatter = new LanguageFormatter(resourceManager, parser.ParseCulture());
            parser.SetLanguageFormatter(languageFormatter);

            Console.WriteLine(languageFormatter.Text("Hello"));

            var name = parser.ParseString("Name");
            userController = new UserController(name);

            eatingController = new EatingController(userController.CurrentUser);
            exerciseController = new ExerciseController(userController.CurrentUser);


            if (userController.IsNewUser)
            {
                AddNewUser();
                userController.Save();
            }
        }

        public void InputCommand()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(languageFormatter.Text("WhatYouWantToDo"));
                Console.WriteLine($"E - {languageFormatter.Text(("EnterMealTime"))}.");
                Console.WriteLine($"A - {languageFormatter.Text(("IntroduceAnExercise"))}.");
                Console.WriteLine($"F - show all foods");
                Console.WriteLine($"G - show all exercise.");
                Console.WriteLine($"Q - {languageFormatter.Text(("Quit"))}.");
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
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.F:
                        Console.Clear();
                        if (exerciseController.Exercises.Count != 0)
                        {
                            foreach (var item in exerciseController.Exercises)
                            {
                                Console.WriteLine($"\t{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Exercises list are empty");
                        }
                        break;
                    case ConsoleKey.G:
                        Console.Clear();
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
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

        public void StartMainController(ResourceManager resourceManager)
        {
            InitialiseData(resourceManager);
            Console.Clear();
            //Console.WriteLine(languageFormatter.Text("PressAnyButton"));
            //Console.ReadLine();
            InputCommand();
        }

        private (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            var name = parser.ParseString("ExerciseName");
            var energy = parser.ParseDouble("PowerConsumptionPerMinute");
            var begin = parser.ParseDateTime("BeginningOfExercises");
            var finish = parser.ParseDateTime("CompletionOfExercise");
            var activity = new Activity(name, energy);
            return (begin, finish, activity);
        }

        private (Food Food, double Weight) EnterEating()
        {
            var productName = parser.ParseString("ProductName");
            var calories = parser.ParseDouble("Calories");
            var prots = parser.ParseDouble("Proteins");
            var fats = parser.ParseDouble("Fats");
            var carbs = parser.ParseDouble("Сarbohydrates");
            var weight = parser.ParseDouble("PortionWeight");
            Food product = new Food(productName, calories, prots, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private void AddNewUser()
        {
            var gender = parser.ParseGender();
            var birthDate = parser.ParseDateTime("BirthDate");
            var weight = parser.ParseDouble("Weight");
            var height = parser.ParseDouble("Height");
            userController.SetNewUserData(gender, birthDate, weight, height);
        }
    }
}
