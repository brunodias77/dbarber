using Azure;
using DB.Application.Communications.Resposes.Errors;
using DB.Domain.Repositories;
using DB.Domain.Token;
using DB.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace DB.Api.Filters;

// Filtro de autorização que verifica se o usuário está autenticado com um token válido
public class AuthenticatedUserFilter : IAsyncAuthorizationFilter
{
    public AuthenticatedUserFilter(IAccessTokenValidator accessTokenValidator, IUserRepository userRepository)
    {
        _accessTokenValidator = accessTokenValidator;
        _userRepository = userRepository;
    }

    private readonly IAccessTokenValidator _accessTokenValidator;
    private readonly IUserRepository _userRepository;

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context);

            var userIdentifier = _accessTokenValidator.ValidateAndGetUserIdentifier(token);

            var exist = await _userRepository.ExistActiveUserWithIdentifier(userIdentifier);
            if (!exist)
            {
                throw new UnauthorizedException(ResourceMessagesException.USER_WITHOUT_PERMISSION_TO_ACCESS_RESOURCES);
            }
        }
        catch (SecurityTokenExpiredException)
        {
            context.Result = new UnauthorizedObjectResult(new ResponseErrorJson("TokenIsExpired")
            {
                TokenExpired = true,
            });
        }
        catch (ExceptionBase exceptionBase)
        {
            context.HttpContext.Response.StatusCode = (int)exceptionBase.GetStatusCode();
            context.Result = new ObjectResult(new ResponseErrorJson(exceptionBase.GetErrorMessages()));
        }
        catch
        {
            context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(ResourceMessagesException.USER_WITHOUT_PERMISSION_TO_ACCESS_RESOURCES));
        }
    }

    private static string TokenOnRequest(AuthorizationFilterContext context)
    {
        var authentication = context.HttpContext.Request.Headers.Authorization.ToString();
        if (string.IsNullOrWhiteSpace(authentication))
        {
            throw new UnauthorizedException(ResourceMessagesException.NO_TOKEN);
        }

        return authentication["Bearer ".Length..].Trim();
    }
}