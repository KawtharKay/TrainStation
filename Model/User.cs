using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainStation.Model
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;

        public User(int id, string email, string password, string role) : base(id)
        {
            Email = email;
            Password = password;
            Role = role;
        }
    }
}