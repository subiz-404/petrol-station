using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation
{
    public class Car : Vehicle
    {
        //overloaded constructor
        public Car(int qCount)
        {
            vehicleType = "Car";
            pB.Image = Properties.Resources.car;
            pB.Location = new System.Drawing.Point((281 - (qCount * 70)), 202);
            Random rnd = new Random();
            this.setTankCapacity(40);
            this.setAvailableFuel(rnd.Next(26) * this.getTankCapacity() / 100);
            int r = rnd.Next(3);
            if(r == 0)
            {
                this.setFuel("Unleaded");
            }
            else if(r == 1)
            {
                this.setFuel("Diesel");
            }
            else
            {
                this.setFuel("LPG");
            }
        }
    }
}
