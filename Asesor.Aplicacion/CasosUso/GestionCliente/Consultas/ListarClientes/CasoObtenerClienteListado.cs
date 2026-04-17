using Asesor.Aplicacion.Contratos.Repositorios;
using Asesor.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ListarClientes
{
    public class CasoObtenerClienteListado : IRequestHandler<ConsultaObtenerClienteListado, List<ClienteListadoDTO>>
    {
        private readonly IRepositorioCliente repositorio;

        public CasoObtenerClienteListado(IRepositorioCliente repositorio)
        {
            this.repositorio = repositorio;
        }
        public async Task<List<ClienteListadoDTO>> Handle(ConsultaObtenerClienteListado request)
        {
            var clientes = await repositorio.ObtenerTodos();

            var clientesDTO = clientes.Select(c => new ClienteListadoDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Identificacion = c.Identificacion.ToString(),
                Correo = c.Correo.ToString(),
                Telefono = c.Telefono,
                Direccion = c.Direccion
            }).ToList();
            return clientesDTO;
        }


    }
}
