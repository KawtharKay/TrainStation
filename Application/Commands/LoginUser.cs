using Application.Repositories;
using Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands
{
    public class LoginUser
    {
        public record LoginUserCommand(string Email, string Password) : IRequest<LoginUserResponse>;
        
        public class LoginUserHandler(IUserRepository userRepository, ITokenService tokenService, IPasswordHasher<string> passwordHasher) : IRequestHandler<LoginUserCommand, LoginUserResponse>
        {
            public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var user = await userRepository.GetAsync(request.Email);
                if (user is null) throw new Exception("User not found");

                string hashPassword = $"{user.Salt}{request.Password}";
                var asd = passwordHasher.VerifyHashedPassword("user", user.HashPassword, hashPassword);
                if(asd == PasswordVerificationResult.Failed) throw new Exception("User not found");

                var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
                var token = tokenService.GenerateToken(new LoginResponse(user.Id, user.Email, roles));
                return new LoginUserResponse(token);
            }
        }
        public record LoginUserResponse(string Token);
        public record LoginResponse(Guid Id, string Email, List<string> Roles);

        public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
        {
            public LoginUserCommandValidator()
            {
                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("Email is required");

                RuleFor(x => x.Password)
                    .NotEmpty()
                    .WithMessage("Password required");
            }
        }
    }
}
