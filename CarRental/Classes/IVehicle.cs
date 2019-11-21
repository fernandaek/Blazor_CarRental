using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Classes
{
    public interface IVehicle
    {
         int Id { get; }
         string RegistrationNumber { get; }
         string Make { get; }
         double Odometer { get; }
         double CostKM { get; }
         double CostPerDay { get; }
         VehicleTypes Type { get; }
         VehicleStatuses Status { get; set; }


        void Drive(double distance);

    }
}
