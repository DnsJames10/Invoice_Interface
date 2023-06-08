using System;
using Interface.Entities;


namespace Interface.Service;


internal class RentalService
{

    public double PricePerHour { get; private set; }
    public double PricePerDay { get; private set; }

    private ITaxService _iTaxService;
    public RentalService(double pricePerHour, double pricePerDay, ITaxService iTaxService)
    {
        PricePerHour = PricePerHour; pricePerDay = pricePerDay; _iTaxService = iTaxService;
    }

    public void ProcessInvoice(CarRental carRental)
    {
        TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

        double basicPayment = 0.0;

        if(duration.TotalHours <= 12)
        {
            basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
        }
        else
        {
            basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
        }

        double tax = _iTaxService.Tax(basicPayment);

        carRental.Invoice = new Invoice(basicPayment, tax);




    }





}
