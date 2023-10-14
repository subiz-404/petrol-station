using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolStation
{
    public class VehicleFactory
    {
        public static Vehicle createVehicle(VehicleType type, int qCount)
        {
            Vehicle vehicle = null;

            if (type == VehicleType.Car)
            {
                vehicle = new Car(qCount);
            }
            else if (type == VehicleType.Van)
            {
                vehicle = new Van(qCount);
            }
            else if (type == VehicleType.HGV)
            {
                vehicle = new HGV(qCount);
            }
            
            return vehicle;
        }
    }
}
