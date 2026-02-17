using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainStation.Model
{
    public class Stations : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;

        public Stations(int id, string name, string location) : base(id)
        {
            Name = name;
            Location = location;
        }
    }
}