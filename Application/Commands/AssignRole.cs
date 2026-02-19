using Application.Repositories;
using Application.Response;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Commands
{
    public class AssignRole
    {
        public record AssignRoleCommand(Guid RoleId, Guid UserId) : IRequest<BaseResponse<AssignRoleResponse>>;
        public class AssignRoleHandler(IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork) : IRequestHandler<AssignRoleCommand, BaseResponse<AssignRoleResponse>>
        {
            public async Task<BaseResponse<AssignRoleResponse>> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
            {
                var user = await userRepository.GetAsync(request.UserId);
                if (user is null) return BaseResponse<AssignRoleResponse>.Failure("User does not exist");
                var role = await roleRepository.GetAsync(request.RoleId);
                if (role is null) return BaseResponse<AssignRoleResponse>.Failure("Role does not exist");
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = request.RoleId,
                };
                user.UserRoles.Add(userRole);
                await userRoleRepository.AddAsync(userRole);
                await unitOfWork.SaveAsync();
                return BaseResponse<AssignRoleResponse>.Success(userRole.Adapt<AssignRoleResponse>(), "Success!");
            }
        }

        public record AssignRoleResponse(Guid Id, Guid UserId, Guid RoleId, string UserEmail, string RoleName);
    }
}
