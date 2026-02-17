using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;

namespace TrainStation.Service.Interface
{
    public interface ITripService
    {
        List<Trip> RecentTrips();
        Trip Create(int takeOff, int destination, DateTime takeOffTime,  double price);
        Trip? GetTrip(int id);
    }
}