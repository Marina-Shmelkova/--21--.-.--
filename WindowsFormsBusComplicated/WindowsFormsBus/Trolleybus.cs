using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsBus
{
    public class Trolleybus : Bus
    {
        public Color DopColor { private set; get; }
        /// Признак наличия штангового токоприемника
        /// </summary>
        public bool RodPantograph { private set; get; }
        /// Признак наличия дверей
        /// </summary>
        public bool Doors { private set; get; }
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
bool rodPantograph, bool doors, int rod, int doorsElements) :
 base(maxSpeed, weight, mainColor, 300, 100)
        {
            DopColor = dopColor;
            RodPantograph = rodPantograph;
            Doors = doors;
            Rod = new DopRod(rod);
            if (doorsElements == 1)
            {
                DoorsElements = new TriangleDoors(doorsElements, dopColor);
            }
            if (doorsElements == 2)
            {
                DoorsElements = new RectangleDoors(doorsElements, dopColor);
            }
            if (doorsElements == 3)
            {
                DoorsElements = new RoundDoors(doorsElements, dopColor);
            }
        }


        /// Отрисовка троллейбуса
        /// </summary>
        /// <param name="g"></param>
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);

            base.DrawTransport(g);

            //Отрисовка рога
            if (RodPantograph)
            {

                g.DrawLine(pen, _startPosX + 100, _startPosY, _startPosX + 20, _startPosY - 20);
                g.DrawLine(pen, _startPosX + 20, _startPosY - 20, _startPosX + 10, _startPosY - 20);
                g.DrawLine(pen, _startPosX + 100, _startPosY, _startPosX + 20, _startPosY - 20);
            }

            DoorsElements.DrawElement(g, DopColor, _startPosX, _startPosY);
            Rod.DrawRod(g, pen, _startPosX, _startPosY);
        }
    }
}
