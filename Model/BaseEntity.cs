using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainStation.Model
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public BaseEntity(int id)
        {
            Id = id;
        }
    }
}