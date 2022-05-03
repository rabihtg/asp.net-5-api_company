using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using PersonalProjectClassLibrary.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Policies
{
    public class Over21AgeAuthHandler: AuthorizationHandler<Over21AgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, Over21AgeRequirement requirement)
        {
            if(context.User.HasClaim(cl => cl.Type == "age"))
            {
                if (int.TryParse(context.User.Claims.SingleOrDefault(c => c.Type == "age").Value, out var foundAge))
                {
                    if (foundAge > requirement.RequiredAge)
                    {
                        context.Succeed(requirement);
                        return Task.CompletedTask;
                    }
                }
            }

            throw new BadHttpRequestException("Authentication Failed; Some reuirements are not met.", 403);
        }
    }
}
