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
    public class CorreoElectronicoPrueba
    {
        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void Constructor_CorreoNulo_LanzaExcepcion()
        {
            // Arrange
            new CorreoElectronico(null!);

        }



        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void Constructor_CorreoSinArroba_LanzaExcepcion()
        {
            // Arrange
            new CorreoElectronico("william.com");
        }


    }
}
