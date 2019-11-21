using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Classes
{
    public class Customer : IPerson
    {
        public string FirstName { get; } 
        public string LastName { get; }
        public int SSN { get; }

        public int Id { get; }

        public Customer()
        {
        }

        public Customer(string firstName, string lastName, int sSN, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            SSN = sSN;
            Id = id;
        }




        public override string ToString()
        {
            return $"{FirstName} {LastName} ( {SSN} )";
        }
    }
}
