using System;
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
    public partial class FormBus : Form
    {
        private ITransport bus;
        public FormBus()
        {
            InitializeComponent();
        }

        public void SetBus(ITransport bus)
        {
            this.bus = bus;
            Draw();
        }
        /// Метод отрисовки троллейбуса
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBus.Width, pictureBoxBus.Height);
            Graphics gr = Graphics.FromImage(bmp);
            bus?.DrawTransport(gr);
            pictureBoxBus.Image = bmp;
        }
        /// Обработка нажатия кнопки "Создать автобус"
        private void buttonCreateBus_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            bus = new Bus(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue);
            bus.SetPosition(rnd.Next(50, 100), rnd.Next(50, 100), pictureBoxBus.Width,
           pictureBoxBus.Height);
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать троллейбус"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateTrolleybus_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int countRod = Convert.ToInt32(comboRod.SelectedItem);
            int doorsForm = (checkBoxTriangle.Checked && !checkBoxRectangle.Checked && !checkBoxRound.Checked) ? 1 :
                (!checkBoxTriangle.Checked && checkBoxRectangle.Checked && !checkBoxRound.Checked) ? 2 :
                (!checkBoxTriangle.Checked && !checkBoxRectangle.Checked && checkBoxRound.Checked ? 3 : 0);
            bus = new Trolleybus(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
           Color.Yellow, true, true,true, countRod, doorsForm, true);
            bus.SetPosition(rnd.Next(50, 100), rnd.Next(50, 100), pictureBoxBus.Width,
           pictureBoxBus.Height);
            Draw();
        }

        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    bus?.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    bus?.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    bus?.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    bus?.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
