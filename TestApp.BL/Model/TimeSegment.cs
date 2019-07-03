using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.BL.Model
{
    [Serializable]
    class TimeSegment
    {
        /// <summary>
        /// Идентификатор
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
    }
}
