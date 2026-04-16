using Asesor.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Dominio.ObjetosValor
{
    public record CorreoElectronico
    {
        public string Valor { get; } = null!; // es inmutable solo se puede obtener

        private CorreoElectronico() { }
        public CorreoElectronico(string pCorreoElectronico)
        {
            if (string.IsNullOrEmpty(pCorreoElectronico))
            {
                throw new ExcepcionReglaNegocio($"El {nameof(pCorreoElectronico)} es obligatorio");
            }

            if (!pCorreoElectronico.Contains("@"))
            {
                throw new ExcepcionReglaNegocio($"El {nameof(pCorreoElectronico)} debe contener el símbolo '@'.");
            }



        }
    }
}
