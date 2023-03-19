using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation
{
    public class Pump
    {

        //member variables
        private bool isAvailable;

        //default constructor
        public Pump()
        {
            isAvailable = true;
        }

        //setters/getters
        public void setIsAvailable(bool a)
        {
            isAvailable = a;
        }

        public bool getIsAvailable()
        {
            return isAvailable;
        }
    }
}
