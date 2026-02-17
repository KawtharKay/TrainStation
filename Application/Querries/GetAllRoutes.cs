using Application.Paging;
using Application.Repositories;
using Application.Response;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Querries
{
    public class GetAllRoutes
    {
        public class GetAllRoutesQuery() : PagingRequest, IRequest<BaseResponse<PaginatedList<GetAllRoutesResponse>>>
        {
            public bool AllowPaging { get; set; }
        }
        public class GetAllRoutesHandler(IRouteRepository routeRepository) : IRequestHandler<GetAllRoutesQuery, BaseResponse<PaginatedList<GetAllRoutesResponse>>>
        {
            public async Task<BaseResponse<PaginatedList<GetAllRoutesResponse>>> Handle(GetAllRoutesQuery query, CancellationToken cancellationToken)
            {
                var response = await routeRepository.GetAllAsync(query, query.AllowPaging);
                return BaseResponse<PaginatedList<GetAllRoutesResponse>>.Success(response.Adapt<PaginatedList<GetAllRoutesResponse>>(), "Success!");
            }
        }
        public record GetAllRoutesResponse(Guid Id, string Name);
    }
}
