using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace WindowsFormsBus
{
    public class Bus : Vehicle, IEquatable<Bus>, IComparable<Bus>, IEnumerator<object>, IEnumerable<object>
    {
        /// Ширина отрисовки троллейбуса
        private readonly int busWidth = 300;
        /// <summary>
        /// Высота отрисовки троллейбуса
        /// </summary>
        private readonly int busHeight = 100;
        /// Разделитель для записи информации по объекту в файл
        /// </summary>
        protected readonly char separator = ';';
        private int _currentIndex = -1;
        public new LinkedList<object> objectProperties = new LinkedList<object>();
        public new object Current => objectProperties.Find(_currentIndex);
        object IEnumerator<object>.Current => objectProperties.Find(_currentIndex);
        /// Загруженность пассажирами 
        /// /// Максимальная скорость
        /// </summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автобуса</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        public Bus(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }
        /// Конструкторс изменением размеров автобуса
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автобуса</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="carWidth">Ширина отрисовки автобуса</param>
        /// <param name="carHeight">Высота отрисовки автобуса</param>
        /// /// <summary>
        /// Конструктор для загрузки с файла
        /// </summary>
        /// <param name="info">Информация по объекту</param>
        public Bus(string info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }
        protected Bus(int maxSpeed, float weight, Color mainColor, int busWidth, int
       busHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.busWidth = busWidth;
            this.busHeight = busHeight;
        }
        public override void MoveTransport(Direction direction)
        {
            int scope = 40;
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
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Pen penFramework = new Pen(Color.White);
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
            
            //окно
            Brush br_yellow = new SolidBrush(Color.Yellow);
            //лобовое
            g.FillRectangle(br_yellow, _startPosX + 190, _startPosY + 10, 10, 30);
            g.DrawRectangle(penFramework, _startPosX + 190, _startPosY + 10, 10, 30);//лобовое
            g.DrawRectangle(pen, _startPosX, _startPosY, 200, 50);
        }
        public override string ToString()
        {
            return $"{MaxSpeed}{separator}{Weight}{separator}{MainColor.Name}";
        }
        /// <summary>
        /// Метод интерфейса IEquatable для класса Bus
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Bus other)
        {
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Bus busObj))
            {
                return false;
            }

            else
            {
                return Equals(busObj);
            }
        }
        public int CompareTo(Bus b)
        {
            if (MaxSpeed != b.MaxSpeed)
            {
                return MaxSpeed.CompareTo(b.MaxSpeed);
            }
            if (Weight != b.Weight)
            {
                return Weight.CompareTo(b.Weight);
            }
            if (MainColor != b.MainColor)
            {
                return MainColor.Name.CompareTo(b.MainColor.Name);
            }
            return 0;
        }
        public void Dispose() 
        { 

        }
        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < 8;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public IEnumerator<object> GetEnumerator()
        {
            return (IEnumerator<object>)objectProperties;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
