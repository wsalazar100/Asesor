using Asesor.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Dominio.ObjetosValor
{
    public record MontoPositivo
    {
        public decimal Valor { get; } // es inmutable
        public MontoPositivo(decimal pMonto)
        {
            
            if (pMonto <= 0m)
            {
                throw new ExcepcionReglaNegocio($"El {nameof(pMonto)} debe ser un valor positivo");
            }
            Valor = pMonto;
        }


    }
}
