using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBus
{
    class BusStationCollection
    {
        /// <summary>
        /// Словарь (хранилище) с парковками
        /// </summary>
        readonly Dictionary<string, BusStation<Vehicle, RectangleDoors>> stationStages;
        /// <summary>
        /// Возвращение списка названий праковок
        /// </summary>
        public List<string> Keys => stationStages.Keys.ToList();
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public BusStationCollection(int pictureWidth, int pictureHeight)
        {
            stationStages = new Dictionary<string, BusStation<Vehicle, RectangleDoors>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }
        /// <summary>
        /// Добавление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void AddBusStation(string name)
        {
            if (stationStages.ContainsKey(name))
            {
                return;
            }
            stationStages.Add(name, new BusStation<Vehicle, RectangleDoors>(pictureWidth, pictureHeight));
        }
        /// <summary>
        /// Удаление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void DelBusStation(string name)
        {
            if (stationStages.ContainsKey(name))
            {
                stationStages.Remove(name);
            }
        }
        /// <summary>
        /// Доступ к парковке
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public BusStation<Vehicle, RectangleDoors> this[string ind]
        {
            get
            {
                if (stationStages.ContainsKey(ind))
                {
                    return stationStages[ind];
                }
                else
                {
                    return null;
                }
            }
        }
        public Vehicle this[string key, int ind]
        {
            get
            {
                if (stationStages.ContainsKey(key) && ind >= 0)
                {
                    return stationStages[key]._places[ind];
                }
                return null;
            }
        }
    }
}
