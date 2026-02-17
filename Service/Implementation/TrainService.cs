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
    public class TrainService : ITrainService
    {
        ITrainRepository trainRepository = new TrainRepository();
        public Trains? CreateTrains(string trainNo)
        {
            var trainExist = trainRepository.TrainExist(trainNo);
            if(trainExist)
            {
                return null;
            }
            Trains trains = new Trains(1, trainNo);
            trainRepository.CreateTrain(trains);
            return trains;
        }

        public List<Trains> GetTrains()
        {
            return trainRepository.GetTrains();
        }
    }
}