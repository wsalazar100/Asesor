using Asesor.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.BorrarCliente
{
    public class ComandoBorrarCliente: IRequest
    {
            public required Guid Id { get; set; }

    }
}
