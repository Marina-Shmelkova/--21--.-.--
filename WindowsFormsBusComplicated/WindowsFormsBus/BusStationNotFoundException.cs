using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBus
{
    /// <summary>
    /// Класс-ошибка "Если не найден автомобиль по определенному месту"
    /// </summary>
    public class BusStationNotFoundException : Exception
    {
        public BusStationNotFoundException(int i) : base("Не найден автобус по месту "
       + i)
        { }
    }
}
