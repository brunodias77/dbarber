using System.Net;
using DB.Application.Communications.Resposes.Errors;
using DB.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DB.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ExceptionBase exceptionBase)
        {
            HandlerProjectExceptions(exceptionBase, context);
        }
        else
        {
            ThrowUnknowException(context);
        }
    }

    private void HandlerProjectExceptions(ExceptionBase exceptionBase, ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)exceptionBase.GetStatusCode();
        context.Result = new ObjectResult(new ResponseErrorJson(exceptionBase.GetErrorMessages()));
    }
    
    private void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson("Erro desconhecido !"));
    }

}