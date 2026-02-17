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
        public record RegisterPassengerCommand(string Name, string Email, string Password, string PhoneNumber, string EmergencyPhoneNumber) : IRequest<BaseResponse<RegisterPassengerResponse>>;
        public class RegisterPassengerValidator : AbstractValidator<RegisterPassengerCommand>
        {
            public RegisterPassengerValidator()
            {
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

                RuleFor(x => x.Password)
                    .NotEmpty()
                    .WithMessage("Password is required")
                    .MinimumLength(4)
                    .WithMessage("Password must be at least 4 characters long");

                RuleFor(x => x.PhoneNumber)
                    .NotEmpty()
                    .WithMessage("Phone number is required")
                    .Matches(@"^\+?[1-9]\d{1,14}$")
                    .WithMessage("Enter a valid phone number");

                RuleFor(x => x.EmergencyPhoneNumber)
                    .NotEmpty()
                    .WithMessage("Emergency phone number is required")
                    .Matches(@"^\+?[1-9]\d{1,14}$")
                    .WithMessage("Enter a valid emergency phone number")
                    .NotEqual(x => x.PhoneNumber)
                    .WithMessage("Emergency phone number must be different from primary phone number");
            }
        }
        public class RegisterPassengerHandler(IPassengerRepository passengerRepository, IUserRepository userRepository, IPasswordHasher<string> passwordHasher, IUnitOfWork unitOfWork) : IRequestHandler<RegisterPassengerCommand, BaseResponse<RegisterPassengerResponse>>
        {
            public async Task<BaseResponse<RegisterPassengerResponse>> Handle(RegisterPassengerCommand request, CancellationToken cancellationToken)
            {
                var userExist = await userRepository.IsExist(request.Email);
                if (userExist) throw new Exception("Passenger already exist");

                string salt = Guid.NewGuid().ToString();
                var user = new User
                {
                    Email = request.Email,
                    Salt = salt
                };
                string saltPassword = $"{salt}{request.Password}";
                user.HashPassword = passwordHasher.HashPassword(salt, saltPassword);
                await userRepository.AddAsync(user);

                var passenger = new Passenger
                {
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    EmergencyPhoneNumber = request.EmergencyPhoneNumber,
                    Wallet = 0
                };
                await passengerRepository.AddAsync(passenger);
                await unitOfWork.SaveAsync();

                return BaseResponse<RegisterPassengerResponse>.Success(passenger.Adapt<RegisterPassengerResponse>(), "Success!");
            }
        }

        public record RegisterPassengerResponse(Guid Id, string Name, string Email);
    }
}
