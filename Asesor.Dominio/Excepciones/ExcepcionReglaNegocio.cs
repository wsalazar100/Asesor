using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Dominio.Excepciones
{
    public class ExcepcionReglaNegocio: Exception
    {

        public ExcepcionReglaNegocio(string mensaje) : base(mensaje)
        {

        }

        /// <summary>
        /// Valida que <paramref name="fechaInicio"/> sea menor o igual que <paramref name="fechaExpiracion"/>.
        /// Lanza <see cref="ExcepcionReglaNegocio"/> si la validación falla.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio.</param>
        /// <param name="fechaExpiracion">Fecha de expiración.</param>
        public static void ValidarFechaInicioMenorIgualFechaExpiracion(DateTime fechaInicio, DateTime fechaExpiracion)
        {
            
            if (fechaInicio > fechaExpiracion)
            {
                throw new ExcepcionReglaNegocio("FechaInicio debe ser menor o igual a FechaExpiracion.");
            }
        }
    }
}
