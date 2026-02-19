using Application.Paging;
using Application.Repositories;
using Application.Response;
using Mapster;
using MediatR;

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
        public record GetCoachesResponse(Guid Id, string CoachNo, int Capacity);
    }
}
