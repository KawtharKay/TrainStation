using Application.Repositories;
using Application.Response;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class CreateUser
    {
        public record CreateUserCommand(string Email, string Password) : IRequest<BaseResponse<Guid>>;
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
        public class CreateUserHandler(IUserRepository userRepository, IPasswordHasher<string> passwordHasher) : IRequestHandler<CreateUserCommand, BaseResponse<Guid>>
        {
            public async Task<BaseResponse<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
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
                return BaseResponse<Guid>.Success(user.Id, "Success!");
            }
        }
    }
}
