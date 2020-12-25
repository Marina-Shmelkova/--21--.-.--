using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBus
{
    public class BusStation<T, R> : IEnumerator<T>, IEnumerable<T>
        where T : class, ITransport where R : class, IDoorsElements
    {
        /// <summary>
        /// Массив объектов, которые храним
        /// </summary>
        public readonly List<T> _places;
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
        /// Максимальное количество мест на парковке
        /// </summary>
        private readonly int _maxCount;
        /// Текущий элемент для вывода через IEnumerator (будет обращаться по своему индексу к ключу словаря, по которму будет возвращаться запись)
        /// </summary>
        private int _currentIndex;
        public T Current => _places[_currentIndex];
        object IEnumerator.Current => _places[_currentIndex];
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth">Рамзер парковки - ширина</param>
        /// <param name="picHeight">Рамзер парковки - высота</param>
        public BusStation(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _places = new List<T>();
            pictureWidth = picWidth;
            pictureHeight = picHeight;
            _maxCount = width * height;
            _currentIndex = -1;

        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на парковку добавляется автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="car">Добавляемый автомобиль</param>
        /// <returns></returns>
        public static bool operator +(BusStation<T,R> b, T bus)
        {
            if (b._places.Count >= b._maxCount)
            {
                throw new BusStationOverflowException();
            }
            if (b._places.Contains(bus))
            {
                throw new BusStationAlreadyHaveException();
            }
            b._places.Add(bus);
            return true;
        }
        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: с парковки забираем автомобиль
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="index">Индекс места, с которого пытаемся извлечь объект</param>
        /// <returns></returns>
        public static T operator -(BusStation<T, R> b, int index)
        {
            if (index < -1 || index > b._places.Count)
            {
                throw new BusStationNotFoundException(index);
            }
            T bus = b._places[index];
            b._places.RemoveAt(index);
            return bus;
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
            for (int i = 0; i < _places.Count; ++i)
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
            for (int i = 0; i < _places.Count; ++i)
            {
                _places[i].SetPosition(5 + i / (pictureHeight / _placeSizeHeight) * _placeSizeWidth + 5, i % (pictureHeight / _placeSizeHeight) *
               _placeSizeHeight + 27, pictureWidth, pictureHeight);
                _places[i].DrawTransport(g);
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
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _places.Count)
                {
                    return _places[index];
                }
                return null;
            }
        }       
        public void ClearPlaces()
        {
            _places.Clear();
        }
        /// <summary>
        /// Сортировка автомобилей на парковке
        /// </summary>
        public void Sort() => _places.Sort((IComparer<T>)new BusComparer());
        /// <summary>
        /// Метод интерфейса IEnumerator, вызываемый при удалении объекта
        /// </summary>
        public void Dispose()
        {
        }
        /// <summary>
        /// Метод интерфейса IEnumerator для перехода к следующему элементу или началу коллекции
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (_currentIndex + 1 >= _places.Count)
            {
                return false;
            }
            _currentIndex++;
            return true;
        }
        /// <summary>
        /// Метод интерфейса IEnumerator для сброса и возврата к началу коллекции
        /// </summary>
        public void Reset()
        {
            _currentIndex = -1;
        }
        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}
