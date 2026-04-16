using Asesor.Dominio.Excepciones;
using Asesor.Dominio.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.pruebas.Dominio.ObjetosValor
{

    [TestClass]
    public class PeriodoVigenciaPrueba
    {

        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void Constructor_FechaInicio_MayorQue_FechaExpiracion_LanzaExcepcion()
        {
            // Arrange
            DateTime fechaInicio = new DateTime(2024, 1, 1);
            DateTime fechaExpiracion = new DateTime(2023, 12, 31);
            // Act
            new PeriodoVigencia(fechaInicio, fechaExpiracion);
        }

    }
}
