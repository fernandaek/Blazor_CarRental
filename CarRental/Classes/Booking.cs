using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Classes
{
    public class Booking : IBooking
    {
        public int Id { get; }

        public int VehicleId { get; }

        public IVehicle Vehicle { get; }

        public string RegNo { get; }

        public IPerson Person { get; }

        public DateTime RentDate { get; }

        public DateTime Returned { get; }

        public double Cost { get; set; } //=> CalculatePrice(Vehicle);//DateExtensions.Duration(RentDate, Returned); //ReturnVehicle(Vehicle);

        public double MilesRented { get; }

        public double MilesReturned { get; }

        public Booking(int id, IVehicle vehicle, IPerson person)
        {
            Id = id;
            VehicleId = vehicle.Id;
            //Vehicle = vehicle;
            RegNo = vehicle.RegistrationNumber;
            RentDate = DateTime.Now;
            Returned = DateTime.Now.AddDays(0);
            MilesRented = vehicle.Odometer;
            MilesReturned = vehicle.Odometer; //vehicle.Drive(0)
            vehicle.Status = VehicleStatuses.Booked;
            //Cost = 500;

            Person = person;

            try
            {
                if (id < 0 || VehicleId < 0 || person == default) throw new AggregateException("Id lower than ZERO.");

            }
            catch 
            {
                throw;
            }
        }


        public void ReturnVehicle(IVehicle vehicle)
        {
            var days = DateExtensions.Duration(Returned, RentDate);

            Cost = days * vehicle.CostPerDay + (MilesRented - vehicle.Odometer) * vehicle.CostKM;
        }
    }
}

