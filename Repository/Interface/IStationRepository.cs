using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;

namespace TrainStation.Repository.Interface
{
    public interface IStationRepository
    {
        bool nameExists(string name);
        int GetID();
        void CreateStation(Stations station);
        List<Stations> GetAll();
        Stations? GetStationById(int id);
    }
}