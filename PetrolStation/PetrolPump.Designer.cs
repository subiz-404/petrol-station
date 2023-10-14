namespace PetrolStation
{
    partial class PetrolPump
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PetrolPump));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.unleadedLabel = new MetroFramework.Controls.MetroLabel();
            this.lpgLabel = new MetroFramework.Controls.MetroLabel();
            this.dieselLabel = new MetroFramework.Controls.MetroLabel();
            this.amountLabel = new MetroFramework.Controls.MetroLabel();
            this.commissionLabel = new MetroFramework.Controls.MetroLabel();
            this.servedLabel = new MetroFramework.Controls.MetroLabel();
            this.notServedLabel = new MetroFramework.Controls.MetroLabel();
            this.metroButton10 = new MetroFramework.Controls.MetroButton();
            this.fuelPump4 = new PetrolStation.FuelPump();
            this.fuelPump5 = new PetrolStation.FuelPump();
            this.fuelPump6 = new PetrolStation.FuelPump();
            this.fuelPump7 = new PetrolStation.FuelPump();
            this.fuelPump8 = new PetrolStation.FuelPump();
            this.fuelPump9 = new PetrolStation.FuelPump();
            this.fuelPump3 = new PetrolStation.FuelPump();
            this.fuelPump2 = new PetrolStation.FuelPump();
            this.fuelPump1 = new PetrolStation.FuelPump();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(163, 263);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(136, 20);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "No Vehicle Available";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(725, 51);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(160, 20);
            this.metroLabel2.TabIndex = 11;
            this.metroLabel2.Text = "Pump Already Occupied";
            // 
            // unleadedLabel
            // 
            this.unleadedLabel.AutoSize = true;
            this.unleadedLabel.Location = new System.Drawing.Point(93, 622);
            this.unleadedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.unleadedLabel.Name = "unleadedLabel";
            this.unleadedLabel.Size = new System.Drawing.Size(133, 20);
            this.unleadedLabel.TabIndex = 12;
            this.unleadedLabel.Text = "Unleaded (Liters) : 0";
            // 
            // lpgLabel
            // 
            this.lpgLabel.AutoSize = true;
            this.lpgLabel.Location = new System.Drawing.Point(544, 622);
            this.lpgLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lpgLabel.Name = "lpgLabel";
            this.lpgLabel.Size = new System.Drawing.Size(98, 20);
            this.lpgLabel.TabIndex = 13;
            this.lpgLabel.Text = "LPG (Liters) : 0";
            // 
            // dieselLabel
            // 
            this.dieselLabel.AutoSize = true;
            this.dieselLabel.Location = new System.Drawing.Point(333, 622);
            this.dieselLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dieselLabel.Name = "dieselLabel";
            this.dieselLabel.Size = new System.Drawing.Size(111, 20);
            this.dieselLabel.TabIndex = 15;
            this.dieselLabel.Text = "Diesel (Liters) : 0";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(1089, 591);
            this.amountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(77, 20);
            this.amountLabel.TabIndex = 16;
            this.amountLabel.Text = "Amount : 0";
            // 
            // commissionLabel
            // 
            this.commissionLabel.AutoSize = true;
            this.commissionLabel.Location = new System.Drawing.Point(1065, 622);
            this.commissionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.commissionLabel.Name = "commissionLabel";
            this.commissionLabel.Size = new System.Drawing.Size(124, 20);
            this.commissionLabel.TabIndex = 17;
            this.commissionLabel.Text = "1% Commission : 0";
            // 
            // servedLabel
            // 
            this.servedLabel.AutoSize = true;
            this.servedLabel.Location = new System.Drawing.Point(830, 591);
            this.servedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.servedLabel.Name = "servedLabel";
            this.servedLabel.Size = new System.Drawing.Size(127, 20);
            this.servedLabel.TabIndex = 18;
            this.servedLabel.Text = "Vehicles Served : 0";
            // 
            // notServedLabel
            // 
            this.notServedLabel.AutoSize = true;
            this.notServedLabel.Location = new System.Drawing.Point(816, 622);
            this.notServedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.notServedLabel.Name = "notServedLabel";
            this.notServedLabel.Size = new System.Drawing.Size(154, 20);
            this.notServedLabel.TabIndex = 19;
            this.notServedLabel.Text = "Vehicles Not Served : 0";
            // 
            // metroButton10
            // 
            this.metroButton10.BackColor = System.Drawing.Color.White;
            this.metroButton10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroButton10.Location = new System.Drawing.Point(1229, 51);
            this.metroButton10.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton10.Name = "metroButton10";
            this.metroButton10.Size = new System.Drawing.Size(124, 28);
            this.metroButton10.TabIndex = 20;
            this.metroButton10.Text = "Check Record";
            this.metroButton10.UseSelectable = true;
            this.metroButton10.Click += new System.EventHandler(this.metroButton10_Click);
            // 
            // fuelPump4
            // 
            this.fuelPump4.IsAvailable = true;
            this.fuelPump4.LeftPump = null;
            this.fuelPump4.Location = new System.Drawing.Point(610, 263);
            this.fuelPump4.Name = "fuelPump4";
            this.fuelPump4.PumpNumber = 4;
            this.fuelPump4.ServiceVehicle = null;
            this.fuelPump4.Size = new System.Drawing.Size(100, 160);
            this.fuelPump4.TabIndex = 24;
            // 
            // fuelPump5
            // 
            this.fuelPump5.IsAvailable = true;
            this.fuelPump5.LeftPump = this.fuelPump4;
            this.fuelPump5.Location = new System.Drawing.Point(815, 263);
            this.fuelPump5.Name = "fuelPump5";
            this.fuelPump5.PumpNumber = 5;
            this.fuelPump5.ServiceVehicle = null;
            this.fuelPump5.Size = new System.Drawing.Size(100, 160);
            this.fuelPump5.TabIndex = 25;
            // 
            // fuelPump6
            // 
            this.fuelPump6.IsAvailable = true;
            this.fuelPump6.LeftPump = this.fuelPump5;
            this.fuelPump6.Location = new System.Drawing.Point(1017, 263);
            this.fuelPump6.Name = "fuelPump6";
            this.fuelPump6.PumpNumber = 6;
            this.fuelPump6.ServiceVehicle = null;
            this.fuelPump6.Size = new System.Drawing.Size(100, 160);
            this.fuelPump6.TabIndex = 26;
            // 
            // fuelPump7
            // 
            this.fuelPump7.IsAvailable = true;
            this.fuelPump7.LeftPump = null;
            this.fuelPump7.Location = new System.Drawing.Point(610, 429);
            this.fuelPump7.Name = "fuelPump7";
            this.fuelPump7.PumpNumber = 7;
            this.fuelPump7.ServiceVehicle = null;
            this.fuelPump7.Size = new System.Drawing.Size(100, 160);
            this.fuelPump7.TabIndex = 27;
            // 
            // fuelPump8
            // 
            this.fuelPump8.IsAvailable = true;
            this.fuelPump8.LeftPump = this.fuelPump7;
            this.fuelPump8.Location = new System.Drawing.Point(815, 429);
            this.fuelPump8.Name = "fuelPump8";
            this.fuelPump8.PumpNumber = 8;
            this.fuelPump8.ServiceVehicle = null;
            this.fuelPump8.Size = new System.Drawing.Size(100, 160);
            this.fuelPump8.TabIndex = 28;
            // 
            // fuelPump9
            // 
            this.fuelPump9.IsAvailable = true;
            this.fuelPump9.LeftPump = this.fuelPump8;
            this.fuelPump9.Location = new System.Drawing.Point(1017, 429);
            this.fuelPump9.Name = "fuelPump9";
            this.fuelPump9.PumpNumber = 9;
            this.fuelPump9.ServiceVehicle = null;
            this.fuelPump9.Size = new System.Drawing.Size(100, 160);
            this.fuelPump9.TabIndex = 29;
            // 
            // fuelPump3
            // 
            this.fuelPump3.IsAvailable = true;
            this.fuelPump3.LeftPump = this.fuelPump2;
            this.fuelPump3.Location = new System.Drawing.Point(1017, 97);
            this.fuelPump3.Name = "fuelPump3";
            this.fuelPump3.PumpNumber = 3;
            this.fuelPump3.ServiceVehicle = null;
            this.fuelPump3.Size = new System.Drawing.Size(100, 160);
            this.fuelPump3.TabIndex = 30;
            // 
            // fuelPump2
            // 
            this.fuelPump2.IsAvailable = true;
            this.fuelPump2.LeftPump = this.fuelPump1;
            this.fuelPump2.Location = new System.Drawing.Point(815, 97);
            this.fuelPump2.Name = "fuelPump2";
            this.fuelPump2.PumpNumber = 2;
            this.fuelPump2.ServiceVehicle = null;
            this.fuelPump2.Size = new System.Drawing.Size(100, 160);
            this.fuelPump2.TabIndex = 31;
            // 
            // fuelPump1
            // 
            this.fuelPump1.IsAvailable = true;
            this.fuelPump1.LeftPump = null;
            this.fuelPump1.Location = new System.Drawing.Point(610, 97);
            this.fuelPump1.Name = "fuelPump1";
            this.fuelPump1.PumpNumber = 1;
            this.fuelPump1.ServiceVehicle = null;
            this.fuelPump1.Size = new System.Drawing.Size(100, 160);
            this.fuelPump1.TabIndex = 32;
            // 
            // PetrolPump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 656);
            this.Controls.Add(this.fuelPump1);
            this.Controls.Add(this.fuelPump2);
            this.Controls.Add(this.fuelPump3);
            this.Controls.Add(this.fuelPump9);
            this.Controls.Add(this.fuelPump8);
            this.Controls.Add(this.fuelPump7);
            this.Controls.Add(this.fuelPump6);
            this.Controls.Add(this.fuelPump5);
            this.Controls.Add(this.fuelPump4);
            this.Controls.Add(this.metroButton10);
            this.Controls.Add(this.notServedLabel);
            this.Controls.Add(this.servedLabel);
            this.Controls.Add(this.commissionLabel);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.dieselLabel);
            this.Controls.Add(this.lpgLabel);
            this.Controls.Add(this.unleadedLabel);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PetrolPump";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Petrol Station";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PetrolPump_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel unleadedLabel;
        private MetroFramework.Controls.MetroLabel lpgLabel;
        private MetroFramework.Controls.MetroLabel dieselLabel;
        private MetroFramework.Controls.MetroLabel amountLabel;
        private MetroFramework.Controls.MetroLabel commissionLabel;
        private MetroFramework.Controls.MetroLabel servedLabel;
        private MetroFramework.Controls.MetroLabel notServedLabel;
        private MetroFramework.Controls.MetroButton metroButton10;
        private FuelPump fuelPump4;
        private FuelPump fuelPump5;
        private FuelPump fuelPump6;
        private FuelPump fuelPump7;
        private FuelPump fuelPump8;
        private FuelPump fuelPump9;
        private FuelPump fuelPump3;
        private FuelPump fuelPump2;
        private FuelPump fuelPump1;
    }
}

