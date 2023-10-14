using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using MetroFramework.Controls;

namespace PetrolStation
{
    public partial class PetrolPump : MetroFramework.Forms.MetroForm
    {
        //timer for creating new vehicle in queue
        private Timer timer = new Timer();
        private static StreamWriter sw;

        //timer for updating the record in file
        private Timer avlTimer = new Timer();

        //counters for fuel, amount, commission etc
        private double unleadedCount = 0.00;
        private double dieselCount = 0.00;
        private double lpgCount = 0.00;
        private double amount = 0.00;
        private int countServed = 0;
        private int countNotServed = 0;

        //queue of vehicles
        private Queue<Vehicle> queue =  new Queue<Vehicle>();
        public PetrolPump()
        {
            InitializeComponent();
            
            sw = null;
            avlTimer.Tick += new EventHandler(avlTimerTick);
            avlTimer.Interval = (2000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = (1500);
            timer.Enabled = true;
            timer.Start();

            this.fuelPump1.pumpFillingButton.Click += pumpFillingButton_CLick;
            this.fuelPump2.pumpFillingButton.Click += pumpFillingButton_CLick;
            this.fuelPump3.pumpFillingButton.Click += pumpFillingButton_CLick;
            this.fuelPump4.pumpFillingButton.Click += pumpFillingButton_CLick;
            this.fuelPump5.pumpFillingButton.Click += pumpFillingButton_CLick;
            this.fuelPump6.pumpFillingButton.Click += pumpFillingButton_CLick;
            this.fuelPump7.pumpFillingButton.Click += pumpFillingButton_CLick;
            this.fuelPump8.pumpFillingButton.Click += pumpFillingButton_CLick;
            this.fuelPump9.pumpFillingButton.Click += pumpFillingButton_CLick;



            metroLabel1.Show();
        }


        //method for updating queue if car leaves after waiting
        void qUpdate()
        {
            if (queue.Count == 0)
                metroLabel1.Show();
            timer.Start();
            for (int c = 0; c < queue.Count; c++)
            {
                Point p;
                p = queue.ElementAt<Vehicle>(c).picBox.Location;
                queue.ElementAt<Vehicle>(c).picBox.Location = new Point(p.X + 70, 202);
            }
        }

        //method for timer tick whenever timer ticks it adds a new vehicle in queue
        void timer_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();

            //random number between 1500 & 2200
            timer.Interval = rand.Next(1500, 2201);

            //check for number of vehicles in queue (it should be 5 <= vehicles)
            if (queue.Count >= 4) 
                timer.Stop();


            int vehicleNumber = rand.Next(0, 3);
            queue.Enqueue(VehicleFactory.createVehicle(vehicleNumber.ToEnum<VehicleType>(), queue.Count));
            

            //binding listerner with the newly added vehicle
            queue.Last<Vehicle>().cmpTime += new Vehicle.waitCompleteTime(cmpHeardIt);
            this.Controls.Add(queue.Last().picBox);
            metroLabel1.Hide();
            metroLabel2.Hide();
        }

        //serviceComplete delegate is called whenever vehicle is served completely
        public void serviceComplete(Vehicle v, FuelPump p, EventArgs e)
        {
            //setting pump as available
            p.IsAvailable = true;

            if (v.getFuel().Type == FuelType.Unleaded)
            {
                //counting unleaded fuel in liters
                unleadedCount += (v.ServiceTime * 1.5 / 1000);
                unleadedLabel.Text = $"{FuelType.Unleaded.ToString()} (Liters) : {unleadedCount.ToString()}";
            }
            else if (v.getFuel().Type == FuelType.Diesel)
            {
                //counting diesel fuel in liters
                dieselCount += (v.ServiceTime * 1.5 / 1000);
                dieselLabel.Text = $"{FuelType.Diesel.ToString()} (Liters) : {dieselCount.ToString()}";
            }
            else
            {
                //counting lpg fuel in liters
                lpgCount += (v.ServiceTime * 1.5 / 1000);
                lpgLabel.Text = $"{FuelType.LPG.ToString()} (Liters) : {lpgCount.ToString()}";
            }

            //updating total amount of fuel sold
            amount = (dieselCount * 80.25) + (lpgCount * 65.75) + (unleadedCount * 55.40);
            amountLabel.Text = "Amount : " + amount.ToString();

            //updating commission
            commissionLabel.Text = "1% Commission : " + (1 * amount / 100);

            //updating number of served vehicles
            servedLabel.Text = "Vehicles Served : " + ++countServed;

            //writing into the file
            try
            {
                sw = new StreamWriter(RecordsFile.filePath, true);
                sw.WriteLine(v.WaitingTime
                        + ","
                        + (v.ServiceTime * 1.5 / 1000).ToString()
                        + ","
                        + (p.PumpNumber).ToString());
            }
            catch (UnauthorizedAccessException ex)
            {
                FileAttributes attr = (new FileInfo(RecordsFile.filePath)).Attributes;
                if ((attr & FileAttributes.ReadOnly) > 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "UnAuthorizedAccessException: Unable to access Read-only file.");
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "UnAuthorizedAccessException: Unable to access file.");

                }
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }


        }


        private void pumpFillingButton_CLick(object sender, EventArgs e)
        {
            var pump = (sender as MetroButton).Parent as FuelPump;
            if (queue.Count != 0)
            {
                if ((pump.LeftPump != null && !pump.LeftPump.IsAvailable) 
                    || (pump.LeftPump != null && pump.LeftPump.LeftPump != null && !pump.LeftPump.LeftPump.IsAvailable))
                {
                    metroLabel2.Text = $"Pump {pump.PumpNumber} is block!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
                else if (pump.IsAvailable)
                {
                    pump.IsAvailable = false;
                    var vehicle = queue.Dequeue();
                    vehicle.fuelTimer = new System.Windows.Forms.Timer();
                    vehicle.ServiceTime = Vehicle.rnd.Next(17000, 19000);

                    vehicle.fuelTimer.Tick += (s, ev) => vehicle.fuelTimerTick(sender,e, pump);
                    vehicle.fuelTimer.Interval = vehicle.ServiceTime;
                    this.Controls.Remove(vehicle.picBox);
                    pump.ServiceVehicle = vehicle;
                    pump.Controls.Add(vehicle.picBox);
                    pump.ServiceVehicle.picBox.Location = new Point(5, 5);
                    vehicle.getFuelTime().Start();
                    qUpdate();
                    vehicle.tick += new Vehicle.TimerTick(serviceComplete);
                    vehicle.getWaitTimer().Stop();
                }
                else
                {
                    metroLabel2.Text = $"Pump {pump.PumpNumber} Already Occupied!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
            }
        }

        // cmpHeardIt delegate is called whenever a vehicle leaves without being served
        public void cmpHeardIt(Vehicle v, EventArgs e)
        {
            if (queue.Count != 0)
            {
                var goneVehile = queue.Dequeue();
                this.Controls.Remove(goneVehile.picBox);
                //excluding vehicle from queue
                if (goneVehile == v)
                {
                    notServedLabel.Text = "Vehicles Not Served : " + ++countNotServed;
                    qUpdate();
                }
            }
        }

        private void avlTimerTick(Object sender, EventArgs e)
        {
            metroLabel2.Hide();
            avlTimer.Stop();
        }



        //if Check Record button is clicked
        private void metroButton10_Click(object sender, EventArgs e)
        {
            Records f2 = new Records();
            f2.Show();
        }

        private void PetrolPump_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sw != null)
            {
                sw.Close();
            }
        }
    }
}