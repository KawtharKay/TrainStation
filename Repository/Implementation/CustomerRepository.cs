using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Context;
using TrainStation.Model;
using TrainStation.Repository.Interface;

namespace TrainStation.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        public void CreateCustomer(Customers customers)
        {
            TrainStationContext.customersDb.Add(customers);
        }

        public Customers? GetCustomer(string email)
        {
            foreach (var customer in TrainStationContext.customersDb)
            {
                if (customer.Email == email)
                {
                    return customer;
                }
            }
            return null;
        }

        public int GetID()
        {
            return TrainStationContext.customersDb.Count + 1;
        }

        public bool IsExist(string email)
        {
            foreach (var customer in TrainStationContext.customersDb)
            {
                if (customer.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
    }
}