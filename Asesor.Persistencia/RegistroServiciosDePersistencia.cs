using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Asesor.Aplicacion.Contratos.Repositorios;
using Asesor.Persistencia.Repositorio;
using Asesor.Aplicacion.Contratos.Persistencia;

namespace Asesor.Persistencia
{
    public static class RegistroServiciosDePersistencia
    {
        public static IServiceCollection AgregarServiciosDePersistencia(this IServiceCollection servicios)
        {
            // Registro de contexto
            servicios.AddDbContext<AsesorDBContext>(options =>
                options.UseSqlServer("name=ConexionAsesorDB")
            );
            // Registro de repositorios
            servicios.AddScoped(typeof(IRepositorioCliente), typeof(RepositorioCliente));
            servicios.AddScoped(typeof(IUnidadTrabajo), typeof(UnidadTrabajoEFCore));
            return servicios;
        }
    }
}
