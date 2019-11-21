using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental.Data.Interfaces
{
    public interface IData
    {
        IEnumerable<IPerson> GetPerson();
        IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default);
        IEnumerable<IBooking> GetBookings();

        IBooking GetBooking(int vehicleId);
        IPerson GetPerson(string socialSecurityNumber);
        IPerson GetPerson(int id);
        IVehicle GetVehicle(string registrationNumber);
        IVehicle GetVehicle(int id);

    }
}
