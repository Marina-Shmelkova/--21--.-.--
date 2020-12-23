using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBus
{
    /// <summary>
    /// Класс-ошибка "Если на парковке уже есть автомобиль с такими же характеристиками"
    /// </summary>
    public class BusStationAlreadyHaveException : Exception
    {
        public BusStationAlreadyHaveException() : base("На парковке уже есть такой транспорт") { }
    }
}
