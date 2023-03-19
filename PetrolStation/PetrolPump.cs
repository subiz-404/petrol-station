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

namespace PetrolStation
{
    public partial class PetrolPump : MetroFramework.Forms.MetroForm
    {
        //timer for creating new vehicle in queue
        private Timer timer = new Timer();

        //timer for updating the record in file
        private Timer avlTimer = new Timer();

        //counters for fuel, amount, commission etc
        private double unleadedCount = 0.00;
        private double dieselCount = 0.00;
        private double lpgCount = 0.00;
        private double amount = 0.00;
        private int countServed = 0;
        private int countNotServed = 0;
        
        //counter for counting number of vehicles in queue
        int count = 0;

        //array of 9 pumps for storing status of pumps
        private Pump[] pump = null;

        //array of vehicles for currently taking service at different pump
        private Vehicle[] service = null;

        //queue of vehicles
        private Queue<Vehicle> queue =  new Queue<Vehicle>();
        public PetrolPump()
        {
            InitializeComponent();
            avlTimer.Tick += new EventHandler(avlTimerTick);
            avlTimer.Interval = (2000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = (1500);
            timer.Enabled = true;
            timer.Start();
            pump = new Pump[9];
            service = new Vehicle[9];
            for(int c = 0; c < 9; c++)
            {
                pump[c] = new Pump();
                service[c] = new Vehicle();
            }
            metroLabel1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //method for updating queue if car leaves after waiting
        void qUpdate()
        {
            count--;
            if (queue.Count == 0)
                metroLabel1.Show();
            timer.Start();
            for (int c = 0; c < queue.Count; c++)
            {
                Point p;
                p = queue.ElementAt<Vehicle>(c).getPic().Location;
                queue.ElementAt<Vehicle>(c).getPic().Location = new Point(p.X + 70, 202);
            }
        }

        //method for timer tick whenever timer ticks it adds a new vehicle in queue
        void timer_Tick(object sender, EventArgs e)
        {
            Random intv = new Random();

            //random number between 1500 & 2200
            timer.Interval = intv.Next(1500, 2201);

            //check for number of vehicles in queue (it should be 5 <= vehicles)
            if (count >= 4) 
                timer.Stop();

           
            Random vhl = new Random();

            if (vhl.Next(1, 4) == 1)
            {
                //adding new car to queue
                queue.Enqueue(new Car(queue.Count));
            }
            else if (vhl.Next(1, 4) == 2)
            {
                //adding new van to queue
                queue.Enqueue(new Van(queue.Count));
            }
            else
            {
                //adding new hgv to queue
                queue.Enqueue(new HGV(queue.Count));
            }

            //binding listerner with the newly added vehicle
            queue.Last<Vehicle>().cmpTime += new Vehicle.waitCompleteTime(cmpHeardIt);
            this.Controls.Add(queue.ElementAt<Vehicle>(count++).getPic());
            metroLabel1.Hide();
            metroLabel2.Hide();
        }

        //serviceComplete delegate is called whenever vehicle is served completely
        public void serviceComplete(Vehicle v, EventArgs e)
        {
            for(int c = 0; c < 9; c++)
            {
                if (v == service[c])
                {
                    //setting pump as available
                    pump[c].setIsAvailable(true);
                    
                    if (service[c].getFuel().getName().Equals("Unleaded"))
                    {
                        //counting unleaded fuel in liters
                        unleadedCount += (service[c].getServiceTime() * 1.5 / 1000);
                        unleadedLabel.Text = "Unleaded (Liters) : " + unleadedCount.ToString();
                    }
                    else if(service[c].getFuel().getName().Equals("Diesel"))
                    {
                        //counting diesel fuel in liters
                        dieselCount += (service[c].getServiceTime() * 1.5 / 1000);
                        dieselLabel.Text = "Diesel (Liters) : " + dieselCount.ToString();
                    }
                    else
                    {
                        //counting lpg fuel in liters
                        lpgCount += (service[c].getServiceTime() * 1.5 / 1000);
                        lpgLabel.Text = "LPG (Liters) : " + lpgCount.ToString();
                    }

                    //updating total amount of fuel sold
                    amount = (dieselCount * 80.25) + (lpgCount * 65.75) + (unleadedCount * 55.40);
                    amountLabel.Text = "Amount : " + amount.ToString();

                    //updating commission
                    commissionLabel.Text = "1% Commission : " + (1 * amount / 100);

                    //updating number of served vehicles
                    servedLabel.Text = "Vehicles Served : " + ++countServed;

                    //writing into the file
                    StreamWriter sw = null;
                    try
                    {
                        sw = new StreamWriter(RecordsFile.filePath, true);
                        sw.WriteLine(service[c].getVehicleType() 
                                + "," 
                                + (service[c].getServiceTime() * 1.5 / 1000).ToString() 
                                + "," 
                                + (c + 1).ToString());
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
            }
        }


        // cmpHeardIt delegate is called whenever a vehicle leaves without being served
        public void cmpHeardIt(Vehicle v, EventArgs e)
        {
            if (queue.Count != 0)
            {
                //excluding vehicle from queue
                if (queue.Dequeue() == v)
                {
                    notServedLabel.Text = "Vehicles Not Served : " + ++countNotServed;
                    qUpdate();
                }
            }
        }

        private void Form1_tick(Vehicle v, EventArgs e)
        {
            throw new NotImplementedException();
        }

        //if pump 1 is clicked for service
        private void metroButton1_Click(object sender, EventArgs e)
        {
            //if queue isn'y empty
            if (queue.Count != 0)
            {
                //if pump 1 is available
                if (pump[0].getIsAvailable())
                {
                    pump[0].setIsAvailable(false);
                    service[0] = queue.Dequeue();
                    service[0].getPic().Location = new Point(463, 119);
                    service[0].getFuelTime().Start();
                    qUpdate();
                    service[0].tick += new Vehicle.TimerTick(serviceComplete);
                    service[0].getWaitTimer().Stop();
                }
                else
                {
                    metroLabel2.Text = "Pump 1 Already Occupied!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
            }
        }

        //if pump 2 is clicked for service
        private void metroButton2_Click(object sender, EventArgs e)
        {

            if (queue.Count != 0)
            { 
                //if pump 1 blocks the way of pump 2
                if (!pump[0].getIsAvailable())
                {
                    metroLabel2.Text = "Pump 2 is block!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
                //if pump 2 is available
                else if (pump[1].getIsAvailable())
                {
                    pump[1].setIsAvailable(false);
                    service[1] = queue.Dequeue();
                    service[1].getPic().Location = new Point(616, 119);
                    service[1].getFuelTime().Start();
                    qUpdate();
                    service[1].tick += new Vehicle.TimerTick(serviceComplete);
                    service[1].getWaitTimer().Stop();
                }
                else
                {
                    metroLabel2.Text = "Pump 2 Already Occupied!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
            }
        }

        //if pump 3 is clicked for service
        private void metroButton3_Click(object sender, EventArgs e)
        {
            //if queue isn't empty
            if (queue.Count != 0)
            {
                //if pump 1 or 2 blocks the way of pump 3
                if (!pump[0].getIsAvailable() || !pump[1].getIsAvailable())
                {
                    metroLabel2.Text = "Pump 3 is block!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
                //if pump 3 is available
                else if (pump[2].getIsAvailable())
                {
                    pump[2].setIsAvailable(false);
                    service[2] = queue.Dequeue();
                    service[2].getPic().Location = new Point(768, 119);
                    service[2].getFuelTime().Start();
                    qUpdate();
                    service[2].tick += new Vehicle.TimerTick(serviceComplete);
                    service[2].getWaitTimer().Stop();
                }
                else
                {
                    metroLabel2.Text = "Pump 3 Already Occupied!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
            }
        }

        //if pump 4 is clicked for service
        private void metroButton4_Click(object sender, EventArgs e)
        {
            //if queue isn't empty
            if (queue.Count != 0)
            {
                //if pump 4 is available
                if (pump[3].getIsAvailable())
                {
                    pump[3].setIsAvailable(false);
                    service[3] = queue.Dequeue();
                    service[3].getPic().Location = new Point(463, 202);
                    service[3].getFuelTime().Start();
                    qUpdate();
                    service[3].tick += new Vehicle.TimerTick(serviceComplete);
                    service[3].getWaitTimer().Stop();
                }
                else
                {
                    metroLabel2.Text = "Pump 4 Already Occupied!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
            }
        }

        //if pump 5 is clicked for service
        private void metroButton5_Click(object sender, EventArgs e)
        {
            //if queue isn't empty
            if (queue.Count != 0)
            {
                //if pump 4 blocks the way of pump 5
                if (!pump[3].getIsAvailable())
                {
                    metroLabel2.Text = "Pump 5 is block!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
                //if pump 5 is available
                else if (pump[4].getIsAvailable())
                {
                    pump[4].setIsAvailable(false);
                    service[4] = queue.Dequeue();
                    service[4].getPic().Location = new Point(616, 202);
                    service[4].getFuelTime().Start();
                    qUpdate();
                    service[4].tick += new Vehicle.TimerTick(serviceComplete);
                    service[4].getWaitTimer().Stop();
                }
                
                else
                {
                    metroLabel2.Text = "Pump 5 Already Occupied!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
            }
        }


        //if pump 6 is clicked for service
        private void metroButton6_Click(object sender, EventArgs e)
        {
            //if queue isn't empty
            if (queue.Count != 0)
            {
                //if pump 4 or 5 blocks the way of pump 6
                if (!pump[4].getIsAvailable() || !pump[3].getIsAvailable())
                {
                    metroLabel2.Text = "Pump 6 is block!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
                //if pump 6 is availabale
                else if (pump[5].getIsAvailable())
                {
                    pump[5].setIsAvailable(false);
                    service[5] = queue.Dequeue();
                    service[5].getPic().Location = new Point(768, 202);
                    service[5].getFuelTime().Start();
                    qUpdate();
                    service[5].tick += new Vehicle.TimerTick(serviceComplete);
                    service[5].getWaitTimer().Stop();
                }
                else
                {
                    metroLabel2.Text = "Pump 6 Already Occupied!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
            }
        }

        //if pump 7 is clicked for service
        private void metroButton7_Click(object sender, EventArgs e)
        {
            //if queue isn't empty
            if (queue.Count != 0)
            {
                //if pump 7 is availabale
                if (pump[6].getIsAvailable())
                {
                    pump[6].setIsAvailable(false);
                    service[6] = queue.Dequeue();
                    service[6].getPic().Location = new Point(463, 284);
                    service[6].getFuelTime().Start();
                    qUpdate();
                    service[6].tick += new Vehicle.TimerTick(serviceComplete);
                    service[6].getWaitTimer().Stop();
                }
                else
                {
                    metroLabel2.Text = "Pump 7 Already Occupied!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
            }
        }

        //if pump 8 is clicked for service
        private void metroButton8_Click(object sender, EventArgs e)
        {
            //if queue isn't empty
            if (queue.Count != 0)
            {
                //if pump 7 blocks the way of pump 8
                if (!pump[6].getIsAvailable())
                {
                    metroLabel2.Text = "Pump 8 is block!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
                //if pump 8 is availabale
                else if (pump[7].getIsAvailable())
                {
                    pump[7].setIsAvailable(false);
                    service[7] = queue.Dequeue();
                    service[7].getPic().Location = new Point(616, 284);
                    service[7].getFuelTime().Start();
                    qUpdate();
                    service[7].tick += new Vehicle.TimerTick(serviceComplete);
                    service[7].getWaitTimer().Stop();
                }
                else
                {
                    metroLabel2.Text = "Pump 8 Already Occupied!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
            }
        }

        //if pump 8 is clicked for service
        private void metroButton9_Click(object sender, EventArgs e)
        {
            if (queue.Count != 0)
            {
                //if pump 7 or 8 blocks the way of pump 9
                if (!pump[7].getIsAvailable() || !pump[6].getIsAvailable())
                {
                    metroLabel2.Text = "Pump 9 is block!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
                //if pump 9 is availabale
                else if (pump[8].getIsAvailable())
                {
                    
                    pump[8].setIsAvailable(false);
                    service[8] = queue.Dequeue();
                    service[8].getPic().Location = new Point(768, 284);
                    service[8].getFuelTime().Start();
                    qUpdate();
                    service[8].tick += new Vehicle.TimerTick(serviceComplete);
                    service[8].getWaitTimer().Stop();
                }
                else
                {
                    metroLabel2.Text = "Pump 9 Already Occupied!";
                    metroLabel2.Show();
                    avlTimer.Enabled = true;
                    avlTimer.Start();
                }
            }
        }


        private void avlTimerTick(Object sender, EventArgs e)
        {
            metroLabel2.Hide();
            avlTimer.Stop();
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void amountLabel_Click(object sender, EventArgs e)
        {

        }

        //if Check Record button is clicked
        private void metroButton10_Click(object sender, EventArgs e)
        {
            Records f2 = new Records();
            f2.Show();
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}