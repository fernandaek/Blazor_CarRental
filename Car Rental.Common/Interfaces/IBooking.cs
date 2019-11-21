using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Rental.Common.Interfaces
{
    public interface IBooking
    {
        
        //How to ärv vehicle interface data?

        public int Id { get; }
        public int VehicleId { get; }
        public string RegNo { get; }
        public IPerson Person { get; }
        public DateTime RentDate { get; }
        public DateTime Returned { get; }
        public double Cost { get; }
        public double MilesRented { get; }
        public double MilesReturned { get; }



        void ReturnVehicle(IVehicle vehicle);


    }
}
