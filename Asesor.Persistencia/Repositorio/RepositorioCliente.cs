using Asesor.Aplicacion.Contratos.Repositorios;
using Asesor.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Persistencia.Repositorio
{
    public class RepositorioCliente : Repositorio<Cliente>, IRepositorio<Cliente>
    {
        public RepositorioCliente(AsesorDBContext contexto) : base(contexto)
        {
        }
    }
}
