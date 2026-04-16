using Asesor.Aplicacion.Utilidades.Mediador;
using Asesor.Dominio.ObjetosValor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.CrearCliente
{
    public  class ComandoCrearCliente : IRequest<Guid>
    {
        public required string Nombre { get; set; } = null!;
        public required Identificacion Identificacion { get; set; } = null!;
        public required CorreoElectronico Correo { get; set; } = null!;    
        public required string Telefono { get; set; } = null!;
        public required string Direccion { get; set; } = null!;
       


        public async Task<Guid> Handle(ComandoCrearCliente comando)
        {
            // Contiene los datos para ejecutar la accion.
            Guid nuevoClienteId = Guid.NewGuid();
            return nuevoClienteId;
        }

    }
}
