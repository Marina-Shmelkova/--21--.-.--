using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBus
{
    class TriangleDoors : IDoorsElements
    {
        private ViewDoorsEnum viewForm;

        public int ViewDoors { set => viewForm = (ViewDoorsEnum)value; }

        public Color DopColor { private set; get; }

        public TriangleDoors(int digit, Color dopColor)
        {
            ViewDoors = digit;
            DopColor = dopColor;
        }

        public void DrawElement(Graphics g, Color dopColor, float x, float y)
        {
            Brush brush = new SolidBrush(dopColor);
            Pen penFramework = new Pen(Color.White);

            PointF doorsLeftOne = new PointF(x + 10, y + 50);
            PointF doorsLeftTwo = new PointF(x + 25, y + 10);
            PointF doorsLeftThree = new PointF(x + 40, y + 50);
            PointF[] pointsleft = { doorsLeftOne, doorsLeftTwo, doorsLeftThree};
            g.FillPolygon(brush, pointsleft);

            PointF doorsMiddleOne = new PointF(x + 80, y + 50);
            PointF doorsMiddleTwo = new PointF(x + 95, y + 10);
            PointF doorsMiddleThree = new PointF(x + 110, y + 50);
            PointF[] pointsmiddle = { doorsMiddleOne, doorsMiddleTwo, doorsMiddleThree };
            g.FillPolygon(brush, pointsmiddle);

            PointF doorsRightOne = new PointF(x + 150, y + 50);
            PointF doorsRightTwo = new PointF(x + 165, y + 10);
            PointF doorsRightThree = new PointF(x + 180, y + 50);
            PointF[] pointsright = { doorsRightOne, doorsRightTwo, doorsRightThree };
            g.FillPolygon(brush, pointsright);

            //Рамки


            g.DrawLine(penFramework, x + 25, y + 11, x + 25, y + 49);//левая
            g.DrawLine(penFramework, x + 10, y + 30, x + 40, y + 30);

            g.DrawLine(penFramework, x + 95, y + 11, x + 95, y + 49);//середина
            g.DrawLine(penFramework, x + 80, y + 30, x + 110, y + 30);

            g.DrawLine(penFramework, x + 165, y + 11, x + 165, y + 49);//правая
            g.DrawLine(penFramework, x + 150, y + 30, x + 180, y + 30);
        }
    }
}