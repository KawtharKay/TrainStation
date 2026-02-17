using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;

namespace TrainStation.Repository.Interface
{
    public interface IBookingRepository
    {
        void CreateBooking(Bookings bookings);
        int GetID();
        List<Bookings> GetBookings();
        List<Bookings> GetBookingsByCustomerId(int customerId);
    }
}