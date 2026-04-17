using Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ObtenerCliente;
using Asesor.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ListarClientes
{
    public static class MapeadorExtension
    {

        public static ClienteListadoDTO ClienteListadoDTO(Cliente cliente)
        {

            var dto = new ClienteListadoDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Identificacion = cliente.Identificacion.ToString(),
                Correo = cliente.Correo.ToString(),
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion
            };

            return dto;

        }
    }
}
