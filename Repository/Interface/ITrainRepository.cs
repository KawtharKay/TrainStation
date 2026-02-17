using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;

namespace TrainStation.Repository.Interface
{
    public interface ITrainRepository
    {
        void CreateTrain(Trains train);
        int GetTrainID();
        bool TrainExist(string trainNo);
        List<Trains> GetTrains();
    }
}