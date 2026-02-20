using Application.Repositories;
using Application.Response;
using Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class AssignSeat
    {
        public record AssignSeatCommand(Guid SeatId, Guid TripId) : IRequest<BaseResponse<AssignSeatResponse>>;
        public class AssignSeatHandler(ISeatRepository seatRepository, ITripRepository tripRepository, ITripSeatRepository tripSeatRepository, IUnitOfWork unitOfWork) : IRequestHandler<AssignSeatCommand, BaseResponse<AssignSeatResponse>>
        {
            public async Task<BaseResponse<AssignSeatResponse>> Handle(AssignSeatCommand request, CancellationToken cancellationToken)
            {
                var seat = await seatRepository.GetAsync(request.SeatId);
                if (seat is null) throw new Exception("Seat does not exist");
                var trip = await tripRepository.GetAsync(request.TripId);
                if (trip is null) throw new Exception("Trip does not exist");

                var tripSeat = new TripSeat
                {
                    TripId = trip.Id,
                    SeatId = request.SeatId,
                };
                trip.TripSeats.Add(tripSeat);
                await tripSeatRepository.AddAsync(tripSeat);
                await unitOfWork.SaveAsync();
                return BaseResponse<AssignSeatResponse>.Success(tripSeat.Adapt<AssignSeatResponse>(), "Success");
            }
        }

        public record AssignSeatResponse(Guid Id, Guid TripId, Guid SeatId);
    }
}
