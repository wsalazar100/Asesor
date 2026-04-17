using Asesor.Aplicacion.Contratos.Persistencia;
using Asesor.Aplicacion.Contratos.Repositorios;
using Asesor.Aplicacion.Excepciones;
using Asesor.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.ActualizarCliente
{
    public class CasoActualizarCliente : IRequestHandler<ComandoActualizarCliente>
    {
        private readonly IRepositorioCliente repositorio;
        private readonly IUnidadTrabajo unidadTrabajo;

        public CasoActualizarCliente(IRepositorioCliente repositorio, IUnidadTrabajo unidadTrabajo )
        {
            this.repositorio = repositorio;
            this.unidadTrabajo = unidadTrabajo;
        }



        public async Task Handle(ComandoActualizarCliente request)
        {
            var cliente = await repositorio.ObtenerPorId(request.Id);
            if (cliente is null)
            {
                throw new ExcepcionNoEncontrado();
            }

            cliente.Actualizar(request.Nombre, request.Identificacion, request.Correo, request.Telefono, request.Direccion);
            try
            {
                await repositorio.Actualizar(cliente);
                await unidadTrabajo.Persistir();
            }
            catch (Exception )
            {
                await unidadTrabajo.Reversar();
                throw;
            }
        }
    }
}
