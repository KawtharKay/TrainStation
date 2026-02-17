using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Service.Implementation;
using TrainStation.Service.Interface;

namespace TrainStation.Menu
{
    public partial class MainMenu
    {

        public void CustomerMenu()
        {
            Console.WriteLine("1. Book Trip\n2. View Bookings\n#. Logout");
            string option = Console.ReadLine();
            if(option == "1")
            {
                BookingMenu();
                CustomerMenu();
            }
            else if(option == "2")
            {
                ViewCustomerBookingsMenu();
                CustomerMenu();
            }
            else if (option == "#")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Thank you for choosing US!");
                Console.ResetColor();
                Start();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option");
                Console.ResetColor();
            }
        }
        public void BookingMenu()
        {
            var currentTrips = tripService.RecentTrips();
            if(currentTrips.Count  == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("no recent trip");
                Console.ResetColor();
                CustomerMenu();
            }
            Console.WriteLine("Select trip: ");
            foreach (var trip in currentTrips)
            {
                var takeoff = stationService.GetStation(trip.TakeOffLocationId);
                var destination = stationService.GetStation(trip.DestinationId);

                Console.WriteLine($" {trip.Id} : {takeoff.Name} to {destination.Name}");
                
            }
            int tripId = int.Parse(Console.ReadLine());
            bookingService.RegisterBooking(tripId);
        }
        public void ViewCustomerBookingsMenu()
        {
            var customerBookings = bookingService.GetCustomerBookings();
            if (customerBookings.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Bookings available yet, Kindly book a trip");
                Console.ResetColor();
            }
            else
            {
                foreach (var booking in customerBookings)
                {
                    var trip = tripService.GetTrip(booking.TripId);
                    var station = stationService.GetStation(trip.TakeOffLocationId);
                    var destination = stationService.GetStation(trip.DestinationId);
                    Console.WriteLine($"{booking.Id}\t{station.Name} to {destination.Name}\t{booking.RefNo}");  
                }   
            }
        }
    }
}