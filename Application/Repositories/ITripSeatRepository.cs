using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface ITripSeatRepository
    {
        Task AddAsync(TripSeat tripSeat);
    }
}
