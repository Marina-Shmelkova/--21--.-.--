using NLog;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsBus
{
    public partial class FormBusStation : Form
    {

        private readonly Stack<Vehicle> busStack;
        private readonly BusStationCollection stationCollection;
        private readonly Logger logger;
        public FormBusStation()
        {
            InitializeComponent();
            stationCollection = new BusStationCollection(pictureBoxBusStation.Width,
pictureBoxBusStation.Height);
            busStack = new Stack<Vehicle>();
            logger = LogManager.GetCurrentClassLogger();
            Draw();
        }
        /// Заполнение listBoxLevels
        /// </summary>
        private void ReloadLevels()
        {
            int index = listBoxBusStation.SelectedIndex;
            listBoxBusStation.Items.Clear();
            for (int i = 0; i < stationCollection.Keys.Count; i++)
            {
                listBoxBusStation.Items.Add(stationCollection.Keys[i]);
            }
            if (listBoxBusStation.Items.Count > 0 && (index == -1 || index >=
           listBoxBusStation.Items.Count))
            {
                listBoxBusStation.SelectedIndex = 0;
            }
            else if (listBoxBusStation.Items.Count > 0 && index > -1 && index <
           listBoxBusStation.Items.Count)
            {
                listBoxBusStation.SelectedIndex = index;
            }
        }
        /// Метод отрисовки парковки
        /// </summary>
        private void Draw()
        {
            if (listBoxBusStation.SelectedIndex > -1)
            {//если выбран один из пуктов в listBox (при старте программы ни один пунктне будет выбран и может возникнуть ошибка, если мы попытаемся обратиться к элементу listBox)
                Bitmap bmp = new Bitmap(pictureBoxBusStation.Width,
                pictureBoxBusStation.Height);
                Graphics gr = Graphics.FromImage(bmp);
                stationCollection[listBoxBusStation.SelectedItem.ToString()].Draw(gr);
                pictureBoxBusStation.Image = bmp;
            }
        }
        /// /// Обработка нажатия кнопки "Добавить парковку"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddBusStation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNewLevelName.Text))
            {
                MessageBox.Show("Введите название парковки", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            stationCollection.AddBusStation(textBoxNewLevelName.Text);
            logger.Info($"Добавлена парковка {textBoxNewLevelName.Text}");
            textBoxNewLevelName.Text = "";
            ReloadLevels();
        }
        /// Обработка нажатия кнопки "Удалить парковку"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelBusStation_Click(object sender, EventArgs e)
        {
            if (listBoxBusStation.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить парковку {listBoxBusStation.SelectedItem.ToString()}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    {
                        stationCollection.DelBusStation(listBoxBusStation.SelectedItem.ToString());
                        logger.Info($"Удалена парковка{ listBoxBusStation.SelectedItem.ToString()}");
                        ReloadLevels();
                        Draw();
                    }
                }
            }
        }   
        /// Обработка нажатия кнопки "Добавить автобус"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetBus_Click(object sender, EventArgs e)
        {
            var formBusConfig = new FormBusConfig();
            formBusConfig.AddEvent(AddBus);
            formBusConfig.Show();
        }
        /// <summary>
        /// Метод добавления машины
        /// </summary>

        private void AddBus(Vehicle bus)
        {
            if (bus != null && listBoxBusStation.SelectedIndex > -1)
            {
                try
                {
                    if ((stationCollection[listBoxBusStation.SelectedItem.ToString()]) + bus)
                    {

                        logger.Info($"Добавлен автобус {bus}");
                    }
                    else
                    {
                        MessageBox.Show("Автобус не удалось поставить");
                    }
                    Draw();
                }
                catch (BusStationOverflowException ex)
                {
                    logger.Warn("Вызвано исключение - переполнение парковок ");
                    MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Fatal("Вызвана неизвестная ошибка");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTakeBus_Click(object sender, EventArgs e)
        {
            if (listBoxBusStation.SelectedIndex > -1 && maskedTextBoxBus.Text != "")
            {
                try
                {
                    var bus = stationCollection[listBoxBusStation.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBoxBus.Text);
                    if (bus != null)
                    {
                        logger.Info($"Изъят автобус {bus} с места { maskedTextBoxBus.Text}");
                        busStack.Push(bus);
                    }
                    maskedTextBoxBus.Text = "";
                    Draw();
                }
                catch (BusStationNotFoundException ex)
                {
                    logger.Warn("Вызвана ошибка BusStationNotFoundException");
                    MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Fatal("Вызвана неизвестная ошибка изъятии автобуса с парковки");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// Метод обработки выбора элемента на listBoxLevels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxBusStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Перешли на парковку { listBoxBusStation.SelectedItem.ToString()}");
            Draw();
        }
        ///
        private void buttonCompare_Click(object sender, EventArgs e)
        {
            int index;
            if (maskedTextBoxCompare.Text != "")
            {
                index = Convert.ToInt32(maskedTextBoxCompare.Text);
            }
            else { return; }

            if (stationCollection[listBoxBusStation.SelectedItem.ToString()] > index)
            {
                MessageBox.Show("Количество заполненных мест более  " + index);
            }
            else if (stationCollection[listBoxBusStation.SelectedItem.ToString()] < index)
            {
                MessageBox.Show("Количество заполненных мест менее " + index);
            }

            else
            {
                MessageBox.Show("Количество заполненных мест = " + index);
            }
        }

        private void buttonStack_Click(object sender, EventArgs e)
        {
            if (busStack.Count() > 0)
            {
                FormBus form = new FormBus();
                form.SetBus(busStack.Pop());
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Стек пуст");
            }
        }

        private void сохранитьОднуПарковкуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileDialogBus.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    stationCollection.SaveData(saveFileDialogBus.FileName, listBoxBusStation.SelectedItem.ToString());
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialogBus.FileName);
                }
                catch (FormatException ex)
                {
                    logger.Error(ex.Message);
                    MessageBox.Show(ex.Message, "Ошибка при загрузке",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Fatal("Вызвана неизвестная ошибка при сохранении");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void сохранитьВсеПарковкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogBus.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    stationCollection.SaveData(saveFileDialogBus.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialogBus.FileName);
                }
                catch (Exception ex)
                {
                    logger.Fatal("Вызвана неизвестная ошибка при сохранении");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void загрузитьОднуПарковкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogBus.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    stationCollection.LoadBusStation(openFileDialogBus.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialogBus.FileName);
                    ReloadLevels();
                    Draw();
                }
                catch (FileNotFoundException ex)
                {
                    logger.Error("Вызвана ошибка NullReferenceException");
                    MessageBox.Show(ex.Message, "Место занято", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (NullReferenceException ex)
                {
                    logger.Error("Вызвана ошибка NullReferenceException");
                    MessageBox.Show(ex.Message, "Место занято", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (FormatException ex)
                {
                    logger.Error(ex.Message);
                    MessageBox.Show(ex.Message, "Ошибка при загрузке",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Fatal("Вызвана неизвестная ошибка при загрузке");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при загрузке",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void загрузитьВсеПарковкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogBus.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    stationCollection.LoadBusStationCollection(openFileDialogBus.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialogBus.FileName);
                    ReloadLevels();
                    Draw();
                }
                catch (FileNotFoundException ex)
                {
                    logger.Error("Вызвана ошибка NullReferenceException");
                    MessageBox.Show(ex.Message, "Место занято", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (FormatException ex)
                {
                    logger.Error(ex.Message);
                    MessageBox.Show(ex.Message, "Ошибка при загрузке",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (NullReferenceException ex)
                {
                    logger.Error("Вызвана ошибка NullReferenceException");
                    MessageBox.Show(ex.Message, "Обращение к null объекту", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Fatal("Вызвана неизвестная ошибка при загрузке");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при загрузке",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Сортировка"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (listBoxBusStation.SelectedIndex > -1)
            {
                stationCollection[listBoxBusStation.SelectedItem.ToString()].Sort();
                Draw();
                logger.Info("Сортировка уровней");
            }
        }
    }
}