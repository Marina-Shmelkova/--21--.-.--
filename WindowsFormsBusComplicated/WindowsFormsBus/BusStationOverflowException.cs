using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBus
{
    /// <summary>
    /// Класс-ошибка "Если на парковке уже заняты все места"
    /// </summary>
    public class BusStationOverflowException : Exception
    {
        public BusStationOverflowException() : base("На парковке нет свободных мест")
        { }

    }
}
