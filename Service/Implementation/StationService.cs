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
    public class StationService : IStationService
    {
        IStationRepository stationRepository = new StationRepository();
        public Stations? Create(string name, string address)
        {
            var nameExist = stationRepository.nameExists(name);
            if (nameExist)
            {
                return null;
            }
            Stations stations = new Stations(stationRepository.GetID(), name, address);
            stationRepository.CreateStation(stations);
            return stations;
        }

        public Stations? GetStation(int id)
        {
            return stationRepository.GetStationById(id);
        }

        public List<Stations> GetStations()
        {
            return stationRepository.GetAll();
        }
    }
}