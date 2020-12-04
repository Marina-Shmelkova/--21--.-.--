using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBus
{
    class RectangleDoors : IDoorsElements
    {
        private ViewDoorsEnum viewForm;

        public int ViewDoors { set => viewForm = (ViewDoorsEnum)value; }

        public Color DopColor { private set; get; }

        public RectangleDoors(int digit, Color dopColor)
        {
            ViewDoors = digit;
            DopColor = dopColor;
        }

        public void DrawElement(Graphics g, Color dopColor, float _startPosX, float _startPosY)
        {
            switch (viewForm)
            {
                case ViewDoorsEnum.One:
                    DrawOne(g, dopColor, _startPosX, _startPosY);
                    break;

                case ViewDoorsEnum.Two:
                    DrawTwo(g, dopColor, _startPosX, _startPosY);
                    break;

                case ViewDoorsEnum.Three:
                    DrawThree(g, dopColor, _startPosX, _startPosY);
                    break;
            }
        }
        public void DrawOne(Graphics g, Color dopColor, float x, float y)
        {
            Brush brush = new SolidBrush(dopColor);
            Pen penFramework = new Pen(Color.White);
            g.FillRectangle(brush, x + 80, y + 10, 30, 40);
            //Рамки

            g.DrawLine(penFramework, x + 95, y + 10, x + 95, y + 49);//середина
            g.DrawLine(penFramework, x + 80, y + 30, x + 110, y + 30);

        }

        public void DrawTwo(Graphics g, Color dopColor, float x, float y)
        {
            Brush brush = new SolidBrush(dopColor);
            Pen penFramework = new Pen(Color.White);

            g.FillRectangle(brush, x + 10, y + 10, 30, 40);
            g.FillRectangle(brush, x + 150, y + 10, 30, 40);

            //Рамки

            g.DrawLine(penFramework, x + 25, y + 10, x + 25, y + 49);//левая
            g.DrawLine(penFramework, x + 10, y + 30, x + 40, y + 30);

            g.DrawLine(penFramework, x + 165, y + 10, x + 165, y + 49);//правая
            g.DrawLine(penFramework, x + 150, y + 30, x + 180, y + 30);
        }
        public void DrawThree(Graphics g, Color dopColor, float x, float y)
        {
            Brush brush = new SolidBrush(dopColor);
            Pen penFramework = new Pen(Color.White);
            DrawOne(g, dopColor, x, y);
            DrawTwo(g, dopColor, x, y);
        }
    }
}
