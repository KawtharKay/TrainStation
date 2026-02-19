using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IBookingRepository
    {
        Task AddAsync(Booking booking);
        Task<Booking?> GetAsync(Guid id);
        Task<ICollection<Booking>> GetAll();
        Task<int> GetCount();
        //Task<bool> IsSeatAvailable(int seatNo);
    }
}