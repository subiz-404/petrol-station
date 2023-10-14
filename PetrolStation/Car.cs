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
        public Car(int qCount): base(40)
        {
            picBox.Image = Properties.Resources.car;
            picBox.Location = new System.Drawing.Point((281 - (qCount * 70)), 202);
            int r = rnd.Next(3);
            this.setFuel(r.ToEnum<FuelType>());
        }
    }
}
