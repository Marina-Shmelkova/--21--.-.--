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
        private readonly BusStation<Bus, RectangleDoors> station;
        public FormBusStation()
        {
            InitializeComponent();
            station = new BusStation<Bus, RectangleDoors>(pictureBoxBusStation.Width,
           pictureBoxBusStation.Height);
            Draw();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBusStation.Width, pictureBoxBusStation.Height);
            Graphics gr = Graphics.FromImage(bmp);
            station.Draw(gr);
            pictureBoxBusStation.Image = bmp;
        }
        ///
        private void buttonSetBus_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var bus = new Bus(100, 1000, dialog.Color);
                if (station + bus)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Автовокзал переполнен");
                }
            }
        }
        private void buttonSetTrolleybus_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var bus = new Trolleybus(100, 1000, dialog.Color, dialogDop.Color, true);
                    if (station + bus)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Автовокзал переполнен");
                    }
                }
            }
        }
        private void buttonTakeBus_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxBus.Text != "")
            {
                var bus = station - Convert.ToInt32(maskedTextBoxBus.Text);
                if (bus != null)
                {
                    FormBus form = new FormBus();
                    form.SetBus(bus);
                    form.ShowDialog();
                }
                Draw();
            }
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            int index;
            if (maskedTextBoxCompare.Text != "")
            {
                index = Convert.ToInt32(maskedTextBoxCompare.Text);
            }
            else { return; }

            if (station > index)
            {
                MessageBox.Show("Количество заполненных мест более  " + index);
            }
            else if (station < index)
            {
                MessageBox.Show("Количество заполненных мест менее " + index);
            }

            else
            {
                MessageBox.Show("Количество заполненных мест = " + index);
            }
        }
    }
}
