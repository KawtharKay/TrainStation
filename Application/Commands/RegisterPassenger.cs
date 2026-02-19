using Application.Contracts.Common;
using Application.Repositories;
using Application.Response;
using Domain.Entities;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands
{
    public class RegisterPassenger
    {
        public record RegisterPassengerCommand(Guid UserId, string Name, string Email,  string PhoneNumber) : IRequest<BaseResponse<RegisterPassengerResponse>>;
       
        public class RegisterPassengerHandler(IPassengerRepository passengerRepository, IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, IPasswordHasher<string> passwordHasher, IUnitOfWork unitOfWork) : IRequestHandler<RegisterPassengerCommand, BaseResponse<RegisterPassengerResponse>>
        {
            public async Task<BaseResponse<RegisterPassengerResponse>> Handle(RegisterPassengerCommand request, CancellationToken cancellationToken)
            {
                var userExist = await userRepository.IsExist(request.Email);
                if (!userExist) throw new Exception("user does not exist");

                var role = await roleRepository.GetAsync(AppRoles.Passenger);
                if(role is null) throw new Exception("Role already exist");

                var isRoleAssigned = await userRoleRepository.IsExist(request.UserId, role.Id);
                if (isRoleAssigned) throw new Exception("Role already exist");

                var userRole = new UserRole
                {
                    UserId = request.UserId,
                    RoleId = role.Id
                };
                await userRoleRepository.AddAsync(userRole);

                var passenger = new Passenger
                {
                    UserId = request.UserId,
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Wallet = 0
                };
                await passengerRepository.AddAsync(passenger);
                await unitOfWork.SaveAsync();

                return BaseResponse<RegisterPassengerResponse>.Success(passenger.Adapt<RegisterPassengerResponse>(), "Success!");
            }
        }

        public record RegisterPassengerResponse(Guid Id);
        public class RegisterPassengerValidator : AbstractValidator<RegisterPassengerCommand>
        {
            public RegisterPassengerValidator()
            {
                RuleFor(x => x.UserId)
                    .NotEmpty()
                    .WithMessage("UserId is required");

                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Name is required")
                    .MinimumLength(3)
                    .WithMessage("Name must be at least 3 cracters long");

                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("Email is required")
                    .EmailAddress()
                    .WithMessage("Enter a valid Email Address");

                RuleFor(x => x.PhoneNumber)
                    .NotEmpty()
                    .WithMessage("Phone number is required")
                    .Matches(@"^\+?[1-9]\d{1,14}$")
                    .WithMessage("Enter a valid phone number");
            }
        }
    }
}
