using Application.Repositories;
using Application.Response;
using Domain.Entities;
using Domain.Enums;
using Mapster;
using MediatR;
namespace Application.Commands
{
    public class CreateBooking
    {
        public record CreateBookingCommand(int SeatNo, BookingClass BookingClass, Guid RouteId, Guid TakeOffStationId, Guid DestinationStationId, Guid PassengerId) : IRequest<BaseResponse<CreateBookingResponse>>;
        public class CreateBookingHandler(IBookingRepository bookingRepository, IStationRepository stationRepository, IRouteRepository routeRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateBookingCommand, BaseResponse<CreateBookingResponse>>
        {
            public async Task<BaseResponse<CreateBookingResponse>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
            {
                var takeOffStation = await stationRepository.GetAsync(request.TakeOffStationId);
                var destinationStation = await stationRepository.GetAsync(request.DestinationStationId);
                if (takeOffStation is null || destinationStation is null) throw new Exception("Input a valid station selection");

                var route = await routeRepository.GetAsync(request.RouteId);
                if (route is null) throw new Exception("Route does not exist");

                //var seatAvailable = await bookingRepository.IsSeatAvailable(request.SeatNo);
                //if (!seatAvailable) throw new Exception($"Seat number {request.SeatNo} is not available");

                var referenceNo = $"NTS/{DateTime.UtcNow.Year}/00{bookingRepository.GetCount()}";
                var booking = new Booking
                {
                    //ReferenceNo = referenceNo,
                    //BookingClass = request.BookingClass,
                    //SeatNo = request.SeatNo,
                    //RouteId = request.RouteId,
                    TakeoffStationId = request.TakeOffStationId,
                    DestinationStationId = request.DestinationStationId,
                    PassengerId = request.PassengerId,
                    DateCreated = DateTime.UtcNow
                };
                await bookingRepository.AddAsync(booking);
                await unitOfWork.SaveAsync();
                return BaseResponse<CreateBookingResponse>.Success(booking.Adapt<CreateBookingResponse>(), "Success!");
            }
        }
        public record CreateBookingResponse(Guid Id, string ReferenceNo, int SeatNo);
    }
}
