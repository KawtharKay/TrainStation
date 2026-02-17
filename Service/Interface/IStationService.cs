using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;

namespace TrainStation.Service.Interface
{
    public interface IStationService
    {
        Stations? Create(string name, string address);
        List<Stations> GetStations();
        Stations? GetStation(int id);
    }
}