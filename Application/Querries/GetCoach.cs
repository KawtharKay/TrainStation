using Application.Repositories;
using Application.Response;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Querries
{
    public class GetCoach
    {
        public record GetCoachQuery(Guid id) : IRequest<BaseResponse<GetCoachResponse>>;
        public class GetCoachHandler : IRequestHandler<GetCoachQuery, BaseResponse<GetCoachResponse>>
        {
            private readonly ICoachRepository _coachRepository;
            public GetCoachHandler(ICoachRepository coachRepository)
            {
                _coachRepository = coachRepository;
            }
            public async Task<BaseResponse<GetCoachResponse>> Handle(GetCoachQuery request, CancellationToken cancellationToken)
            {
                var response = await _coachRepository.GetAsync(request.id);
                if (response is null) throw new Exception($"Coach not found");
                return BaseResponse<GetCoachResponse>.Success(response.Adapt<GetCoachResponse>(), "Success!");
            }
        }
        public record GetCoachResponse(Guid Id, string CoachNo);
    }
}
