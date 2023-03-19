using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation
{
    public class Fuel
    {

        //member variables
        private string name;
        private double rate;

        //defualt constructor
        public Fuel(string n)
        {
            this.setName(n);
            if(this.getName().Equals("Diesel"))
            {
                this.setRate(80.25);
            }
            else if(this.getName().Equals("LPG"))
            {
                this.setRate(65.75);
            }
            else
            {
                this.setRate(55.40);
            }
        }


        //setter getters
        public void setName(string n)
        {
            name = n;
        }
        public string getName()
        {
            return name;
        }

        public void setRate(double r)
        {
            rate = r;
        }

        public double getRate()
        {
            return rate;
        }
    }
}
