using MetroFramework.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetrolStation
{
    public partial class FuelPump : UserControl
    {
        public int PumpNumber { get; set; }
        public Vehicle ServiceVehicle { get; set; }
        public FuelPump LeftPump { get; set; }
        public bool IsAvailable { get; set; }


        //default constructor
        public FuelPump()
        {
            InitializeComponent();
            ServiceVehicle = null;
            IsAvailable = true;
        }

        private void FuelPump_Load(object sender, EventArgs e)
        {
           this.pumpFillingButton.Text += " " + this.PumpNumber.ToString();
        }

        private void pumpFillingButton_Click(object sender, EventArgs e)
        {

        }
    }
        
}
