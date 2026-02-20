using Application.Repositories;
using Application.Response;
using Domain.Entities;
using FluentValidation;
using MediatR;
using static Application.Commands.CreateRole;

namespace Application.Commands
{
    public class CreateRoute
    {
        public record CreateStationRoute(Guid StationId, int StopOrder,int DistanceFromDeparture, DateTime DepartureTime);
        public record CreateRouteCommand(string Name, List<CreateStationRoute> StationRoutes) : IRequest<BaseResponse<Guid>>;
        
        public class CreateRouteHandler (IRouteRepository routeRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateRouteCommand, BaseResponse<Guid>>
        {
            public async Task<BaseResponse<Guid>> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
            {
                var routeExist = await routeRepository.IsExist(request.Name);
                if (routeExist) throw new Exception("Route already exist");
                var route = new Route
                {
                    Name = request.Name
                };

                foreach (var item in request.StationRoutes)
                {
                    var st = new StationRoute
                    {
                        RouteId = route.Id,
                        StationId = item.StationId,
                        StopOrder = item.StopOrder,
                        DistanceFromDeparture = item.DistanceFromDeparture
                    };

                    route.StationRoutes.Add(st);
                }
                await routeRepository.AddAsync(route);
                await unitOfWork.SaveAsync();
                return BaseResponse<Guid>.Success(route.Id, "Route created successfully!");
            }
        }

        public class CreateRouteCommandValidator : AbstractValidator<CreateRouteCommand>
        {
            public CreateRouteCommandValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Route name is required");
            }
        }
    }
}
