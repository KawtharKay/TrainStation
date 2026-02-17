using Application.Paging;
using Application.Repositories;
using Application.Response;
using Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Querries
{
    public class GetStations
    {
        public class GetStationsQuery : PagingRequest, IRequest<BaseResponse<PaginatedList<GetStationsResponse>>>
            {
                public bool AllowPaging { get; set; }
            };
        public class GetStationsHandler : IRequestHandler<GetStationsQuery, BaseResponse<PaginatedList<GetStationsResponse>>>
        {
            private readonly IStationRepository _stationRepository;
            public GetStationsHandler(IStationRepository stationRepository)
            {
                _stationRepository = stationRepository;
            }
            public async Task<BaseResponse<PaginatedList<GetStationsResponse>>> Handle(GetStationsQuery request, CancellationToken cancellationToken)
            {
                var response = await _stationRepository.GetAll(request, request.AllowPaging);
                return BaseResponse<PaginatedList<GetStationsResponse>>.Success(response.Adapt<PaginatedList<GetStationsResponse>>(), "Success!");
            }
        }
        public record GetStationsResponse(Guid Id,string Name, string City, string State);
    }
}
