using Clinovi.Application.Exceptions;
using Clinovi.Domain.Exceptions;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JsonSerializerOptions _jsonOptions;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;

        _jsonOptions = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (AppException ex)
        {
            await HandleError(context, ex.StatusCode, ex.Message);
        }
        catch (DomainException ex)
        {
            await HandleError(context, (int)HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception)
        {
            await HandleError(context, 500, "Erro interno");
        }
    }

    private async Task HandleError(HttpContext context, int statusCode, string message)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        var response = new { erro = message };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response, _jsonOptions));
    }
}