using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;

namespace TrainStation.Service.Interface
{
    public interface ITrainService
    {
        Trains? CreateTrains(string trainNo);
        List<Trains> GetTrains();
    }
}