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
    }
}
