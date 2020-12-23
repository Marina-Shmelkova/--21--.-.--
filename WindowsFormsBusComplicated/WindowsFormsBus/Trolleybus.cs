using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsBus
{
    public class Trolleybus : Bus, IEquatable<Trolleybus>, IComparable<Trolleybus>, IEnumerable<object>, IEnumerator<object>
 
    {
        public Color DopColor { private set; get; }
        /// Признак наличия штангового токоприемника
        /// </summary>
        public bool RodPantograph { private set; get; }
        public bool Doors { private set; get; }
        public bool Strip { private set; get; }
        public int count_Doors { private set; get; }
        public string DoorsForm { private set; get; }
        private int _currentIndex = -1;
        public new LinkedList<object> objectProperties = new LinkedList<object>();
        public new object Current => objectProperties.Find(_currentIndex);
        object IEnumerator<object>.Current => objectProperties.Find(_currentIndex);


        private     IDoorsElements DoorsElements;
        public Trolleybus(int maxSpeed, float weight, Color mainColor, Color dopColor, bool rodPantograph, bool doors, bool strip, int count_doors, string doorsForm) :
             base(maxSpeed, weight, mainColor, 100, 60)
        {
            DopColor = dopColor;
            DoorsElements = new RectangleDoors(3, dopColor);
            Doors = doors;
            RodPantograph = rodPantograph;
            Strip = strip;
            DoorsForm = doorsForm;
            if (DoorsForm == "TriangleDoors")
            {
                DoorsElements = new TriangleDoors(count_doors, dopColor);
            }
            if (DoorsForm == "RectangleDoors")
            {
                DoorsElements = new RectangleDoors(count_doors, dopColor);
            }
            if (DoorsForm == "RoundDoors")
            {
                DoorsElements = new RoundDoors(count_doors, dopColor);
            }
        }
        /// <summary>
        /// Конструктор для загрузки с файла
        /// </summary>
        /// <param name="info"></param>
        public Trolleybus(string info) : base(info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 9)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                RodPantograph = Convert.ToBoolean(strs[4]);
                Doors = Convert.ToBoolean(strs[5]);
                Strip = Convert.ToBoolean(strs[6]);
                count_Doors = Convert.ToInt32(strs[7]);
                DoorsForm = strs[8];
                SetDoors();
            }
        }
        public void SetDopColor(Color color)
        {
            DopColor = color;
            SetDoors();
        }
        public void SetDoors(IDoorsElements doors)
        {
            DoorsElements = doors;
            DoorsForm = DoorsElements.GetType().Name;

        }
        private void SetDoors()
        {
            if (DoorsForm == "TriangleDoors")
            {
                DoorsElements = new TriangleDoors(count_Doors, DopColor);
            }
            if (DoorsForm == "RectangleDoors")
            {
                DoorsElements = new RectangleDoors(count_Doors, DopColor);
            }
            if (DoorsForm == "RoundDoors")
            {
                DoorsElements = new RoundDoors(count_Doors,DopColor);
            }
        }
        public void SetCountDoors(int rod_count)
        {
            count_Doors = rod_count;
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
            if (DoorsElements != null)
            {
                DoorsElements.DrawElement(g, DopColor, _startPosX, _startPosY);
            }

            if (Doors)
            {
                DoorsElements.DrawElement(g, DopColor, _startPosX, _startPosY);
            }
            //Отрисовка рога
            if (RodPantograph)
            {
                g.DrawLine(pen, _startPosX + 100, _startPosY, _startPosX + 20, _startPosY - 20);
                g.DrawLine(pen, _startPosX + 20, _startPosY - 20, _startPosX + 10, _startPosY - 20);
                g.DrawLine(pen, _startPosX + 100, _startPosY, _startPosX + 20, _startPosY - 20);
            }
        }
        public override string ToString()
        {
            return
           $"{base.ToString()}{separator}{DopColor.Name}{separator}{RodPantograph}{separator}" +
           $"{Doors}{separator}{Strip}{separator}{count_Doors}"+ $"{separator}{DoorsForm}";
        }
        /// Метод интерфейса IEquatable для класса дочернего Trolleybus
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Trolleybus other)
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
            if (DopColor != other.DopColor)
            {
                return false;
            }
            if (RodPantograph != other.RodPantograph)
            {
                return false;
            }
            if (Doors != other.Doors)
            {
                return false;
            }
            if (Strip != other.Strip)
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
            if (!(obj is Trolleybus busObj))
            {
                return false;
            }
            else
            {
                return Equals(busObj);
            }
        }
        public int CompareTo(Trolleybus b)
        {
            var res = base.CompareTo(b);
            if (res != 0)
            {
                return res;
            }
            if (DopColor != b.DopColor)
            {
                return DopColor.Name.CompareTo(b.DopColor.Name);
            }
            if (RodPantograph != b.RodPantograph)
            {
                return RodPantograph.CompareTo(b.RodPantograph);
            }
            if (Doors != b.Doors)
            {
                return Doors.CompareTo(b.Doors);
            }
            if (DoorsForm != b.DoorsForm)
            {
                return DoorsForm.CompareTo(b.DoorsForm);
            }
            if (count_Doors != b.count_Doors)
            {
                return count_Doors.CompareTo(b.count_Doors);
            }
            if (Strip != b.Strip)
            {
                return Strip.CompareTo(b.Strip);
            }
            return 0;
        }
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
            _currentIndex++;
            return _currentIndex < 8;
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
        public IEnumerator<object> GetEnumerator()
        {
            return (IEnumerator<object>)objectProperties;
        }
        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
