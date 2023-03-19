using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation
{
    public class HGV : Vehicle
    {
        public HGV(int qCount)
        {
            vehicleType = "HGV";
            pB.Image = Properties.Resources.truck;
            pB.Location = new System.Drawing.Point((281 - (qCount * 70)), 202);
            Random rnd = new Random();
            this.setTankCapacity(150);
            this.setAvailableFuel(rnd.Next(26) * this.getTankCapacity() / 100);
            this.setFuel("Diesel");
        }
    }
}
