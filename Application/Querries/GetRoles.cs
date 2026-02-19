using Application.Repositories;
using Application.Response;
using Mapster;
using MediatR;

namespace Application.Querries
{
    public class GetRoles
    {
        public record GetAllRolesQuery : IRequest<BaseResponse<ICollection<GetAllRolesResponse>>>;
        public class GetAllRolesHandler(IRoleRepository roleRepository) : IRequestHandler<GetAllRolesQuery, BaseResponse<ICollection<GetAllRolesResponse>>>
        {
            public async Task<BaseResponse<ICollection<GetAllRolesResponse>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
            {
                var response = await roleRepository.GetAllAsync();
                return BaseResponse<ICollection<GetAllRolesResponse>>.Success(response.Adapt<ICollection<GetAllRolesResponse>>(), "Success");
            }
        }

        public record GetAllRolesResponse(Guid Id, string Name);
    }
}
