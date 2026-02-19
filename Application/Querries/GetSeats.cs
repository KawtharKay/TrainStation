using Application.Repositories;
using Application.Response;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Querries
{
    public class GetSeats
    {
        public record GetSeatsQuery(Guid CoachId) : IRequest<BaseResponse<ICollection<GetSeatsResponse>>>;
        public class GetSeatsHandler(ISeatRepository seatRepository) : IRequestHandler<GetSeatsQuery, BaseResponse<ICollection<GetSeatsResponse>>>
        {
            public async Task<BaseResponse<ICollection<GetSeatsResponse>>> Handle(GetSeatsQuery request, CancellationToken cancellationToken)
            {
                var response = await seatRepository.GetAllAsync(request.CoachId);
                return BaseResponse<ICollection<GetSeatsResponse>>.Success(response.Adapt<ICollection<GetSeatsResponse>>(), "Success!");
            }
        }

        public record GetSeatsResponse(Guid Id, int SeatNo);
    }
}
