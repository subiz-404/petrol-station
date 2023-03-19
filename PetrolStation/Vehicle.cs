using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PetrolStation
{
    public class Vehicle
    {
        //member variables
        private double tankCapacity;
        private int waitingTime;
        private double availableFuel;
        private int serviceTime;
        protected string vehicleType;
        private bool isWaiting;
        private Fuel fuel;
        protected System.Windows.Forms.PictureBox pB;
        protected System.Windows.Forms.Timer fuelTimer;
        protected System.Windows.Forms.Timer waitTimer;
        public event TimerTick tick;
        public event waitCompleteTime cmpTime;
        public delegate void TimerTick(Vehicle v, EventArgs e);
        public delegate void waitCompleteTime(Vehicle v, EventArgs e);
        

        //setters/getters
        public string getVehicleType()
        {
            return vehicleType;
        }
        public Fuel getFuel()
        {
            return fuel;
        }

        public void setFuel(string n)
        {
            this.fuel = new Fuel(n);
        }

        //default constructor
        public Vehicle()
        {
            Random rnd = new Random();
            this.setIsWaiting(true);
            this.setWaitingTime(rnd.Next(3000, 5000));
            this.setServiceTime(rnd.Next(17000, 19000));
            pB = new System.Windows.Forms.PictureBox();
            pB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pB.Size = new Size(64, 39);
            fuelTimer = new System.Windows.Forms.Timer();
            fuelTimer.Tick += new EventHandler(fuelTimerTick);
            fuelTimer.Interval = this.getServiceTime();
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Tick += new EventHandler(waitTimerTick);
            waitTimer.Interval = this.getwaitingTime();
            waitTimer.Start();

        }

        public System.Windows.Forms.Timer getWaitTimer()
        {
            return waitTimer;
        }

        private void fuelTimerTick(Object sender, EventArgs e)
        {
            fuelTimer.Stop();
            pB.Hide();
            if (tick != null)
                tick(this, e);
        }

        private void waitTimerTick(Object sender, EventArgs e)
        {
            waitTimer.Stop();
            pB.Hide();
            if (cmpTime != null)
                cmpTime(this, e);
        }


        //setters/getters
        public System.Windows.Forms.Timer getFuelTime()
        {
            return fuelTimer;
        }

        public void setTankCapacity(double c)
        {
            tankCapacity = c;
        }

        public double getTankCapacity()
        {
            return tankCapacity;
        }

        public void setWaitingTime(int w)
        {
            waitingTime = w;
        }

        public int getwaitingTime()
        {
            return waitingTime;
        }

        public void setAvailableFuel(double a)
        {
            availableFuel = a;
        }

        public double getAvailableFuel()
        {
            return availableFuel;
        }

        public void setServiceTime(int s)
        {
            serviceTime = s;
        }
        public int getServiceTime()
        {
            return serviceTime;
        }
        
        public void setIsWaiting(bool w)
        {
            isWaiting = w;
        }

        public bool getIsWaiting()
        {
            return isWaiting;
        }
        public System.Windows.Forms.PictureBox getPic()
        {
            return pB;
        }
    }
}