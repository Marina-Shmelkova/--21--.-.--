using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBus
{
    public class BusStation<T, R> where T : class, ITransport where R : class, IDoorsElements
    {
        /// <summary>
        /// Массив объектов, которые храним
        /// </summary>
        public readonly T[] _places;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Размер парковочного места (ширина)
        /// </summary>
        private readonly int _placeSizeWidth = 260;
        /// <summary>
        /// Размер парковочного места (высота)
        /// </summary>
        private readonly int _placeSizeHeight = 110;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth">Рамзер парковки - ширина</param>
        /// <param name="picHeight">Рамзер парковки - высота</param>
        public BusStation(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _places = new T[width * height];
            pictureWidth = picWidth;
            pictureHeight = picHeight;

        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на парковку добавляется автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="car">Добавляемый автомобиль</param>
        /// <returns></returns>
        public static bool operator +(BusStation<T, R> p, T bus)
        {
            for (int i = 0; i < p._places.Length; i++)
            {
                if (p._places[i] == null)
                {
                    bus.SetPosition(10 + p._placeSizeWidth * (int)(i / (int)(p.pictureHeight / p._placeSizeHeight)), 25 + p._placeSizeHeight * (int)(i % (int)(p.pictureHeight / p._placeSizeHeight)), p.pictureWidth, p.pictureHeight);
                    p._places[i] = bus;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: с парковки забираем автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="index">Индекс места, с которого пытаемся извлечь объект</param>
        /// <returns></returns>
        public static T operator -(BusStation<T, R> p, int index)
        {
            if ((index < p._places.Length) && (index >= 0))
            {
                T bus = p._places[index];
                p._places[index] = null;
                return bus;
            }
            return null;
        }

        public static bool operator >(BusStation<T, R> p, int index)
        {
            return p.count_operator() > index;
        }
        public static bool operator <(BusStation<T, R> p, int index)
        {
            return p.count_operator() < index;
        }

        public int count_operator()
        {
            int count = 0;
            for (int i = 0; i < _places.Length; ++i)
            {
                if (_places[i] != null)
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Length; i++)
            {
                _places[i]?.DrawTransport(g);
            }
        }
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            for (int i = 0; i < pictureWidth / _placeSizeWidth; i++)
            {
                for (int j = 0; j < pictureHeight / _placeSizeHeight + 1; ++j)
                {//линия рамзетки места
                    g.DrawLine(pen, i * _placeSizeWidth + 3, j * _placeSizeHeight + 3, i * _placeSizeWidth + _placeSizeWidth / 2 + 90, j * _placeSizeHeight + 3);
                }
                g.DrawLine(pen, i * _placeSizeWidth + 3, 3, i * _placeSizeWidth + 3, (pictureHeight / _placeSizeHeight) * _placeSizeHeight + 3);
            }
        }
    }
}
