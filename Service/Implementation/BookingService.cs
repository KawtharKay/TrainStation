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
    public class BookingService : IBookingService
    {
        IBookingRepository bookingRepository = new BookingRepository();
        ICustomerRepository customerRepository = new CustomerRepository();
        IUserService userService = new UserService();
        public Bookings RegisterBooking(int trainServiceId)
        {
            string refNo = $"NTS/00{new Random().Next(000,999)}";
            var currentUser = userService.GetCurrentUser();
            var customer = customerRepository.GetCustomer(currentUser.Email);
            Bookings booking = new Bookings(bookingRepository.GetID(),refNo,customer.Id,trainServiceId);
            bookingRepository.CreateBooking(booking);
            return booking;
        }

        public List<Bookings> GetBookings()
        {
            return bookingRepository.GetBookings();
        }

        public List<Bookings> GetCustomerBookings()
        {
            var currentUser = userService.GetCurrentUser();
            var customer = customerRepository.GetCustomer(currentUser.Email);
            var customerBookings = bookingRepository.GetBookingsByCustomerId(customer.Id);
            return customerBookings;
        }
    }
}