using Application.Repositories;
using Application.Response;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Querries
{
    public class GetPassenger
    {
        public record GetPassengerQuery(Guid Id) : IRequest<BaseResponse<GetPassengerResponse>>;
        public record GetPassengerHandler(IPassengerRepository PassengerRepository) : IRequestHandler<GetPassengerQuery, BaseResponse<GetPassengerResponse>>
        {
            public async Task<BaseResponse<GetPassengerResponse>> Handle(GetPassengerQuery request, CancellationToken cancellationToken)
            {
                var response = await PassengerRepository.GetAsync(request.Id);
                if (response is null) throw new Exception("Passenger not found");
                return BaseResponse<GetPassengerResponse>.Success(response.Adapt<GetPassengerResponse>(), "Success!");
            }
        }
        public record GetPassengerResponse(Guid Id, string Name);
    }
}
