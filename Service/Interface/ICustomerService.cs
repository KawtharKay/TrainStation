using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;

namespace TrainStation.Service.Interface
{
    public interface ICustomerService
    {
        Customers? RegisterCustomer(string name, string email, string password);
    }
}