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

        //VG DELEN
        int NextVehicle { get; }
        int NextPerson { get; }
        int NextBookingId { get; }

        void AddVehicle(IVehicle vehicle);
        void AddPerson(IPerson customer);

        IBooking RentVehicle(int vehicleId, int customerId);
        IBooking ReturnVehicle(int vehicleId);


        //Default interfaces methods
        public string[] VehicleStatuses => Enum.GetNames(typeof(VehicleStatuses));
        public VehicleStatuses GetVehicleStatus(string name) => (VehicleStatuses)Enum.Parse(typeof(VehicleStatuses), name);
        public string[] VehicleTypeNames => Enum.GetNames(typeof(VehicleTypes));
        public VehicleTypes GetVehicleType(string name) => (VehicleTypes)Enum.Parse(typeof(VehicleTypes), name);

    }
}
