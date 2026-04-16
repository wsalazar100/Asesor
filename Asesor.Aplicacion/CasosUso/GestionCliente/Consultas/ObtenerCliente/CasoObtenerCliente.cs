using Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ObtenerDetalleCliente;
using Asesor.Aplicacion.Contratos.Repositorios;
using Asesor.Aplicacion.Excepciones;
using Asesor.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ObtenerCliente
{
    public class CasoObtenerCliente : IRequestHandler<ConsultaObtenerCliente, ClienteDTO>
    {
        private readonly IRepositorioCliente repositorio;
        public CasoObtenerCliente(IRepositorioCliente repositorio)
        {
            this.repositorio = repositorio;
        }
        public async Task<ClienteDTO> Handle(ConsultaObtenerCliente request)
        {
            var cliente = await repositorio.ObtenerPorId(request.Id);
            if (cliente is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            return MapeadorExtension.ClienteDTO(cliente);

        }
    }
}
