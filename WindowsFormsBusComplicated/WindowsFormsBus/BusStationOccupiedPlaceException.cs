using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBus
{
    class BusStationOccupiedPlaceException : Exception
    {
        public BusStationOccupiedPlaceException() : base("Не удалось припарковать")
        { }
    }
}
