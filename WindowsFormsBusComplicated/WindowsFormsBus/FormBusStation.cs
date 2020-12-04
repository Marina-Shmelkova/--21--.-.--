using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public FormBusStation()
        {
            InitializeComponent();
            stationCollection = new BusStationCollection(pictureBoxBusStation.Width,
pictureBoxBusStation.Height);
            busStack = new Stack<Vehicle>();
            //Draw();
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
                if ((stationCollection[listBoxBusStation.SelectedItem.ToString()]) + bus)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Автобус не удалось поставить");
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
                var bus = stationCollection[listBoxBusStation.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBoxBus.Text);
                if (bus != null)
                {
                    busStack.Push(bus);
                }
                maskedTextBoxBus.Text = "";
                Draw();
            }
        }
        /// Метод обработки выбора элемента на listBoxLevels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxBusStation_SelectedIndexChanged(object sender, EventArgs e)
        {
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
    }
}
