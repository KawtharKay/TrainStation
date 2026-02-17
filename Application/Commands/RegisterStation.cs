using Application.Repositories;
using Application.Response;
using Domain.Entities;
using FluentValidation;
using Mapster;
using MediatR;

namespace Application.Commands
{
    public class RegisterStation
    {
        public record RegisterStationCommand(string Name, string City, string State) : IRequest<BaseResponse<RegisterStationResponse>>;
        public class RegisterStationValidator : AbstractValidator<RegisterStationCommand>
        {
            public RegisterStationValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Name is required")
                    .MinimumLength(3)
                    .WithMessage("Name must be at least 3 cracters long");
                RuleFor(x => x.City)
                    .NotEmpty()
                    .WithMessage("City must be stated");
                RuleFor(x => x.State)
                    .NotEmpty()
                    .WithMessage("State must be stated");
            }
        }
        public class RegisterStationHandler : IRequestHandler<RegisterStationCommand, BaseResponse<RegisterStationResponse>>
        {
            private readonly IStationRepository _stationRepository;
            private readonly IUnitOfWork _unitOfWork;
            public RegisterStationHandler(IStationRepository stationRepository, IUnitOfWork unitOfWork)
            {
                _stationRepository = stationRepository;
                _unitOfWork = unitOfWork;
            }
            public async Task<BaseResponse<RegisterStationResponse>> Handle(RegisterStationCommand request, CancellationToken cancellationToken)
            {
                var stationExist = await _stationRepository.IsExist(request.Name);
                if (stationExist) throw new Exception($"{request.Name} already exist");
                var station = new Station
                {
                    Name = request.Name,
                    City = request.City,
                    State = request.State
                };
                await _stationRepository.AddAsync(station);
                await _unitOfWork.SaveAsync();
                return BaseResponse<RegisterStationResponse>.Success(station.Adapt<RegisterStationResponse>(), "Station successfully created");
            }
        }

        public record RegisterStationResponse(Guid Id, string Name);
    }
}
