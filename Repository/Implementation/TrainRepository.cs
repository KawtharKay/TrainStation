using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Context;
using TrainStation.Model;
using TrainStation.Repository.Interface;

namespace TrainStation.Repository.Implementation
{
    public class TrainRepository : ITrainRepository
    {
        public void CreateTrain(Trains train)
        {
            TrainStationContext.trainsDb.Add(train);
        }

        public int GetTrainID()
        {
            return TrainStationContext.trainsDb.Count + 1;
        }

        public List<Trains> GetTrains()
        {
            return TrainStationContext.trainsDb;
        }

        public bool TrainExist(string trainNo)
        {
            foreach (var train in TrainStationContext.trainsDb)
            {
                if(train.TrainNo == trainNo)
                {
                    return true;
                }
            }
            return false;
        }
    }
}