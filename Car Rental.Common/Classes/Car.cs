using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes
{
    public class Car : Vehicles
    {
        public Car()
        {
        }

        public Car(int id, string RegistrationNumber, string make, double odometer, double costKM, VehicleTypes types, VehicleStatuses status)
            : base(id, RegistrationNumber, make, odometer, costKM, types, status)
        {
        }
        public override void Start()
        {

        }
    }
}
