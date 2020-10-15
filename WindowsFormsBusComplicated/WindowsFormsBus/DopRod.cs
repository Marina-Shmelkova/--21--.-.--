using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBus
{
    class DopRod
    {
        private DirectionRod rod;
        public int Rod { set => rod = (DirectionRod)value; }

        public void DrawRod(Graphics g, Pen dopcolor, float _startPosX, float _startPosY)
        {
            switch (rod)
            {
                case DirectionRod.One:
                    DrawRodOne(g, dopcolor, _startPosX, _startPosY);
                    break;

                case DirectionRod.Two:
                    DrawRodTwo(g, dopcolor, _startPosX, _startPosY);
                    break;

                case DirectionRod.Three:
                    DrawRodThree(g, dopcolor, _startPosX, _startPosY);
                    break;
            }
        }
        public DopRod(int rod_count)
        {
            Rod = rod_count;
        }
        public void DrawRodOne(Graphics g, Pen dopcolor, float x, float y)
        {
            g.DrawLine(dopcolor, x + 100, y, x + 20, y - 20);
            g.DrawLine(dopcolor, x + 20, y - 20, x + 10, y - 20);
            g.DrawLine(dopcolor, x + 100, y, x + 20, y - 20);
        }
        public void DrawRodTwo(Graphics g, Pen dopcolor, float x, float y)
        {
            DrawRodOne(g, dopcolor, x, y);

            g.DrawLine(dopcolor, x + 120, y, x + 50, y - 20);
            g.DrawLine(dopcolor, x + 50, y - 20, x + 40, y - 20);
            g.DrawLine(dopcolor, x + 120, y, x + 50, y - 20);
        }
        public void DrawRodThree(Graphics g, Pen dopcolor, float x, float y)
        {         

            DrawRodTwo(g, dopcolor, x, y);

            g.DrawLine(dopcolor, x + 140, y, x + 80, y - 20);
            g.DrawLine(dopcolor, x + 80, y - 20, x + 70, y - 20);
            g.DrawLine(dopcolor, x + 140, y, x + 80, y - 20);
        }
    }
}
