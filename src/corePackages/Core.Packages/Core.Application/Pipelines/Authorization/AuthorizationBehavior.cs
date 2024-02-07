using MediatR;
using Microsoft.AspNetCore.Http;
using Core.Security.Extensions;
using Core.Security.Constants;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.IdentityModel.Tokens;

namespace Core.Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<string>? userRolesClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

        if (userRolesClaims == null)
            throw new AuthorizationException("You are not authenticated!");

        bool isNotMatchedAUserRoleClaimWithRequestedRoles = userRolesClaims
            .FirstOrDefault(userRolesClaim => userRolesClaim == GeneralOperationClaims.Admin || request.Roles.Any(role => role == userRolesClaim))
            .IsNullOrEmpty();

        if (isNotMatchedAUserRoleClaimWithRequestedRoles)
            throw new AuthorizationException("You are not authorized!");

        TResponse response = await next();

        return response;
    }
}
