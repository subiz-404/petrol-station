using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PetrolStation
{
    public static class ExtensionMethods
    {
        public static TEnum ToEnum<TEnum>(this int value)
        {
            if (typeof(TEnum).IsEnumDefined(value))
                return (TEnum)(object)value;

            return default;
        }
    }
    public abstract class Vehicle
    {
        private Fuel fuel;
        protected readonly double _tankCapacity;
        protected readonly double _availableFuel;

        public static Random rnd;
        public double TankCapacity { get; }
        public int WaitingTime { get; set; }
        public double AvailableFuel { get; }
        public int ServiceTime { get; set; }
        public bool IsWaiting { get; set; }
        public System.Windows.Forms.PictureBox picBox { get; set; }
        
        public System.Windows.Forms.Timer fuelTimer;
        protected System.Windows.Forms.Timer waitTimer;
        public event TimerTick tick;
        public event waitCompleteTime cmpTime;
        public delegate void TimerTick(Vehicle v, FuelPump p, EventArgs e);
        public delegate void waitCompleteTime(Vehicle v, EventArgs e);
        

        //setters/getters
        public Fuel getFuel()
        {
            return fuel;
        }

        public void setFuel(FuelType t)
        {
            this.fuel = new Fuel(t);
        }

        //default constructor
        public Vehicle()
        {
            initialization();
        }

        protected Vehicle(double capacity)
        {
            initialization();
            this._tankCapacity = capacity;
            this._availableFuel = rnd.Next(26) * this.TankCapacity / 100;
        }

        private void initialization()
        {
            rnd = new Random();
            this.IsWaiting = true;
            this.WaitingTime = rnd.Next(3000, 5000);
            this.picBox = new System.Windows.Forms.PictureBox();
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.Size = new Size(65, 40);
            
            this.waitTimer = new System.Windows.Forms.Timer();
            this.waitTimer.Tick += new EventHandler(waitTimerTick);
            this.waitTimer.Interval = this.WaitingTime;
            this.waitTimer.Start();
        }

        public System.Windows.Forms.Timer getWaitTimer()
        {
            return waitTimer;
        }

        public void fuelTimerTick(Object sender, EventArgs e, FuelPump pump)
        {
            fuelTimer.Stop();
            pump.Controls.Remove(this.picBox);
            if (tick != null)
                tick(this,pump, e);
        }

        private void waitTimerTick(Object sender, EventArgs e)
        {
            waitTimer.Stop();
            picBox.Hide();
            if (cmpTime != null)
                cmpTime(this, e);
        }

        public System.Windows.Forms.Timer getFuelTime()
        {
            return fuelTimer;
        }


    }
}