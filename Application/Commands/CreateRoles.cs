using Application.Contracts.Common;
using Application.Repositories;
using Application.Response;
using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class CreateRoles
    {
        public record CreateRolesCommand() : IRequest<BaseResponse<string>>;
        public class CreateRolesHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateRolesCommand, BaseResponse<string>>
        {
            public async Task<BaseResponse<string>> Handle(CreateRolesCommand request, CancellationToken cancellationToken)
            {
                foreach(var item in AppRoles.Roles)
                {
                    var roleExist = await roleRepository.IsExistAsync(item);
                    if (roleExist) continue;
                    var role = new Role
                    {
                        Name = item
                    };
                    await roleRepository.AddAsync(role);
                }
                
                await unitOfWork.SaveAsync();
                return BaseResponse<string>.Success("created", "Role sucessfully created");
            }
        }
    }
}
