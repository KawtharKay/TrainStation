using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;

namespace TrainStation.Repository.Interface
{
    public interface ITripRepository
    {
        List<Trip> GetRecentTrips();
        void CreateTrip(Trip trip);
        int GetID();
        Trip GetTrip(int id);
    }
}