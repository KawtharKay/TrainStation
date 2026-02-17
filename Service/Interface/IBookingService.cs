using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;
using TrainStation.Service.Implementation;

namespace TrainStation.Service.Interface
{
    public interface IBookingService
    {
        Bookings RegisterBooking(int trainServiceId);
        List<Bookings> GetBookings();
        List<Bookings> GetCustomerBookings();
    }
}