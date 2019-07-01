using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        ///<summary>
        ///Создать новый пол.
        ///</summary>
        ///<param name="name">Имя пола</param>
        public Gender() { }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя поля не может быть пустым или null.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
