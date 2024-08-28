using DB.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DB.Api.Attributes
{
    public class AuthenticatedUserAttribute : TypeFilterAttribute
    {
        public AuthenticatedUserAttribute() : base(typeof(AuthenticatedUserFilter))
        {
        }
    }
}