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
using Asesor.Aplicacion.Utilidades.Mediador;
namespace Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.CrearCliente
{
    public class CasoCrearCliente : IRequestHandler<ComandoCrearCliente, Guid>
    {
        private readonly IRepositorioCliente _repositorio;
        private readonly IUnidadTrabajo _unidadTrabajo;
        

        public CasoCrearCliente(IRepositorioCliente repositorio, IUnidadTrabajo unidadTrabajo)
        {
            this._repositorio = repositorio;
            this._unidadTrabajo = unidadTrabajo;
        }

        public async Task<Guid> Handle(ComandoCrearCliente comando)
        {
          
            var cliente = new Cliente(comando.Nombre, comando.Identificacion, comando.Correo, comando.Telefono, comando.Direccion);
            try
            {
                var nuevoCliente = await _repositorio.Agregar(cliente);
                await _unidadTrabajo.Persistir();
                return nuevoCliente.Id;
            }
            catch (Exception e)
            {
                await _unidadTrabajo.Reversar();
                throw;
            }
        }
    }
}
