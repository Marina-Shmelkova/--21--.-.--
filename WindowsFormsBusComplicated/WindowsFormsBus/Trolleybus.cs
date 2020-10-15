using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsBus
{
    class Trolleybus
    {
        /// <summary>
        /// Левая координата отрисовки троллейбуса
        /// </summary>
        private float _startPosX;
        /// <summary>
        /// Правая кооридната отрисовки троллейбуса
        /// </summary>
        private float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int _pictureHeight;
        /// <summary>
        /// Ширина отрисовки троллейбуса
        private readonly int busWidth = 300;
        /// <summary>
        /// Высота отрисовки троллейбуса
        /// </summary>
        private readonly int busHeight = 100;
        /// Загруженность пассажирами 
        /// /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }
        /// <summary>
        /// Вес троллейбуса
        /// </summary>
        public float Weight { private set; get; }

        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { private set; get; }
        /// <summary>
        /// Цвет дверей
        /// </summary>
        public Color DopColor { private set; get; }
        /// Признак наличия штангового токоприемника
        /// </summary>
        public bool RodPantograph { private set; get; }
        /// Признак наличия дверей
        /// </summary>
        public bool Doors { private set; get; }
        private DopRod Rod;
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
bool rodPantograph, bool doors, int rod)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            RodPantograph = rodPantograph;
            Doors = doors;  
            Rod = new DopRod(rod);
        }
        /// Установка позиции троллейбуса
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            int scope = 30;
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - busWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > scope)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > scope)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - busHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        /// Отрисовка троллейбуса
        /// </summary>
        /// <param name="g"></param>
        public void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Pen penFramework = new Pen(Color.White);

            //Отрисовка рога
            if (RodPantograph)
            {

                g.DrawLine(pen, _startPosX + 100, _startPosY, _startPosX + 20, _startPosY - 20);
                g.DrawLine(pen, _startPosX + 20, _startPosY - 20, _startPosX + 10, _startPosY - 20);
                g.DrawLine(pen, _startPosX + 100, _startPosY, _startPosX + 20, _startPosY - 20);
            }
            //Отрисовка кузова

            Brush br = new SolidBrush(MainColor);
            g.FillRectangle(br, _startPosX, _startPosY, 200, 50);

            //Зеркало
            g.DrawLine(pen, _startPosX + 200, _startPosY + 5, _startPosX + 210, _startPosY + 5);
            g.DrawLine(pen, _startPosX + 210, _startPosY, _startPosX + 210, _startPosY + 15);

            //Колеса         
            Brush brBlack = new SolidBrush(Color.Black);
            g.FillEllipse(brBlack, _startPosX + 50, _startPosY + 48, 22, 22);
            g.FillEllipse(brBlack, _startPosX + 130, _startPosY + 48, 22, 22);

            //Белая полоса
            Brush brWhite = new SolidBrush(Color.White);
            g.FillRectangle(brWhite, _startPosX, _startPosY + 20, 200, 20);

            //Отрисовка дверей
            if (Doors)
            {
                Brush dopcolor = new SolidBrush(DopColor);
                g.FillRectangle(dopcolor, _startPosX + 10, _startPosY + 10, 30, 40);
                g.FillRectangle(dopcolor, _startPosX + 80, _startPosY + 10, 30, 40);
                g.FillRectangle(dopcolor, _startPosX + 150, _startPosY + 10, 30, 40);
                g.FillRectangle(dopcolor, _startPosX + 190, _startPosY + 10, 10, 30);
                //рамки
                g.DrawRectangle(penFramework, _startPosX + 10, _startPosY + 10, 30, 40);
                g.DrawRectangle(penFramework, _startPosX + 80, _startPosY + 10, 30, 40);
                g.DrawRectangle(penFramework, _startPosX + 150, _startPosY + 10, 30, 40);
                g.DrawRectangle(penFramework, _startPosX + 190, _startPosY + 10, 10, 30);//лобовое

                g.DrawLine(penFramework, _startPosX + 25, _startPosY + 10, _startPosX + 25, _startPosY + 50);//левая
                g.DrawLine(penFramework, _startPosX + 10, _startPosY + 30, _startPosX + 40, _startPosY + 30);

                g.DrawLine(penFramework, _startPosX + 95, _startPosY + 10, _startPosX + 95, _startPosY + 50);//середина
                g.DrawLine(penFramework, _startPosX + 80, _startPosY + 30, _startPosX + 110, _startPosY + 30);

                g.DrawLine(penFramework, _startPosX + 165, _startPosY + 10, _startPosX + 165, _startPosY + 50);//правая
                g.DrawLine(penFramework, _startPosX + 150, _startPosY + 30, _startPosX + 180, _startPosY + 30);
            }

            g.DrawRectangle(pen, _startPosX, _startPosY, 200, 50);
            //Отрисовка рога            
            Rod.DrawRod(g, pen, _startPosX, _startPosY);
        }
    }
}
