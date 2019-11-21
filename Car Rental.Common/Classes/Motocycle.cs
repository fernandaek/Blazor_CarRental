using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes
{
    public class Motocycle : Vehicles
    {
        public Motocycle(int id, string registrationNumber, string make, int odometer, double costKM, VehicleTypes type, VehicleStatuses status) 
            : base(id, registrationNumber, make, odometer, costKM, type, status)
        {
        }

        public override void Start()
        {

        }

    }

}
