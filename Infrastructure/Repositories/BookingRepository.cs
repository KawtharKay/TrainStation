using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TrainStationContext _context;
        public BookingRepository(TrainStationContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

        public async Task<ICollection<Booking>> GetAll()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking?> GetAsync(Guid id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetCount()
        {
            return await _context.Bookings.CountAsync();
        }

        //public async Task<bool> IsSeatAvailable(int seatNo)
        //{
        //    return await _context.Bookings.AnyAsync(x => x.SeatNo == seatNo);
        //}
    }
}
