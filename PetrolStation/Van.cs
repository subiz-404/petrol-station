using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation
{
    public class Van : Vehicle
    {

        //overloaded constructor
        public Van(int qCount)
        {
            vehicleType = "Van";
            pB.Image = Properties.Resources.van;
            pB.Location = new System.Drawing.Point((281 - (qCount * 70)), 202);
            Random rnd = new Random();
            this.setTankCapacity(80);
            this.setAvailableFuel(rnd.Next(26) * this.getTankCapacity() / 100);
            if(rnd.Next(2) == 0)
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
