using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Context;
using TrainStation.Model;
using TrainStation.Repository.Interface;

namespace TrainStation.Repository.Implementation
{
    public class StationRepository : IStationRepository
    {
        public void CreateStation(Stations station)
        {
            TrainStationContext.stationsDb.Add(station);
        }

        public List<Stations> GetAll()
        {
            return TrainStationContext.stationsDb;
        }

        public int GetID()
        {
            return TrainStationContext.stationsDb.Count +  1;
        }

        public Stations? GetStationById(int id)
        {
            foreach (var item in TrainStationContext.stationsDb)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public bool nameExists(string name)
        {
            foreach (var item in TrainStationContext.stationsDb)
            {
                if(item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}