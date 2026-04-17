using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asesor.Aplicacion.Excepciones;
using FluentValidation;
using FluentValidation.Results;


namespace Asesor.Aplicacion.Utilidades.Mediador
{
    public class MediadorSimple : IMediator
    {
        private readonly IServiceProvider _serviceProvider;
        public MediadorSimple(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {

            await RealizarValidacion(request);

            var tipoCasoUso = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var casoUso = _serviceProvider.GetService(tipoCasoUso);
            if (casoUso == null)
            {
                throw new ExcepcionMediador($"No se encontró un caso de uso para el tipo de solicitud {request.GetType().Name}");
            }

            // Referencia al metodo Handle del caso de uso, que es el encargado de ejecutar la logica de negocio para procesar la solicitud.
            var metodo = tipoCasoUso.GetMethod("Handle");
            return await (Task<TResponse>)metodo.Invoke(casoUso, new object[] { request })!;

        }

        // No retorna nada porque es para solicitudes que no esperan una respuesta, como comandos que solo ejecutan una acción sin devolver datos.
        public async Task Send<TResponse>(IRequest request)
        {
            await RealizarValidacion(request);

            var tipoCasoUso = typeof(IRequestHandler<>).MakeGenericType(request.GetType());
            var casoUso = _serviceProvider.GetService(tipoCasoUso);
            if (casoUso is null)
            {
                throw new ExcepcionMediador($"No se encontró un caso de uso para el tipo de solicitud {request.GetType().Name}");

            }
            var metodo = tipoCasoUso.GetMethod("Handle");
            await (Task)metodo.Invoke(casoUso, new object[] { request })!;

        }

        private async Task RealizarValidacion(object request) 
        {

            var tipoValidador = typeof(IValidator<>).MakeGenericType(request.GetType());
            var validador = _serviceProvider.GetService(tipoValidador) as IValidator;
            if (validador != null)
            {
                var metodoValidar = tipoValidador.GetMethod("ValidateAsync", new Type[] { request.GetType(), typeof(CancellationToken) });
                var tareaValidar = (Task)metodoValidar.Invoke(validador, new object[] { request, CancellationToken.None });
                await tareaValidar.ConfigureAwait(false);

                var resultado = tareaValidar.GetType().GetProperty("Result");
                var resultadoValidacion = (ValidationResult)resultado!.GetValue(tareaValidar);

                if (!resultadoValidacion.IsValid)
                {
                    throw new ExcepcionValidacion(resultadoValidacion);
                }

            }



        }
    }
}
