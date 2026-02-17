using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;
using TrainStation.Repository.Implementation;
using TrainStation.Repository.Interface;
using TrainStation.Service.Interface;

namespace TrainStation.Service.Implementation
{
    public class TripService : ITripService
    {
        ITripRepository tripRepository = new TripRepository();

        public Trip? Create(int takeOff, int destination, DateTime takeOffTime, double price)
        {
            Trip trip= new Trip(tripRepository.GetID(),takeOff,destination,takeOffTime,price);
            tripRepository.CreateTrip(trip);
            return trip;
        }

        public Trip GetTrip(int id)
        {
            return tripRepository.GetTrip(id);
        }

        public List<Trip> RecentTrips()
        {
            return tripRepository.GetRecentTrips();
        }
    }
}