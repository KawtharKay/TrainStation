using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainStation.Model
{
    public class Trains : BaseEntity
    {
        public string TrainNo { get; set; } = null!;

        public Trains(int id, string trainNo) : base(id)
        {
            TrainNo = trainNo;
        }
    }
}