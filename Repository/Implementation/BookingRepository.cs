using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Context;
using TrainStation.Model;
using TrainStation.Repository.Interface;

namespace TrainStation.Repository.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        public void CreateBooking(Bookings bookings)
        {
            TrainStationContext.bookingsDb.Add(bookings);
        }

        public List<Bookings> GetBookings()
        {
            return TrainStationContext.bookingsDb;
        }

        public List<Bookings> GetBookingsByCustomerId(int customerId)
        {
            List<Bookings> customerBookings = new List<Bookings>();
            foreach (var booking in TrainStationContext.bookingsDb)
            {
                if (booking.CustomerId == customerId)
                {
                    customerBookings.Add(booking);
                }
            }
            return customerBookings;
        }

        public int GetID()
        {
            return TrainStationContext.bookingsDb.Count + 1;
        }
    }
}