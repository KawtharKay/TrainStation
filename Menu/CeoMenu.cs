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
        IStationService stationService = new StationService();
        ITrainService trainService= new TrainService();
        IBookingService bookingService = new BookingService();
        ITripService tripService= new TripService();
        public void CeoMenu()
        {
            Console.WriteLine("1. Create Train Stations\n2. Register Trains\n3. Create Trip\n4. Get Bookings\n5. Go back\n#. Logout");
            string option = Console.ReadLine();
            if (option == "1")
            {
                CreateStationMenu();
                CeoMenu();
            }
            else if (option == "2")
            {
                RegisterTrainMenu();
                CeoMenu();
            }
            else if (option == "3")
            {
                RegisterTrainServiceMenu();
                CeoMenu();
            }
            else if (option == "4")
            {
                GetAllBookingsMenu();
                CeoMenu();
            }
            else if(option == "5")
            {
                Start();
            }
            else if (option == "#")
            {
                Console.WriteLine("Thank you");
            }
            else
            {
                Console.WriteLine("Invalid option");
                CeoMenu();
            }
        }

        public void CreateStationMenu()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Address");
            string address = Console.ReadLine();

            var response = stationService.Create(name, address);
            if(response == null)
            {
                Console.WriteLine("station already exist");
            }
            else
            {
                Console.WriteLine("Created successfully");
            }
        }

        public void RegisterTrainMenu()
        {
            Console.Write("Train Number: ");
            string trainNumber = Console.ReadLine();

            var response = trainService.CreateTrains(trainNumber);
            if(response == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Operation failed");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Train successfully created");
                Console.ResetColor();
            }
        }

        public void RegisterTrainServiceMenu()
        {
            Console.WriteLine("Select Take off point: ");
            var stations = stationService.GetStations();
            foreach (var station in stations)
            {
                Console.WriteLine($" {station.Id}.  {station.Name}");
            }
            int takeOffLocationId = int.Parse(Console.ReadLine());

            Console.WriteLine("Select Destination: ");
            foreach (var station in stations)
            {
                if(station.Id == takeOffLocationId)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($" {station.Id}.  {station.Name}");    
                }
            }
            int destinationId = int.Parse(Console.ReadLine());
            Console.Write("Take off time: ");
            DateTime takeOffTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine());

            var response = tripService.Create(takeOffLocationId, destinationId,takeOffTime, price);
            if(response == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Trip service creation failed");
                Console.ResetColor();
            }
            if (response.Price <= 0)
            {
                Console.WriteLine("Price not valid");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Trip created successfully");
                Console.ResetColor();
            }
            
            
        }
        public void GetAllBookingsMenu()
        {
            var bookings = bookingService.GetBookings();
            if(bookings.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No bookings available");
                Console.ResetColor();
            }
            else
            {
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"{booking.Id}\t{booking.RefNo}");
                }
            }
        }   
    }
}