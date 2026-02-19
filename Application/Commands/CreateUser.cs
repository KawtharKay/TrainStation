using Application.Repositories;
using Application.Response;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands
{
    public class CreateUser
    {
        public record CreateUserCommand(string Email, string Password) : IRequest<BaseResponse<CreateUserResponse>>;
        public record CreateUserResponse(Guid Id);

        public class CreateUserHandler(IUserRepository userRepository, IPasswordHasher<string> passwordHasher, IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand, BaseResponse<CreateUserResponse>>
        {
            public async Task<BaseResponse<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var userExist = await userRepository.IsExist(request.Email);
                if(userExist) throw new Exception("User already exist");
                string salt = Guid.NewGuid().ToString();
                var user = new User
                {
                    Email = request.Email,
                    Salt = salt
                };
                string saltPassword = $"{salt}{request.Password}";
                user.HashPassword = passwordHasher.HashPassword(salt, saltPassword);
                await userRepository.AddAsync(user);
                await unitOfWork.SaveAsync();
                return BaseResponse<CreateUserResponse>.Success(new CreateUserResponse(user.Id), "Success!");
            }
        }
        public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
        {
            public CreateUserCommandValidator()
            {
                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("Email address is required")
                    .EmailAddress()
                    .WithMessage("Enter a valid email address");
                RuleFor(x => x.Password)
                    .NotEmpty()
                    .WithMessage("Password is required")
                    .MinimumLength(4)
                    .WithMessage("Password must be at least 4 characters long");
            }
        }
    }
}
