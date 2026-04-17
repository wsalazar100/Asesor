using Asesor.Aplicacion.Contratos.Persistencia;
using Asesor.Aplicacion.Contratos.Repositorios;
using Asesor.Aplicacion.Excepciones;
using Asesor.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.BorrarCliente
{
    public class CasoBorrarCliente : IRequestHandler<ComandoBorrarCliente>
    {
        private readonly IRepositorioCliente repositorio;
        private readonly IUnidadTrabajo unidad;

        public CasoBorrarCliente(IRepositorioCliente repositorio, IUnidadTrabajo unidad)
        {
            this.repositorio = repositorio;
            this.unidad = unidad;
        }
        public async Task Handle(ComandoBorrarCliente request)
        {
            var cliente = await repositorio.ObtenerPorId(request.Id);
            if (cliente is null)
            {
                throw new ExcepcionNoEncontrado();
            }
            try
            {
                await repositorio.Borrar(cliente);
                await unidad.Persistir();
            }
            catch (Exception)
            {
                await unidad.Reversar();
                throw;
            }
        }



    }
}
