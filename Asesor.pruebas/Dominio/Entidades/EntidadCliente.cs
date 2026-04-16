using Asesor.Dominio.Entidades;
using Asesor.Dominio.Excepciones;
using Asesor.Dominio.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.pruebas.Dominio.Entidades
{
    [TestClass]
    public class EntidadCliente
    {

        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]  
        public void CrearCliente_ConNombreVacio_LanzaExcepcion()
        {
            // Arrange
            string nombre = "";
            var correo = new CorreoElectronico("soswilo@gmail.com");
            var identificacion = new Identificacion("123456789");
            string telefono = "555-1234";
            string direccion = "Calle Falsa 123";
            new Cliente(nombre, identificacion, correo,telefono,direccion);
        }



        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void CrearCliente_ConCorreoNulo_LanzaExcepcion()
        {
            // Arrange
            string nombre = "";
            var identificacion = new Identificacion("123456789");
            var correo = new CorreoElectronico("");
            string telefono = "555-1234";
            string direccion = "Calle Falsa 123";
            new Cliente(nombre, identificacion, correo, telefono, direccion);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaNegocio))]
        public void CrearCliente_ConIdentificacion_Mayor10Caracteres_LanzaExcepcion()
        {
            // Arrange
            string nombre = "";
            var identificacion = new Identificacion("12345678901");
            var correo = new CorreoElectronico("");
            string telefono = "555-1234";
            string direccion = "Calle Falsa 123";
            new Cliente(nombre, identificacion, correo, telefono, direccion);
        }






    }
}
