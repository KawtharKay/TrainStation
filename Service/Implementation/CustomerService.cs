using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;
using TrainStation.Repository.Implementation;
using TrainStation.Repository.Interface;
using TrainStation.Service.Interface;

namespace TrainStation.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository customerRepository = new CustomerRepository();
        IUserRepository userRepository = new UserRepository();
        public Customers? RegisterCustomer(string name, string email, string password)
        {
            var exist = customerRepository.IsExist(email);
            if (exist)
            {
                return null;
            }
            
            Customers customers = new Customers(customerRepository.GetID(), name, email);
            User user = new User(userRepository.GetID(), email, password, "app_Customer");
            customerRepository.CreateCustomer(customers);
            userRepository.CreateUser(user);
            return customers;
        }
    }
}