using System;

namespace TestApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        #region Свойства
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Время начала упражнения.
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// Время окончания упражнения.
        /// </summary>
        public DateTime Finish { get; set; }
        /// <summary>
        /// Идентификатор упражнения.
        /// </summary>
        public int ActivityId { get; set; }
        /// <summary>
        /// Упражнение.
        /// </summary>
        public virtual Activity Activity { get; set; }
        /// <summary>
        /// Идентификатор польователя.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public virtual User User { get; set; }
        #endregion
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            //Check

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
