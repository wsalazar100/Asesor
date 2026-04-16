
using Asesor.Aplicacion.Contratos.Repositorios;
using Microsoft.EntityFrameworkCore;
namespace Asesor.Persistencia.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly AsesorDBContext _contexto;
        public Repositorio(AsesorDBContext contexto)
        {
            _contexto = contexto;
        }
        public Task Actualizar(T entidad)
        {
            _contexto.Update(entidad);
            return Task.CompletedTask;

        }

        public Task<T> Agregar(T entidad)
        {

            _contexto.Add(entidad);
            return Task.FromResult(entidad);

        }

        public Task Borrar(T entidad)
        {
            _contexto.Remove(entidad);
            return Task.CompletedTask;
        }

        public async Task<T?> ObtenerPorId(Guid id)
        {
            return await _contexto.Set<T>().FindAsync(id);

        }

        public async Task<IEnumerable<T>> ObtenerTodos()
        {
            return await _contexto.Set<T>().ToListAsync();
        }
    }
}
