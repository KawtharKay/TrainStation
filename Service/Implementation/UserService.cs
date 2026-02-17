using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Context;
using TrainStation.Model;
using TrainStation.Repository.Implementation;
using TrainStation.Repository.Interface;
using TrainStation.Service.Interface;

namespace TrainStation.Service.Implementation
{
    public class UserService : IUserService
    {
        public static User? CurrentLoggedInUser;
        IUserRepository userRepository = new UserRepository();

        public User? GetCurrentUser()
        {
            return CurrentLoggedInUser;
        }

        public User? Login(string email, string password)
        {
            var user = userRepository.GetUser(email);
            if (user == null)
            {
                return null;
            }
            if (user.Password != password)
            {
                return null;
            }
            CurrentLoggedInUser = user;
            return user;
        }
    }
}