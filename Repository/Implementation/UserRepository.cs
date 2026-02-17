using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Context;
using TrainStation.Model;
using TrainStation.Repository.Interface;

namespace TrainStation.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        public void CreateUser(User user)
        {
            TrainStationContext.userDb.Add(user);
        }

        public int GetID()
        {
            return TrainStationContext.userDb.Count + 1;
        }

        public User? GetUser(string email)
        {
            foreach (var user in TrainStationContext.userDb)
            {
                if (user.Email == email)
                {
                   return user; 
                }
            }
            return null;
        }
    }
}