using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.BL.Model;

namespace TestApp.BL.Controller
{
    public class ExerciseController : ControllerBase <Exercise>
    {
        private readonly User user;
        private const string EXERCISE_FILE_NAME = "exercise.dat"; 
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
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
            var list = Load<List<Exercise>>(EXERCISE_FILE_NAME) ?? new List<Exercise>();
            return list;
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        private void Save()
        {
            Save(EXERCISE_FILE_NAME, Exercises);
        }
    }
}
