using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBus
{
    public class BusComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {

            if (x is Trolleybus && y is Trolleybus)
            {
                return ComparerTrolleybus((Trolleybus)x, (Trolleybus)y);
            }
            if (x is Trolleybus && y is Bus)
            {
                return -1;
            }
            if (x is Bus && y is Trolleybus)
            {
                return 1;
            }
            if (x is Bus && y is Bus)
            {
                return ComparerBus((Bus)x, (Bus)y);
            }
            return 0;

        }
        private int ComparerBus(Bus x, Bus y)
        {
            if (x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }
        private int ComparerTrolleybus(Trolleybus x, Trolleybus y)
        {
            var res = ComparerBus(x, y);
            if (res != 0)
            {
                return res;
            }
            if (x.DopColor != y.DopColor)
            {
                return x.DopColor.Name.CompareTo(y.DopColor.Name);
            }
            if (x.RodPantograph != y.RodPantograph)
            {
                return x.RodPantograph.CompareTo(y.RodPantograph);
            }
            if (x.Doors != y.Doors)
            {
                return x.Doors.CompareTo(y.Doors);
            }
            if (x.Strip != y.Strip)
            {
                return x.Strip.CompareTo(y.Strip);
            }
            return 0;
        }

    }
}
