using Microsoft.AspNetCore.Http;
using PersonalProjectClassLibrary.ActionResults;
using PersonalProjectClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.Middlewares
{
    public class ExceptionHandlerMid
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMid(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BadHttpRequestException bex)
            {
                await HandleException(context, bex);
            }
            catch (Exception ex)
            {

                await HandleException(context,ex);
            }
        }

        private  static Task HandleException(HttpContext context, Exception ex)
        {
            int statusCode = 500;
            string message = ex.Message;
            if(ex is BadHttpRequestException badEx)
            {
                message = badEx.Message;
                statusCode = badEx.StatusCode;
            }
            return context.Response.WriteAsJsonAsync(new ErrorModel
            {
                Message = message,
                StatusCode = statusCode
            });
        }
    }
}
