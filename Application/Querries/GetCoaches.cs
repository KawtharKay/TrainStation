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
    public class GetCoaches
    {
        public class GetAllCoachesQuery : PagingRequest, IRequest<BaseResponse<PaginatedList<GetCoachesResponse>>>
        {
            public bool allowPaging {  get; set; }
        }
        public class GetAllCoachesHandler : IRequestHandler<GetAllCoachesQuery, BaseResponse<PaginatedList<GetCoachesResponse>>>
        {
            private readonly ICoachRepository _coachRepository;
            public GetAllCoachesHandler(ICoachRepository coachRepository)
            {
                _coachRepository = coachRepository;
            }
            public async Task<BaseResponse<PaginatedList<GetCoachesResponse>>> Handle(GetAllCoachesQuery request, CancellationToken cancellationToken)
            {
                var response = await _coachRepository.GetAllAsync(request, request.allowPaging);
                return BaseResponse<PaginatedList<GetCoachesResponse>>.Success(response.Adapt<PaginatedList<GetCoachesResponse>>(), "Success!");
            }
        }
        public record GetCoachesResponse(string CoachNo, int Capacity);
    }
}
