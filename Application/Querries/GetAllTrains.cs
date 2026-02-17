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
    public class GetAllTrains
    {
        public class GetAllTrainsQuery : PagingRequest, IRequest<BaseResponse<PaginatedList<GetTrainsResponse>>>
        {
            public bool AllowPaging { get; set; }
        };
        public class GetAllTrainsHandler : IRequestHandler<GetAllTrainsQuery, BaseResponse<PaginatedList<GetTrainsResponse>>>
        {
            private readonly ITrainRepository _trainRepository;
            public GetAllTrainsHandler(ITrainRepository trainRepository)
            {
                _trainRepository = trainRepository;
            }
            public async Task<BaseResponse<PaginatedList<GetTrainsResponse>>> Handle(GetAllTrainsQuery query, CancellationToken cancellationToken)
            {
                var response = await _trainRepository.GetAll(query, query.AllowPaging);
                return BaseResponse<PaginatedList<GetTrainsResponse>>.Success(response.Adapt<PaginatedList<GetTrainsResponse>>(), "Success!");
            }
        }
        public record GetTrainsResponse(Guid Id, string TrainNo, string EngineNo);
    }
}
