using System.Globalization;
using Interface.Entities;
using Interface.Service;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter Rental Data");
            Console.Write("Car Model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (MM/dd/yyyy hh:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(),"MM/dd/yyyy HH:mm",CultureInfo.InvariantCulture);
            Console.Write("Finish (MM/dd/yyyy hh:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(),"MM/dd/yyyy HH:mm",CultureInfo.InvariantCulture);
            CarRental carRental = new CarRental(start, finish, new Vehicles(model));
            Console.Write("Enter price per hour: ");
            double pricePerHour = double.Parse(Console.ReadLine());
            Console.Write("Enter price per Day: ");
            double pricePerDay = double.Parse(Console.ReadLine());
            RentalService rentalService = new RentalService(pricePerHour, pricePerDay, new BrazilTaxService());
            rentalService.ProcessInvoice(carRental);
            
            Console.WriteLine("INVOICE");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.Write(carRental.Invoice);
            Console.WriteLine();
            Console.WriteLine("-------------------------");



        }
    }
}