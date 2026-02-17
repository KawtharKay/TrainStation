using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Context;
using TrainStation.Model;
using TrainStation.Repository.Interface;

namespace TrainStation.Repository.Implementation
{
    public class TripRepository : ITripRepository
    {
        public void CreateTrip(Trip trip)
        {
            TrainStationContext.tripDb.Add(trip);
        }

        public int GetID()
        {
            return TrainStationContext.tripDb.Count + 1;
        }

        public List<Trip> GetRecentTrips()
        {
            List<Trip> recentTrips = new List<Trip>();
            foreach (var trip in TrainStationContext.tripDb)
            {
                if(trip.TakeOffTime > DateTime.Now)
                {
                    recentTrips.Add(trip);
                }
            }
            return recentTrips;
        }

        public Trip? GetTrip(int id)
        {
            return TrainStationContext.tripDb.Find(trip => trip.Id == id);

        }
    }
}