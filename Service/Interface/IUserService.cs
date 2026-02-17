using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;

namespace TrainStation.Service.Interface
{
    public interface IUserService
    {
        User? Login(string email, string password);
        User? GetCurrentUser();
    }
}