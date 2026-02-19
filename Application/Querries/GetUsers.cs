using Application.Repositories;
using Application.Response;
using Mapster;
using MediatR;

namespace Application.Querries
{
    public class GetUsers
    {
        public record GetAllUserQuery() : IRequest<BaseResponse<ICollection<GetAllUserResponse>>>;

        public class GetAllUserHandler(IUserRepository userRepository)
            : IRequestHandler<GetAllUserQuery, BaseResponse<ICollection<GetAllUserResponse>>>
        {
            public async Task<BaseResponse<ICollection<GetAllUserResponse>>> Handle(
                GetAllUserQuery request,
                CancellationToken cancellationToken)
            {
                var response = await userRepository.GetAllAsync();

                var users = response.Select(a => new GetAllUserResponse(
                    a.Id,
                    a.Email,
                    a.UserRoles.Select(ur => new RoleDto(ur.RoleId, ur.Role.Name)).ToList()
                )).ToList();

                return BaseResponse<ICollection<GetAllUserResponse>>.Success(users, "Success!");
            }
        }

        public record GetAllUserResponse(Guid Id, string Email, List<RoleDto> Roles);
        public record RoleDto(Guid Id, string Name);
    }
}