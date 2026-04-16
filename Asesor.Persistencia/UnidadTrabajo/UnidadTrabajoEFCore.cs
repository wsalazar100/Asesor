using Asesor.Aplicacion.Contratos.Persistencia;
using Asesor.Persistencia;

namespace Asesor.Persistencia
{
    public class UnidadTrabajoEFCore : IUnidadTrabajo
    {
        private readonly AsesorDBContext _contexto;
        public UnidadTrabajoEFCore(AsesorDBContext contexto)
        {
            _contexto = contexto;
        }
        public async Task Persistir()
        {
          await _contexto.SaveChangesAsync();

        }

        public async Task Reversar()
        {
           await Task.CompletedTask;
        }
    }
}
