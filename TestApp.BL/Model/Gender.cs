using System;

namespace TestApp.BL.Model
{
    ///<summary>
    ///Пол.
    ///</summary>
    [Serializable]
    public class Gender
    {
        #region Свойства
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        ///<summary>
        ///Название.
        ///</summary>
        public string Name { get; set; }
        #endregion
        public Gender() { }
        ///<summary>
        ///Создать новый пол.
        ///</summary>
        ///<param name="name">Имя пола</param>
        public Gender(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
