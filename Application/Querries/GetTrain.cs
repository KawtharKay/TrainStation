using Application.Repositories;
using Application.Response;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Application.Querries
{
    public class GetTrain
    {
        public record GetTrainQuery(Guid Id) : IRequest<BaseResponse<GetTrainResponse>>;
        public class GetTrainHandler : IRequestHandler<GetTrainQuery, BaseResponse<GetTrainResponse>>
        {
            private readonly ITrainRepository _trainRepository;
            public GetTrainHandler(ITrainRepository trainRepository)
            {
                _trainRepository = trainRepository;
            }
            public async Task<BaseResponse<GetTrainResponse>> Handle(GetTrainQuery request, CancellationToken cancellationToken)
            {
                var response = await _trainRepository.GetAsync(request.Id);
                if (response is null) throw new Exception($"{request.Id} not found");
                return BaseResponse<GetTrainResponse>.Success(response.Adapt<GetTrainResponse>(), "Success!");
            }
        }
        public record GetTrainResponse(Guid Id, string TrainNo, string EngineNo);
    }
}
