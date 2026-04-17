using Asesor.Aplicacion.Excepciones;
using System.Net;
using System.Text.Json;

namespace Asesor.API.Midlewares
{
 
    public class ManejadorExcepcionesMiddleware
    {
        private readonly RequestDelegate _next;
        public ManejadorExcepcionesMiddleware(RequestDelegate next)
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
                await ManejarExcepcion(context, ex);
            }
        }

        private Task ManejarExcepcion(HttpContext context, Exception exception) 
        { 
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var resultado = string.Empty;
            switch (exception)
            {
                case ExcepcionNoEncontrado ex:   
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case ExcepcionValidacion ex:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    resultado = JsonSerializer.Serialize( ex.ErroresValidacion);
                    break;
                default:
                    resultado = new { mensaje = "Ocurrió un error en el servidor." }.ToString();
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;  
            return context.Response.WriteAsync(resultado);  
        }

    }

    public static class ManejadorExcepcionesMiddlewareExtensions
    {
        public static IApplicationBuilder UseManejadorExcepciones(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ManejadorExcepcionesMiddleware>();
        }
    }


}
