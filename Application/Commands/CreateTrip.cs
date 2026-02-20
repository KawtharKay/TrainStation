using Application.Repositories;
using Application.Response;
using Domain.Entities;
using Domain.Enums;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class CreateTrip
    {
        public record CreateTripCommand(Guid TrainId, Guid RouteId, DateTime DepartureDate, TripStatus Status) : IRequest<BaseResponse<CreateTripResponse>>;
        public class CreateTripHandler(ITripRepository tripRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateTripCommand, BaseResponse<CreateTripResponse>>
        {
            public async Task<BaseResponse<CreateTripResponse>> Handle(CreateTripCommand request, CancellationToken cancellationToken)
            {
                var tripExist = await tripRepository.IsExist(request.TrainId, request.RouteId);
                if (tripExist) return BaseResponse<CreateTripResponse>.Failure("Trip already exist");
                Trip trip = new()
                {
                    TrainId = request.TrainId,
                    RouteId = request.RouteId,
                    DepartureDate = request.DepartureDate,
                    Status = request.Status
                };
                await tripRepository.AddAsync(trip);
                await unitOfWork.SaveAsync();
                return BaseResponse<CreateTripResponse>.Success(trip.Adapt<CreateTripResponse>(), "Success");
            }
        }

        public record CreateTripResponse(Guid Id);
    }
}
