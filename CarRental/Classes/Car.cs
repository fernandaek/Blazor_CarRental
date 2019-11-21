using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Classes
{
    public class Car : Vehicles
    {
        public Car()
        {
        }

        public Car(int id, string RegistrationNumber, string make, int odometer, double costKM, VehicleTypes types, VehicleStatuses status)
            : base(id, RegistrationNumber, make, odometer, costKM, types, status)
        {
        }
        public override void Start()
        {

        }
    }
}
