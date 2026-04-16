using Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ObtenerCliente;
using Asesor.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ObtenerDetalleCliente
{
    public class ConsultaObtenerCliente: IRequest<ClienteDTO>
    {
        public Guid Id { get; set; }


    }
}
