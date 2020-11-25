namespace WindowsFormsBus
{
    partial class FormBusConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupBoxColor = new System.Windows.Forms.GroupBox();
            this.labelDopColor = new System.Windows.Forms.Label();
            this.panelGray = new System.Windows.Forms.Panel();
            this.panelYellow = new System.Windows.Forms.Panel();
            this.panelOrange = new System.Windows.Forms.Panel();
            this.panelFuchsia = new System.Windows.Forms.Panel();
            this.panelGreen = new System.Windows.Forms.Panel();
            this.panelBlack = new System.Windows.Forms.Panel();
            this.panelBlue = new System.Windows.Forms.Panel();
            this.panelRed = new System.Windows.Forms.Panel();
            this.labelMainColor = new System.Windows.Forms.Label();
            this.panelBus = new System.Windows.Forms.Panel();
            this.pictureBoxConfig = new System.Windows.Forms.PictureBox();
            this.groupBoxTypeBus = new System.Windows.Forms.GroupBox();
            this.labelTrolleybus = new System.Windows.Forms.Label();
            this.labelBus = new System.Windows.Forms.Label();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxStrip = new System.Windows.Forms.CheckBox();
            this.checkBoxDoors = new System.Windows.Forms.CheckBox();
            this.checkBoxRod = new System.Windows.Forms.CheckBox();
            this.numericUpDownWeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.labelWeightBus = new System.Windows.Forms.Label();
            this.labelMaxSpeed = new System.Windows.Forms.Label();
            this.groupBoxDoors = new System.Windows.Forms.GroupBox();
            this.labelTriangle = new System.Windows.Forms.Label();
            this.labelRectangle = new System.Windows.Forms.Label();
            this.labelRound = new System.Windows.Forms.Label();
            this.labelModification = new System.Windows.Forms.Label();
            this.groupBoxColor.SuspendLayout();
            this.panelBus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfig)).BeginInit();
            this.groupBoxTypeBus.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).BeginInit();
            this.groupBoxDoors.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(667, 204);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Text = "Отмена";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(577, 204);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // groupBoxColor
            // 
            this.groupBoxColor.Controls.Add(this.labelDopColor);
            this.groupBoxColor.Controls.Add(this.panelGray);
            this.groupBoxColor.Controls.Add(this.panelYellow);
            this.groupBoxColor.Controls.Add(this.panelOrange);
            this.groupBoxColor.Controls.Add(this.panelFuchsia);
            this.groupBoxColor.Controls.Add(this.panelGreen);
            this.groupBoxColor.Controls.Add(this.panelBlack);
            this.groupBoxColor.Controls.Add(this.panelBlue);
            this.groupBoxColor.Controls.Add(this.panelRed);
            this.groupBoxColor.Controls.Add(this.labelMainColor);
            this.groupBoxColor.Location = new System.Drawing.Point(546, 56);
            this.groupBoxColor.Name = "groupBoxColor";
            this.groupBoxColor.Size = new System.Drawing.Size(242, 142);
            this.groupBoxColor.TabIndex = 10;
            this.groupBoxColor.TabStop = false;
            this.groupBoxColor.Text = "Цвета";
            // 
            // labelDopColor
            // 
            this.labelDopColor.AllowDrop = true;
            this.labelDopColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDopColor.Location = new System.Drawing.Point(119, 24);
            this.labelDopColor.Name = "labelDopColor";
            this.labelDopColor.Size = new System.Drawing.Size(100, 23);
            this.labelDopColor.TabIndex = 1;
            this.labelDopColor.Text = "Доп. Цвет";
            this.labelDopColor.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelDopColor_DragDop);
            this.labelDopColor.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelMainColor_DragEnter);
            // 
            // panelGray
            // 
            this.panelGray.BackColor = System.Drawing.Color.Gray;
            this.panelGray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGray.Location = new System.Drawing.Point(171, 110);
            this.panelGray.Name = "panelGray";
            this.panelGray.Size = new System.Drawing.Size(25, 23);
            this.panelGray.TabIndex = 9;
            // 
            // panelYellow
            // 
            this.panelYellow.BackColor = System.Drawing.Color.Yellow;
            this.panelYellow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelYellow.Location = new System.Drawing.Point(119, 110);
            this.panelYellow.Name = "panelYellow";
            this.panelYellow.Size = new System.Drawing.Size(23, 23);
            this.panelYellow.TabIndex = 8;
            // 
            // panelOrange
            // 
            this.panelOrange.BackColor = System.Drawing.Color.Orange;
            this.panelOrange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrange.Location = new System.Drawing.Point(69, 110);
            this.panelOrange.Name = "panelOrange";
            this.panelOrange.Size = new System.Drawing.Size(25, 23);
            this.panelOrange.TabIndex = 7;
            // 
            // panelFuchsia
            // 
            this.panelFuchsia.BackColor = System.Drawing.Color.Fuchsia;
            this.panelFuchsia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFuchsia.Location = new System.Drawing.Point(17, 110);
            this.panelFuchsia.Name = "panelFuchsia";
            this.panelFuchsia.Size = new System.Drawing.Size(26, 23);
            this.panelFuchsia.TabIndex = 6;
            // 
            // panelGreen
            // 
            this.panelGreen.BackColor = System.Drawing.Color.Green;
            this.panelGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGreen.Location = new System.Drawing.Point(171, 64);
            this.panelGreen.Name = "panelGreen";
            this.panelGreen.Size = new System.Drawing.Size(25, 23);
            this.panelGreen.TabIndex = 5;
            // 
            // panelBlack
            // 
            this.panelBlack.BackColor = System.Drawing.Color.Black;
            this.panelBlack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBlack.Location = new System.Drawing.Point(119, 64);
            this.panelBlack.Name = "panelBlack";
            this.panelBlack.Size = new System.Drawing.Size(23, 23);
            this.panelBlack.TabIndex = 4;
            // 
            // panelBlue
            // 
            this.panelBlue.BackColor = System.Drawing.Color.Blue;
            this.panelBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBlue.Location = new System.Drawing.Point(69, 64);
            this.panelBlue.Name = "panelBlue";
            this.panelBlue.Size = new System.Drawing.Size(25, 23);
            this.panelBlue.TabIndex = 3;
            // 
            // panelRed
            // 
            this.panelRed.BackColor = System.Drawing.Color.Red;
            this.panelRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRed.Location = new System.Drawing.Point(17, 64);
            this.panelRed.Name = "panelRed";
            this.panelRed.Size = new System.Drawing.Size(26, 23);
            this.panelRed.TabIndex = 2;
            // 
            // labelMainColor
            // 
            this.labelMainColor.AllowDrop = true;
            this.labelMainColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMainColor.Location = new System.Drawing.Point(6, 24);
            this.labelMainColor.Name = "labelMainColor";
            this.labelMainColor.Size = new System.Drawing.Size(100, 23);
            this.labelMainColor.TabIndex = 0;
            this.labelMainColor.Text = "Основной цвет";
            this.labelMainColor.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelMainColor_DragDop);
            this.labelMainColor.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelMainColor_DragEnter);
            // 
            // panelBus
            // 
            this.panelBus.AllowDrop = true;
            this.panelBus.Controls.Add(this.pictureBoxConfig);
            this.panelBus.Location = new System.Drawing.Point(203, 53);
            this.panelBus.Name = "panelBus";
            this.panelBus.Size = new System.Drawing.Size(324, 168);
            this.panelBus.TabIndex = 9;
            this.panelBus.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelBus_DragDrop);
            this.panelBus.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelBus_DragEnter);
            // 
            // pictureBoxConfig
            // 
            this.pictureBoxConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxConfig.Location = new System.Drawing.Point(22, 3);
            this.pictureBoxConfig.Name = "pictureBoxConfig";
            this.pictureBoxConfig.Size = new System.Drawing.Size(279, 156);
            this.pictureBoxConfig.TabIndex = 1;
            this.pictureBoxConfig.TabStop = false;
            // 
            // groupBoxTypeBus
            // 
            this.groupBoxTypeBus.Controls.Add(this.labelTrolleybus);
            this.groupBoxTypeBus.Controls.Add(this.labelBus);
            this.groupBoxTypeBus.Location = new System.Drawing.Point(52, 53);
            this.groupBoxTypeBus.Name = "groupBoxTypeBus";
            this.groupBoxTypeBus.Size = new System.Drawing.Size(120, 99);
            this.groupBoxTypeBus.TabIndex = 8;
            this.groupBoxTypeBus.TabStop = false;
            this.groupBoxTypeBus.Text = "Тип кузова";
            // 
            // labelTrolleybus
            // 
            this.labelTrolleybus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTrolleybus.Location = new System.Drawing.Point(6, 64);
            this.labelTrolleybus.Name = "labelTrolleybus";
            this.labelTrolleybus.Size = new System.Drawing.Size(100, 23);
            this.labelTrolleybus.TabIndex = 2;
            this.labelTrolleybus.Text = "Троллейбус";
            this.labelTrolleybus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTrolleybus_MouseDown);
            // 
            // labelBus
            // 
            this.labelBus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelBus.Location = new System.Drawing.Point(6, 31);
            this.labelBus.Name = "labelBus";
            this.labelBus.Size = new System.Drawing.Size(100, 23);
            this.labelBus.TabIndex = 0;
            this.labelBus.Text = "Обычный";
            this.labelBus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelBus_MouseDown);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.checkBoxStrip);
            this.groupBoxOptions.Controls.Add(this.checkBoxDoors);
            this.groupBoxOptions.Controls.Add(this.checkBoxRod);
            this.groupBoxOptions.Controls.Add(this.numericUpDownWeight);
            this.groupBoxOptions.Controls.Add(this.numericUpDownSpeed);
            this.groupBoxOptions.Controls.Add(this.labelWeightBus);
            this.groupBoxOptions.Controls.Add(this.labelMaxSpeed);
            this.groupBoxOptions.Location = new System.Drawing.Point(203, 264);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(288, 117);
            this.groupBoxOptions.TabIndex = 7;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Параметры";
            // 
            // checkBoxStrip
            // 
            this.checkBoxStrip.AutoSize = true;
            this.checkBoxStrip.Location = new System.Drawing.Point(161, 88);
            this.checkBoxStrip.Name = "checkBoxStrip";
            this.checkBoxStrip.Size = new System.Drawing.Size(64, 17);
            this.checkBoxStrip.TabIndex = 6;
            this.checkBoxStrip.Text = "Полоса";
            this.checkBoxStrip.UseVisualStyleBackColor = true;
            // 
            // checkBoxDoors
            // 
            this.checkBoxDoors.AutoSize = true;
            this.checkBoxDoors.Location = new System.Drawing.Point(161, 64);
            this.checkBoxDoors.Name = "checkBoxDoors";
            this.checkBoxDoors.Size = new System.Drawing.Size(59, 17);
            this.checkBoxDoors.TabIndex = 5;
            this.checkBoxDoors.Text = "Двери";
            this.checkBoxDoors.UseVisualStyleBackColor = true;
            // 
            // checkBoxRod
            // 
            this.checkBoxRod.AutoSize = true;
            this.checkBoxRod.Location = new System.Drawing.Point(161, 41);
            this.checkBoxRod.Name = "checkBoxRod";
            this.checkBoxRod.Size = new System.Drawing.Size(50, 17);
            this.checkBoxRod.TabIndex = 4;
            this.checkBoxRod.Text = "Рога";
            this.checkBoxRod.UseVisualStyleBackColor = true;
            // 
            // numericUpDownWeight
            // 
            this.numericUpDownWeight.Location = new System.Drawing.Point(85, 80);
            this.numericUpDownWeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownWeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownWeight.Name = "numericUpDownWeight";
            this.numericUpDownWeight.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownWeight.TabIndex = 3;
            this.numericUpDownWeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownSpeed
            // 
            this.numericUpDownSpeed.Location = new System.Drawing.Point(85, 41);
            this.numericUpDownSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSpeed.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSpeed.Name = "numericUpDownSpeed";
            this.numericUpDownSpeed.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownSpeed.TabIndex = 2;
            this.numericUpDownSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelWeightBus
            // 
            this.labelWeightBus.AutoSize = true;
            this.labelWeightBus.Location = new System.Drawing.Point(6, 64);
            this.labelWeightBus.Name = "labelWeightBus";
            this.labelWeightBus.Size = new System.Drawing.Size(75, 13);
            this.labelWeightBus.TabIndex = 1;
            this.labelWeightBus.Text = "Вес автобуса";
            // 
            // labelMaxSpeed
            // 
            this.labelMaxSpeed.AutoSize = true;
            this.labelMaxSpeed.Location = new System.Drawing.Point(6, 25);
            this.labelMaxSpeed.Name = "labelMaxSpeed";
            this.labelMaxSpeed.Size = new System.Drawing.Size(134, 13);
            this.labelMaxSpeed.TabIndex = 0;
            this.labelMaxSpeed.Text = "Максимальная скорость";
            // 
            // groupBoxDoors
            // 
            this.groupBoxDoors.Controls.Add(this.labelTriangle);
            this.groupBoxDoors.Controls.Add(this.labelRectangle);
            this.groupBoxDoors.Controls.Add(this.labelRound);
            this.groupBoxDoors.Location = new System.Drawing.Point(520, 264);
            this.groupBoxDoors.Name = "groupBoxDoors";
            this.groupBoxDoors.Size = new System.Drawing.Size(120, 110);
            this.groupBoxDoors.TabIndex = 13;
            this.groupBoxDoors.TabStop = false;
            this.groupBoxDoors.Text = "Форма дверей";
            // 
            // labelTriangle
            // 
            this.labelTriangle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTriangle.Location = new System.Drawing.Point(5, 84);
            this.labelTriangle.Name = "labelTriangle";
            this.labelTriangle.Size = new System.Drawing.Size(100, 23);
            this.labelTriangle.TabIndex = 16;
            this.labelTriangle.Text = "Треугольные";
            this.labelTriangle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelTriangle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDoorsForm_MouseDown);
            // 
            // labelRectangle
            // 
            this.labelRectangle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelRectangle.Location = new System.Drawing.Point(5, 15);
            this.labelRectangle.Name = "labelRectangle";
            this.labelRectangle.Size = new System.Drawing.Size(100, 23);
            this.labelRectangle.TabIndex = 14;
            this.labelRectangle.Text = "Квадратные";
            this.labelRectangle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelRectangle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDoorsForm_MouseDown);
            // 
            // labelRound
            // 
            this.labelRound.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelRound.Location = new System.Drawing.Point(5, 49);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(100, 23);
            this.labelRound.TabIndex = 15;
            this.labelRound.Text = "Круглые";
            this.labelRound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelRound.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDoorsForm_MouseDown);
            // 
            // labelModification
            // 
            this.labelModification.AllowDrop = true;
            this.labelModification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelModification.Location = new System.Drawing.Point(655, 286);
            this.labelModification.Name = "labelModification";
            this.labelModification.Size = new System.Drawing.Size(120, 59);
            this.labelModification.TabIndex = 15;
            this.labelModification.Text = "Преобразовать";
            this.labelModification.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelModification.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelDoorsForm_DragDop);
            this.labelModification.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelDoorsForm_DragEnter);
            // 
            // FormBusConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelModification);
            this.Controls.Add(this.groupBoxDoors);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.groupBoxColor);
            this.Controls.Add(this.panelBus);
            this.Controls.Add(this.groupBoxTypeBus);
            this.Controls.Add(this.groupBoxOptions);
            this.Name = "FormBusConfig";
            this.Text = "FormBusConfig";
            this.groupBoxColor.ResumeLayout(false);
            this.panelBus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfig)).EndInit();
            this.groupBoxTypeBus.ResumeLayout(false);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeed)).EndInit();
            this.groupBoxDoors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.GroupBox groupBoxColor;
        private System.Windows.Forms.Panel panelGray;
        private System.Windows.Forms.Panel panelYellow;
        private System.Windows.Forms.Panel panelOrange;
        private System.Windows.Forms.Panel panelFuchsia;
        private System.Windows.Forms.Panel panelGreen;
        private System.Windows.Forms.Panel panelBlack;
        private System.Windows.Forms.Panel panelBlue;
        private System.Windows.Forms.Panel panelRed;
        private System.Windows.Forms.Label labelDopColor;
        private System.Windows.Forms.Label labelMainColor;
        private System.Windows.Forms.Panel panelBus;
        private System.Windows.Forms.PictureBox pictureBoxConfig;
        private System.Windows.Forms.GroupBox groupBoxTypeBus;
        private System.Windows.Forms.Label labelTrolleybus;
        private System.Windows.Forms.Label labelBus;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox checkBoxStrip;
        private System.Windows.Forms.CheckBox checkBoxDoors;
        private System.Windows.Forms.CheckBox checkBoxRod;
        private System.Windows.Forms.NumericUpDown numericUpDownWeight;
        private System.Windows.Forms.NumericUpDown numericUpDownSpeed;
        private System.Windows.Forms.Label labelWeightBus;
        private System.Windows.Forms.Label labelMaxSpeed;
        private System.Windows.Forms.GroupBox groupBoxDoors;
        private System.Windows.Forms.Label labelTriangle;
        private System.Windows.Forms.Label labelRectangle;
        private System.Windows.Forms.Label labelRound;
        private System.Windows.Forms.Label labelModification;
    }
}