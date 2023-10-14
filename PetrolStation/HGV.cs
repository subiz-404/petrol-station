using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation
{
    public class HGV : Vehicle
    {
        public HGV(int qCount) : base(150)
        {
            picBox.Image = Properties.Resources.truck;
            picBox.Location = new System.Drawing.Point((281 - (qCount * 70)), 202);
            this.setFuel(FuelType.Diesel);
        }
    }
}
