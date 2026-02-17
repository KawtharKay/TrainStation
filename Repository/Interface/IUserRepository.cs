using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;

namespace TrainStation.Repository.Interface
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        int GetID();
        User? GetUser(string email);
    }
}