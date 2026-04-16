using Asesor.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Dominio.ObjetosValor
{
    public record PeriodoVigencia
    {

        public DateTime FechaInicio { get; }    
        public DateTime FechaExpiracion { get; }

        public PeriodoVigencia(DateTime fechaInicio, DateTime fechaExpiracion)
        {
            if (fechaInicio > fechaExpiracion)
            {
                throw new ExcepcionReglaNegocio("FechaInicio debe ser menor o igual a FechaExpiracion.");
            }
            FechaInicio = fechaInicio;
            FechaExpiracion = fechaExpiracion;
        }
    }
}
