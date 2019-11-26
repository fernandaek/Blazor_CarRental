using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Classes;
using Car_Rental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental.Business.Classes
{
    public class BookingProcessor
    {
        private readonly IData _db = new CollectionData();

        public IEnumerable<IPerson> GetCustomers()
        {
            return _db.GetPerson();
        }


        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
        {
            return _db.GetVehicles(status);
        }


        public IEnumerable<IBooking> GetBookings()
        {
            return _db.GetBookings();
        }


        public IBooking GetBooking(int vehicleId)
        {
            return _db.GetBooking(vehicleId);
        }


        public Customer GetCustomer(int customerId)
        {
            return GetCustomer(customerId);
        }


        public IVehicle GetVehicle(int vehicleId)
        {
            return _db.GetVehicle(vehicleId);
        } 

        public void AddVehicle(string make, string registationNumber, double odometer, double costKm, VehicleStatuses status, VehicleTypes type)
        {
            _db.AddVehicle(new Car(_db.NextVehicle, registationNumber, make, odometer, costKm, type, status));
        }

        public void AddCustomer(int socialSecurityNumber, string firstName, string lastName)
        {
            _db.AddPerson(new Customer(firstName, lastName, socialSecurityNumber, _db.NextPerson));
        }

        public IBooking RentVehicle (int vehicleId, int customerId)
        {
            return _db.RentVehicle(vehicleId, customerId);
        }

        public IBooking ReturnVehicle( int vehicleId, double distance)
        {
            var vehicle = GetVehicle(vehicleId);
            vehicle.Drive(distance);
            var booking = _db.ReturnVehicle(vehicleId);
            vehicle.Status = VehicleStatuses.Available;

            return booking;
        }


        //Calling default interfaces
        public string[] VehicleStatusNames => _db.VehicleTypeNames;
        public string[] VehicleTypeNames => _db.VehicleTypeNames;

        public VehicleStatuses GetVehicleStatus(string name)
        {
            return _db.GetVehicleStatus(name);
        }

        public VehicleTypes GetVehicleType(string name)
        {
            return _db.GetVehicleType(name);
        }
    }
}
