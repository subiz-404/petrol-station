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
        public Van(int qCount): base(80)
        {
            picBox.Image = Properties.Resources.van;
            picBox.Location = new System.Drawing.Point((281 - (qCount * 70)), 202);
            int f = rnd.Next(1, 3);
            this.setFuel(f.ToEnum<FuelType>());

        }
    }
}
