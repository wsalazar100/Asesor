using Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.CrearCliente;
using Asesor.Aplicacion.Contratos.Persistencia;
using Asesor.Aplicacion.Contratos.Repositorios;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Asesor.Dominio;
using Asesor.Dominio.ObjetosValor;
using Asesor.Dominio.Entidades;
using FluentValidation.Results;

namespace Asesor.pruebas.Aplicacion.CasoUso.Cliente
{
    [TestClass]
    public class CasoCrearClientePrueba
    {
        private  IRepositorioCliente repositorio;
        private  IUnidadTrabajo unidadTrabajo;
        private  IValidator<ComandoCrearCliente> validator;
        private CasoCrearCliente caso;

        [TestInitialize]
        public void Setup()
        {
            // Aquí puedes configurar tus objetos de prueba, como repositorios simulados o una base de datos en memoria.

            repositorio = Substitute.For<IRepositorioCliente>();
            unidadTrabajo = Substitute.For<IUnidadTrabajo>();
            validator = Substitute.For<IValidator<ComandoCrearCliente>>();
            caso = new CasoCrearCliente(repositorio, unidadTrabajo, validator);
        }

        [TestMethod]
        public async Task Handle_ComandoValido_ObtenerIdCliente() { 
            var comando = new ComandoCrearCliente
            {
                Nombre = "Juan Perez",
                Identificacion = new Identificacion("0123456789"),// valida
                Correo = new CorreoElectronico("soswilo@gmail.com"), // valida
                Telefono = "555-1234",
                Direccion = "Calle Falsa 123"
            };

            // Devuelve la validación como  exitosa
            validator.ValidateAsync(comando).Returns(new ValidationResult());

            // Simula el comportamiento del repositorio para agregar un cliente
            var nuevoCliente = new Asesor.Dominio.Entidades.Cliente(comando.Nombre, comando.Identificacion, comando.Correo, comando.Telefono, comando.Direccion);
            repositorio.Agregar(Arg.Any<Asesor.Dominio.Entidades.Cliente>()).Returns(nuevoCliente);

            // probar el caso de uso
            var resultado = await caso.Handle(comando); 

            // verificacion
            await validator.Received(1).ValidateAsync(comando); 
            await repositorio.Received(1).Agregar(Arg.Any<Asesor.Dominio.Entidades.Cliente>());
            await unidadTrabajo.Received(1).Persistir();
            Assert.AreNotEqual(Guid.Empty, resultado); // valida que no sea vacio
        }


    }
}
