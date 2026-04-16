using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asesor.Dominio.Entidades;

namespace Asesor.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {

        public Task Actualizar(Cliente entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Agregar(Cliente entidad)
        {
            throw new NotImplementedException();
        }

        public Task Borrar(Cliente entidad)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
