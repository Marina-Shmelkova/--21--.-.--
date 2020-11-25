using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsBus
{
    public class Trolleybus : Bus
    {
        public Color DopColor { private set; get; }
        /// Признак наличия штангового токоприемника
        /// </summary>
        public bool RodPantograph { private set; get; }

        public bool Flag { private set; get; }
        /// Признак наличия дверей
        /// </summary>
        public bool Doors { private set; get; }
        public bool Strip { private set; get; }
        public string DoorsForm { private set; get; }
        private DopRod Rod;

        IDoorsElements DoorsElements;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>   
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="rodPantograph">Признак наличия переднего спойлера</param>
        /// <param name="doors">Признак наличия дверей</param>

        public Trolleybus(int maxSpeed, float weight, Color mainColor, Color dopColor,
bool rodPantograph, bool doors, bool strip, int rod, int doorsForm, bool flag) :
 base(maxSpeed, weight, mainColor, 300, 100)
        {
            DopColor = dopColor;
            RodPantograph = rodPantograph;
            Rod = new DopRod(rod);
            Doors = doors;
            Strip = strip;  
            Flag = flag;        
            if (doorsForm == 1)
            {
                DoorsElements = new TriangleDoors(doorsForm, dopColor);
            }
            if (doorsForm == 2)
            {
                DoorsElements = new RectangleDoors(doorsForm, dopColor);
            }
            if (doorsForm == 3)
            {
                DoorsElements = new RoundDoors(doorsForm, dopColor);
            }
        }
        public Trolleybus(int maxSpeed, float weight, Color mainColor, Color dopColor,bool rodPantograph, bool doors, bool strip) :
             base(maxSpeed, weight, mainColor, 100, 60)
        {
            DopColor = dopColor;
            DoorsElements = new RectangleDoors(3, dopColor);
            Doors = doors;
            RodPantograph = rodPantograph;
            Strip = strip;
        }
        public void SetDopColor(Color color)
        {
            DopColor = color;         
        }
        public void SetDoors(IDoorsElements doors)
        {
            DoorsElements = doors;
            DoorsForm = DoorsElements.GetType().Name;
            switch (DoorsForm)
            {
                case "RectangleDoors":
                    DoorsElements = new RectangleDoors(3, DopColor);
                    break;
                case "RoundDoors":
                    DoorsElements = new RoundDoors(3, DopColor);
                    break;
                case "TriangleDoors":
                    DoorsElements = new TriangleDoors(3, DopColor);
                    break;
                default:
                    break;
            }

        }
        /// Отрисовка троллейбуса
        /// </summary>
        /// <param name="g"></param>
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            base.DrawTransport(g); 
            if (Strip)
            {
                //Белая полоса
                Brush brWhite = new SolidBrush(Color.White);
                g.FillRectangle(brWhite, _startPosX, _startPosY + 20, 190, 20);
            }
            if (Doors)
            {
                DoorsElements.DrawElement(g, DopColor, _startPosX, _startPosY);
            }
            if (Flag)
            {
                Rod.DrawRod(g, pen, _startPosX, _startPosY);
            }

            //Отрисовка рога
            if (RodPantograph)
            {
                g.DrawLine(pen, _startPosX + 100, _startPosY, _startPosX + 20, _startPosY - 20);
                g.DrawLine(pen, _startPosX + 20, _startPosY - 20, _startPosX + 10, _startPosY - 20);
                g.DrawLine(pen, _startPosX + 100, _startPosY, _startPosX + 20, _startPosY - 20);
            }           
        }       
    }
}
