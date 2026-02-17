using Application.Repositories;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Querries
{
    public class GetStation
    {
        public record GetStationQuery(Guid Id) : IRequest<BaseResponse<Guid>>;
        public class GetStationHandler : IRequestHandler<GetStationQuery, BaseResponse<Guid>>
        {
            private readonly IStationRepository _stationRepository;
            public GetStationHandler(IStationRepository stationRepository)
            {
                _stationRepository = stationRepository;
            }
            public async Task<BaseResponse<Guid>> Handle(GetStationQuery request, CancellationToken cancellationToken)
            {
                var response = await _stationRepository.GetAsync(request.Id);
                if (response is null) throw new Exception("Station not found");
                return BaseResponse<Guid>.Success(response.Id, "Success!");
            }
        }
    }
}
