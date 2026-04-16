using Asesor.Aplicacion.Utilidades.Mediador;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




using Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.CrearCliente;
using Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ObtenerDetalleCliente;
using Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ObtenerCliente;
namespace Asesor.Aplicacion
{
    public static class RegistraServiciosDeAplicacion
    {
     public static IServiceCollection AgregarServiciosDeAplicacion(this IServiceCollection servicios)
        {
            // Registro Mediador
            servicios.AddTransient<IMediator, MediadorSimple >();
            servicios.AddScoped<IRequestHandler<ComandoCrearCliente, Guid>, CasoCrearCliente>();
            servicios.AddScoped<IRequestHandler<ConsultaObtenerCliente, ClienteDTO>, CasoObtenerCliente>();
            // 
            return servicios;


        }

    }
}
