namespace WindowsFormsBus
{
    partial class FormBusStation
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
            this.pictureBoxBusStation = new System.Windows.Forms.PictureBox();
            this.buttonBus = new System.Windows.Forms.Button();
            this.buttonTrolleybus = new System.Windows.Forms.Button();
            this.groupBoxStation = new System.Windows.Forms.GroupBox();
            this.OutPutBus = new System.Windows.Forms.Button();
            this.maskedTextBoxBus = new System.Windows.Forms.MaskedTextBox();
            this.labelBus = new System.Windows.Forms.Label();
            this.labelCompare = new System.Windows.Forms.Label();
            this.maskedTextBoxCompare = new System.Windows.Forms.MaskedTextBox();
            this.buttonCompare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBusStation)).BeginInit();
            this.groupBoxStation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxBusStation
            // 
            this.pictureBoxBusStation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxBusStation.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBusStation.Name = "pictureBoxBusStation";
            this.pictureBoxBusStation.Size = new System.Drawing.Size(553, 450);
            this.pictureBoxBusStation.TabIndex = 1;
            this.pictureBoxBusStation.TabStop = false;
            // 
            // buttonBus
            // 
            this.buttonBus.Location = new System.Drawing.Point(641, 12);
            this.buttonBus.Name = "buttonBus";
            this.buttonBus.Size = new System.Drawing.Size(96, 42);
            this.buttonBus.TabIndex = 2;
            this.buttonBus.Text = "Припарковать автобус";
            this.buttonBus.UseVisualStyleBackColor = true;
            this.buttonBus.Click += new System.EventHandler(this.buttonSetBus_Click);
            // 
            // buttonTrolleybus
            // 
            this.buttonTrolleybus.Location = new System.Drawing.Point(641, 60);
            this.buttonTrolleybus.Name = "buttonTrolleybus";
            this.buttonTrolleybus.Size = new System.Drawing.Size(96, 40);
            this.buttonTrolleybus.TabIndex = 3;
            this.buttonTrolleybus.Text = "Припарковать троллейбус";
            this.buttonTrolleybus.UseVisualStyleBackColor = true;
            this.buttonTrolleybus.Click += new System.EventHandler(this.buttonSetTrolleybus_Click);
            // 
            // groupBoxStation
            // 
            this.groupBoxStation.Controls.Add(this.OutPutBus);
            this.groupBoxStation.Controls.Add(this.maskedTextBoxBus);
            this.groupBoxStation.Controls.Add(this.labelBus);
            this.groupBoxStation.Location = new System.Drawing.Point(624, 106);
            this.groupBoxStation.Name = "groupBoxStation";
            this.groupBoxStation.Size = new System.Drawing.Size(125, 109);
            this.groupBoxStation.TabIndex = 4;
            this.groupBoxStation.TabStop = false;
            this.groupBoxStation.Text = "Забрать транспортное средство";
            // 
            // OutPutBus
            // 
            this.OutPutBus.Location = new System.Drawing.Point(9, 79);
            this.OutPutBus.Name = "OutPutBus";
            this.OutPutBus.Size = new System.Drawing.Size(75, 23);
            this.OutPutBus.TabIndex = 2;
            this.OutPutBus.Text = "Забрать";
            this.OutPutBus.UseVisualStyleBackColor = true;
            this.OutPutBus.Click += new System.EventHandler(this.buttonTakeBus_Click);
            // 
            // maskedTextBoxBus
            // 
            this.maskedTextBoxBus.Location = new System.Drawing.Point(51, 53);
            this.maskedTextBoxBus.Name = "maskedTextBoxBus";
            this.maskedTextBoxBus.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxBus.TabIndex = 1;
            // 
            // labelBus
            // 
            this.labelBus.AutoSize = true;
            this.labelBus.Location = new System.Drawing.Point(6, 53);
            this.labelBus.Name = "labelBus";
            this.labelBus.Size = new System.Drawing.Size(39, 13);
            this.labelBus.TabIndex = 0;
            this.labelBus.Text = "Место";
            // 
            // labelCompare
            // 
            this.labelCompare.AutoSize = true;
            this.labelCompare.Location = new System.Drawing.Point(582, 230);
            this.labelCompare.Name = "labelCompare";
            this.labelCompare.Size = new System.Drawing.Size(167, 13);
            this.labelCompare.TabIndex = 8;
            this.labelCompare.Text = "Количество заполненных мест:";
            // 
            // maskedTextBoxCompare
            // 
            this.maskedTextBoxCompare.Location = new System.Drawing.Point(624, 246);
            this.maskedTextBoxCompare.Name = "maskedTextBoxCompare";
            this.maskedTextBoxCompare.Size = new System.Drawing.Size(125, 20);
            this.maskedTextBoxCompare.TabIndex = 9;
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(624, 272);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(125, 39);
            this.buttonCompare.TabIndex = 10;
            this.buttonCompare.Text = "Сравнить";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // FormBusStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCompare);
            this.Controls.Add(this.maskedTextBoxCompare);
            this.Controls.Add(this.labelCompare);
            this.Controls.Add(this.groupBoxStation);
            this.Controls.Add(this.buttonTrolleybus);
            this.Controls.Add(this.buttonBus);
            this.Controls.Add(this.pictureBoxBusStation);
            this.Name = "FormBusStation";
            this.Text = "FormBusStation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBusStation)).EndInit();
            this.groupBoxStation.ResumeLayout(false);
            this.groupBoxStation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBusStation;
        private System.Windows.Forms.Button buttonBus;
        private System.Windows.Forms.Button buttonTrolleybus;
        private System.Windows.Forms.GroupBox groupBoxStation;
        private System.Windows.Forms.Button OutPutBus;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBus;
        private System.Windows.Forms.Label labelBus;
        private System.Windows.Forms.Label labelCompare;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCompare;
        private System.Windows.Forms.Button buttonCompare;
    }
}