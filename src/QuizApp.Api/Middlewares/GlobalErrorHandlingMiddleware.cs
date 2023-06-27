using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using QuizApp.Core.Exceptions;
using QuizApp.Models.Common;
using System.Net;
using System.Text.Json;

namespace QuizApp.Api.Middlewares
{
    internal class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ApiResponse response = null;
                switch (ex)
                {
                    case NotfoundException:
                        response = ApiResponse.Fail(ex.Message, HttpStatusCode.NotFound);
                        break;
                    case BadRequestException:
                        response = ApiResponse.Fail(ex.Message, HttpStatusCode.BadRequest);
                        break;
                    case UnHandlendException:
                    default:
                        response = ApiResponse.Fail("Xəta baş verdi! Yenidən yoxlayın!", HttpStatusCode.BadRequest);
                        break;
                }
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)response.StatusCode;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy(),
                    },
                    NullValueHandling = NullValueHandling.Ignore
                }));
            }
        }
    }

    internal static class GlobalErrorHandlingMiddlewareExtension
    {
        internal static IApplicationBuilder AddGlobalErrorHandling(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalErrorHandlingMiddleware>();

            return builder;
        }
    }
}
