using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Extensions;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental.Data.Classes
{
    public class CollectionData : IData
    {
        readonly List<IPerson> _persons = new List<IPerson>();
        readonly List<IVehicle> _vehicles = new List<IVehicle>();
        readonly List<IBooking> _bookings = new List<IBooking>();

        public int NextVehicle => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(v => v.Id) + 1;

        public int NextPerson => _persons.Count.Equals(0) ? 1 : _persons.Max(p => p.Id) + 1;

        public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

        public CollectionData()
        {
            SeedData();
        }

   

        private void SeedData()
        {
            //Customers
            _persons.Add(new Customer("Jonh", "Doe", 12345, 1));
            _persons.Add(new Customer("Jane", "Doe", 54321, 2));


            //Vehicles
            _vehicles.AddRange(new List<IVehicle>
            {
                new Car(1, "ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, VehicleStatuses.Available),
                new Car(2, "DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, VehicleStatuses.Available),
                new Car(3, "GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, VehicleStatuses.Available),
                new Car(4, "JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, VehicleStatuses.Available),
                new Car(5, "MNO234", "Yamanha", 30000, 0.5, VehicleTypes.Motocycle, VehicleStatuses.Available),

            });

            //Bookings
            var vehicle1 = _vehicles.Single(v => v.Id.Equals(3));
            vehicle1.Status = VehicleStatuses.Booked;
            var person1 = _persons.Single(v => v.Id.Equals(1));
            _bookings.Add(new Booking(1, vehicle1, person1));

            var vehicle2 = _vehicles.Single(v => v.Id.Equals(4));
            var person2 = _persons.Single(v => v.Id.Equals(2));
            var booking = new Booking(2, vehicle2, person2);
            _bookings.Add(booking);


            //Return vehicle
            vehicle2.Drive(500);
            booking.ReturnVehicle(vehicle2);
            vehicle2.Status = VehicleStatuses.Available;
        }

        public CollectionData(List<IPerson> persons, List<IVehicle> vehicles, List<IBooking> bookings)
        {
            _persons = persons;
            _vehicles = vehicles;
            _bookings = bookings;
        }

        public IBooking GetBooking(int vehicleId)
        {
            return _bookings.Single(b => b.VehicleId.Equals(vehicleId));
        }

        public IEnumerable<IBooking> GetBookings()
        {
            return _bookings;
        }

        public IEnumerable<IPerson> GetPerson()
        {
            return _persons;
        }

        public IPerson GetPerson(string socialSecurityNumber)
        {
            return _persons.Single(p => p.SSN.Equals(socialSecurityNumber));
        }

        public IPerson GetPerson(int id)
        {
            return _persons.Single(p => p.Id.Equals(id));
        }

        public IVehicle GetVehicle(string registrationNumber)
        {
            return _vehicles.Single(v => v.RegistrationNumber.Equals(registrationNumber));
        }

        public IVehicle GetVehicle(int id)
        {
            return _vehicles.Single(v => v.Id.Equals(id));
        }

        public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = 0)
        {
            
            return _vehicles;
        }

        //VG DEL

        public void AddVehicle(IVehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void AddPerson(IPerson customer)
        {
            _persons.Add(customer);
        }

        public IBooking RentVehicle(int vehicleId, int customerId)
        {
            var vehicle = GetVehicle(vehicleId);
            var customer = GetPerson(customerId);

            var newBooking = new Booking(NextBookingId, vehicle, customer);

            _bookings.Add(newBooking);

            return _bookings.Single(b => b.Id.Equals(newBooking.Id));
           // return newBooking;
        }

        public IBooking ReturnVehicle(int vehicleId)
        {
            var booking = _bookings.Single(b => b.VehicleId.Equals(vehicleId) && b.Returned == default);
            var vehicle = GetVehicle(vehicleId);

            booking.ReturnVehicle(vehicle);

            return booking;
        }


        //Trying calculate price
        public double CalculatePrice(IVehicle vehicle, double returnMeterSetting, int duration)
        {
            return vehicle.CostPerDay * duration + vehicle.CostKM * (returnMeterSetting - vehicle.Odometer) * vehicle.CostKM;
        }
    }
}
