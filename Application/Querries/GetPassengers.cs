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
    public class GetPassengers
    {
        public class GetAllPassengersQuery : PagingRequest, IRequest<BaseResponse<PaginatedList<GetPassengersResponse>>>
        {
            public bool AllowPaging { get; set; }
        }
        public class GetPassengersHandler(IPassengerRepository passengerRepository) : IRequestHandler<GetAllPassengersQuery, BaseResponse<PaginatedList<GetPassengersResponse>>>
        {
            public async Task<BaseResponse<PaginatedList<GetPassengersResponse>>> Handle(GetAllPassengersQuery request, CancellationToken cancellationToken)
            {
                var response = await passengerRepository.GetAllAsync(request, request.AllowPaging);
                return BaseResponse<PaginatedList<GetPassengersResponse>>.Success(response.Adapt<PaginatedList<GetPassengersResponse>>(), "Success!");
            }
        }
        public record GetPassengersResponse(Guid Id, string Name, string Email);
    }
}
