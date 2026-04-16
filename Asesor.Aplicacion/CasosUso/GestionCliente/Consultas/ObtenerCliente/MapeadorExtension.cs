using Asesor.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ObtenerCliente
{
    public static class MapeadorExtension
    {
        public static ClienteDTO ClienteDTO(Cliente cliente)
        {
            if (cliente == null) return null;
            return new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Identificacion = cliente.Identificacion.ToString(),
                Correo = cliente.Correo.ToString(),
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion
            };

        }
    }
}
