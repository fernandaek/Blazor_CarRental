using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Classes
{
    public class BP_old
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
