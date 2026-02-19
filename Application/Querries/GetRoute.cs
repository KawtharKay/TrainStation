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
    public class GetRoute
    {
        public record GetRouteQuery(Guid Id) : IRequest<BaseResponse<GetRouteResponse>>;
        public class GetRouteHandler(IRouteRepository routeRepository) : IRequestHandler<GetRouteQuery, BaseResponse<GetRouteResponse>>
        {
            public async Task<BaseResponse<GetRouteResponse>> Handle(GetRouteQuery request, CancellationToken cancellationToken)
            {
                var response = await routeRepository.GetAsync(request.Id);
                if (response is null) throw new Exception("Route does not exist");

                //var stationRoutes = response.StationRoutes.Select(a => new StationRouteResponse(a.StationId, a.DepartureTime,a.Station.Name, a.StopOrder)).OrderBy(s => s.StopOrder).ToList();
                var asd = response.Adapt<GetRouteResponse>();

                return BaseResponse<GetRouteResponse>.Success(asd, "Success!");
            }
        }

        public record GetRouteResponse(Guid Id, string Name, List<StationRouteResponse> Stations);
        public record StationRouteResponse(Guid StationId, DateTime DepartureTime, string StationName,  int StopOrder);
    }
}
