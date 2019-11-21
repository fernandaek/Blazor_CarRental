using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes
{
    public abstract class Vehicles : IVehicle
    {
        public int Id { get; }

        public string RegistrationNumber { get; }

        public string Make { get; }

        public double Odometer { get; set; }

        public double CostKM { get; }


        public double CostPerDay => GetCost(Type);

        public VehicleTypes Type { get; }

        public VehicleStatuses Status { get; set; }



        public Vehicles()
        {
 
        }

        protected Vehicles(int id, string registrationNumber, string make, int odometer, double costKM, VehicleTypes type, VehicleStatuses status)
        {
            Id = id;
            RegistrationNumber = registrationNumber;
            Make = make;
            Odometer = odometer;
            CostKM = costKM;
            Type = type;
            Status = status;
        }

        public double GetCost(VehicleTypes vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleTypes.Sedan:
                    return 100;
                    
                    
                case VehicleTypes.Van:
                    return 300;

                case VehicleTypes.Combi:
                    return 200;

                case VehicleTypes.Motocycle:
                    return 50;

                default:
                    throw new ArgumentException("Vehicle not available!");
            }
        }
        public void Drive(double distance)
        {
            Odometer += distance;
        }

        public abstract void Start();

    }

}