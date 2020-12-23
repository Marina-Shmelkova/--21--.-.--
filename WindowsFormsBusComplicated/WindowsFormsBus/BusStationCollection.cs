using System;
using System.Collections.Generic;
using System.IO;
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
        /// Разделитель для записи информации в файл
        /// </summary>
        private readonly char separator = ':';
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
        /// <summary>
        /// Метод записи информации в файл
        /// </summary>
        /// <param name="text">Строка, которую следует записать</param>
        /// <param name="stream">Поток для записи</param>
      
        public Vehicle this[string key, int ind]
        {
            get
            {
                if (stationStages.ContainsKey(key) && ind >= 0)
                {
                    return stationStages[key][ind];
                }
                return null;
            }
        }
        /// <summary>
        /// Сохранение информации по автобусам на парковках в файл
        /// </summary>
        /// <param name="filename">Путь и имя файла</param>
        /// <returns></returns>

        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine($"BusStationCollection");

                    foreach (var level in stationStages)
                    {
                        sw.WriteLine($"Station{separator}{level.Key}");
                        ITransport bus = null;
                        for (int i = 0; (bus = level.Value[i]) != null; i++)
                        {
                            if (bus != null)
                            {
                                if (bus.GetType().Name == "Bus")
                                {
                                    sw.Write($"Bus{separator}");

                                }
                                if (bus.GetType().Name == "Trolleybus")
                                {
                                    sw.Write($"Trolleybus{separator}");
                                }
                                //Записываемые параметры
                                sw.WriteLine(bus);
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool SaveData(string filename, string dockName)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            if (!stationStages.ContainsKey(dockName))
            {
                return false;
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine($"OneBusStation");

                    sw.WriteLine($"Station{separator}{dockName}");
                    ITransport bus = null;
                    var level = stationStages[dockName];


                    for (int i = 0; (bus = level[i]) != null; i++)
                    {
                        if (bus != null)
                        {
                            if (bus.GetType().Name == "Bus")
                            {
                                sw.Write($"Bus{separator}");

                            }
                            if (bus.GetType().Name == "Trolleybus")
                            {
                                sw.Write($"Trolleybus{separator}");
                            }
                            //Записываемые параметры
                            sw.WriteLine(bus);
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Загрузка информации по автобусам на парковках из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public void LoadBusStationCollection(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();
                if (line.Contains("BusStationCollection"))
                {
                    //очищаем записи
                    stationStages.Clear();
                }
                else
                {
                    //если нет такой записи, то это не те данные
                    throw new FormatException("Неверный формат файла");
                }
                line = sr.ReadLine();
                Vehicle bus = null;
                string key = string.Empty;
                while (line != null && line.Contains("Station"))
                {
                    key = line.Split(separator)[1];
                    stationStages.Add(key, new BusStation<Vehicle, RectangleDoors>(pictureWidth, pictureHeight));

                    line = sr.ReadLine();
                    while (line != null && (line.Contains("Bus") || line.Contains("Trolleybus")))
                    {
                        if (line.Split(separator)[0] == "Bus")
                        {
                            bus = new Bus(line.Split(separator)[1]);
                        }
                        else if (line.Split(separator)[0] == "Trolleybus")
                        {
                            bus = new Trolleybus(line.Split(separator)[1]);
                        }
                        var result = stationStages[key] + bus;
                        if (!result)
                        {
                            throw new NullReferenceException();
                        }
                        line = sr.ReadLine();
                    }
                }
            }
        }

        public void LoadBusStation(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();

                if (line.Contains("OneBusStation")) { }
                else
                {
                    //если нет такой записи, то это не те данные
                    throw new FormatException("Неверный формат файла");
                }
                line = sr.ReadLine();
                Vehicle bus = null;
                string key = string.Empty;
                if (line != null && line.Contains("Station"))
                {
                    key = line.Split(separator)[1];
                    if (stationStages.ContainsKey(key))
                    {
                        stationStages[key].ClearPlaces();
                    }
                    else
                    {
                        stationStages.Add(key, new BusStation<Vehicle, RectangleDoors>(pictureWidth, pictureHeight));
                    }

                    line = sr.ReadLine();
                    while (line != null && (line.Contains("Bus") || line.Contains("Trolleybus")))
                    {
                        if (line.Split(separator)[0] == "Bus")
                        {
                            bus = new Bus(line.Split(separator)[1]);
                        }
                        else if (line.Split(separator)[0] == "Trolleybus")
                        {
                            bus = new Trolleybus(line.Split(separator)[1]);
                        }
                        var result = stationStages[key] + bus;
                        if (!result)
                        {
                            throw new NullReferenceException();
                        }
                        line = sr.ReadLine();
                    }
                }
            }
        }
    }    
}
