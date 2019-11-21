using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces
{
    public interface IVehicle
    {
         int Id { get; }
         string RegistrationNumber { get; }
         string Make { get; }
         double Odometer { get; set; }
         double CostKM { get; }
         double CostPerDay { get; }
         VehicleTypes Type { get; }
         VehicleStatuses Status { get; set; }


        void Drive(double distance);

    }
}
