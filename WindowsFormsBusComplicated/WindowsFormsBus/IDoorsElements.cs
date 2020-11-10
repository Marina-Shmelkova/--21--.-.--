using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBus
{
    public interface IDoorsElements
    {
        int ViewDoors { set; }

        void DrawElement(Graphics g, Color dopColor, float x, float y);
    }
}
