using Asesor.Aplicacion.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asesor.Dominio.Entidades;
using Asesor.Aplicacion.Contratos.Persistencia;
using FluentValidation;
using Asesor.Aplicacion.Excepciones;
namespace Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.CrearCliente
{
    public class CasoCrearCliente( IRepositorioCliente repositorio,  IUnidadTrabajo unidadTrabajo, IValidator<ComandoCrearCliente> validador)
    {
        // Coordina la logica de negocio para crear un cliente, se encarga de validar los datos y
        // llamar al repositorio para guardar el cliente en la base de datos.
        private readonly IRepositorioCliente repositorio = repositorio;
        private readonly IUnidadTrabajo unidadTrabajo = unidadTrabajo;
        public IValidator<ComandoCrearCliente> validador { get; } = validador;

        public async Task<Guid> Handle(ComandoCrearCliente comando)
        {
            var rptaValidacion = await validador.ValidateAsync(comando);
            if ( !rptaValidacion.IsValid) 
            {
                // todos los errores de validacion se devuelvel al cliente
                throw new ExcepcionValidacion(rptaValidacion);
            }
            var cliente = new Cliente(comando.Nombre, comando.Identificacion, comando.Correo, comando.Telefono, comando.Direccion);
            try
            {
                var nuevoCliente = await repositorio.Agregar(cliente);
                await unidadTrabajo.Persistir();
                return nuevoCliente.Id;
            }
            catch (Exception e)
            {
                await unidadTrabajo.Reversar();
                throw;
            }
        }
    }
}
