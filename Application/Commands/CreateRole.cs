using Application.Repositories;
using Application.Response;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class CreateRole
    {
        public record CreateRoleCommand(string Name) : IRequest<BaseResponse<Guid>>;
        public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
        {
            public CreateRoleCommandValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Role name is required");
            }
        }
        public class CreateRoleHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateRoleCommand, BaseResponse<Guid>>
        {
            public async Task<BaseResponse<Guid>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
            {
                var roleExist = await roleRepository.IsExistAsync(request.Name);
                if (roleExist) throw new Exception("Role already exist");
                var role = new Role
                {
                    Name = request.Name
                };
                await roleRepository.AddAsync(role);
                await unitOfWork.SaveAsync();
                return BaseResponse<Guid>.Success(role.Id, "Role sucessfully created");
            }
        }
    }
}
