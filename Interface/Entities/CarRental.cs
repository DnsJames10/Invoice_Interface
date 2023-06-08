using System;

namespace Interface.Entities
{
    internal class CarRental
    {

        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Vehicles Vehicles { get; set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime start, DateTime finish, Vehicles vehicles)
        {
            Start = start; Finish = finish; Vehicles = vehicles; Invoice = null;
        }


    }
}
