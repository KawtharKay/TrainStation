using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;

namespace TrainStation.Repository.Interface
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customers customers);
        bool IsExist(string email);
        int GetID();
        public Customers? GetCustomer(string email);
    }
}