﻿using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.BL.Model;

namespace TestApp.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private readonly User user;

        public List<Exercise> Exercises { get; set; }

        public List<Activity> Activities { get; set; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if(act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
