using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation
{
    public class Fuel
    {
        private readonly double _rate;
        public FuelType Type { get; set; }
        public double Rate { get; }
        public Fuel(FuelType t)
        {
            this.Type = t;
            if(t == FuelType.Diesel)
            {
                this._rate = 80.25;
            }
            else if(t == FuelType.LPG)
            {
                this._rate = 65.75;
            }
            else
            {
                this._rate = 55.40;
            }
        }


    }
}
