using Application.Repositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Repositories
{
    public class CurrentUser(IHttpContextAccessor context) : ICurrentUser
    {
        public Guid GetCurrentUser()
        {
            if (context.HttpContext == null)
                throw new InvalidOperationException("GetCurrentUser() called outside of an HTTP request context.");

            var sub = context.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(sub))
                throw new InvalidOperationException("No 'sub' claim found. User may not be authenticated.");

            return Guid.Parse(sub);
        }
    }
}
