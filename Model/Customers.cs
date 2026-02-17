using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainStation.Model
{
    public class Customers : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public Customers(int id, string name, string email) : base(id)
        {
            Name = name;
            Email = email;
        }

    }
}