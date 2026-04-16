using Asesor.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Dominio.ObjetosValor
{
    public record Identificacion
    {
        public string Valor { get; } = null!; // es inmutable solo se puede obtener

        public Identificacion(string pIdentificacion)
        {
            if (string.IsNullOrWhiteSpace(pIdentificacion))
            {
                throw new ExcepcionReglaNegocio($"El {nameof(pIdentificacion)} es obligatorio");
            }

            var valor = pIdentificacion.Trim();

            if (valor.Length != 10)
            {
                throw new ExcepcionReglaNegocio($"El {nameof(pIdentificacion)} debe contener exactamente 10 caracteres");
            }

            if (!valor.All(char.IsDigit))
            {
                throw new ExcepcionReglaNegocio($"El {nameof(pIdentificacion)} debe contener solo dígitos numéricos");
            }

            Valor = valor;
        }
    }
}
