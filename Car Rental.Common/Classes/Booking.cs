using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Rental.Common.Classes
{
        public class Booking : IBooking
        {
            public int Id { get; }

            public int VehicleId { get; }

            public IVehicle Vehicle { get; }

            public string RegNo { get; }

            public IPerson Person { get; }

            public DateTime RentDate { get; }

            public DateTime Returned { get; private set; }

            public double Cost { get; private set; } //=> CalculatePrice(Vehicle);//DateExtensions.Duration(RentDate, Returned); //ReturnVehicle(Vehicle);

            public double MilesRented { get; }

            public double MilesReturned { get; private set; }

            public Booking(int id, IVehicle vehicle, IPerson person)
            {
                Id = id;
                VehicleId = vehicle.Id;
                //Vehicle = vehicle;
                RegNo = vehicle.RegistrationNumber;
                RentDate = DateTime.Now;
                Returned = DateTime.MinValue;
                MilesRented = vehicle.Odometer;
                MilesReturned = default;
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
                Returned = DateTime.Now.AddDays(3);
                var days = RentDate.Duration(Returned);
                MilesReturned = vehicle.Odometer;
                Cost = days * vehicle.CostPerDay + (MilesReturned - MilesRented) * vehicle.CostKM;
            }
        }
}
