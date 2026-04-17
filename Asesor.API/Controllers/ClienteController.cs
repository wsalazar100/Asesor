using Asesor.API.DTOs.Cliente;
using Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.CrearCliente;
using Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ListarClientes;
using Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ObtenerCliente;
using Asesor.Aplicacion.CasosUso.GestionCliente.Consultas.ObtenerDetalleCliente;
using Asesor.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;


using Asesor.Aplicacion.CasosUso.GestionCliente;
using Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.ActualizarCliente;
using Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.BorrarCliente;

namespace Asesor.API.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator mediator;
        public ClienteController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerClientePorId(Guid id)
        {
            // ojo el manejo de errores esta en el Middleware
            var consulta = new ConsultaObtenerCliente { Id = id };
            var resultado = await mediator.Send(consulta);
            return Ok(resultado);


        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente( ClientesDTO  pClienteDTO)
        {
            // ojo el manejo de errores esta en el Middleware
            var comando = new ComandoCrearCliente
            {
                Nombre = pClienteDTO.Nombre,
                Identificacion = new Asesor.Dominio.ObjetosValor.Identificacion(pClienteDTO.Identificacion),
                Correo = new Asesor.Dominio.ObjetosValor.CorreoElectronico(pClienteDTO.Correo),
                Telefono = pClienteDTO.Telefono,
                Direccion = pClienteDTO.Direccion
            };
            await mediator.Send(comando);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(Guid id, ActualizaClienteDTO pActualizaClienteDTO)
        {
            // ojo el manejo de errores esta en el Middleware
            var comando = new ComandoActualizarCliente
            {
                Id = id,
                Nombre = pActualizaClienteDTO.Nombre,
                Identificacion = new Asesor.Dominio.ObjetosValor.Identificacion(pActualizaClienteDTO.Identificacion),
                Correo = new Asesor.Dominio.ObjetosValor.CorreoElectronico(pActualizaClienteDTO.Correo),
                Telefono = pActualizaClienteDTO.Telefono,
                Direccion = pActualizaClienteDTO.Direccion
            };
            await mediator.Send<object>(comando);
            return NoContent();
        }




        [HttpGet]
        public async Task<ActionResult<List<ClienteListadoDTO>>> ObtenerClientes()
        {
            var consulta = new ConsultaObtenerClienteListado();
            var resultado = await mediator.Send(consulta);
            return Ok(resultado);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarCliente(Guid id)
        {
            // ojo el manejo de errores esta en el Middleware
            var comando = new ComandoBorrarCliente { Id = id };
            await mediator.Send<object>(comando);
            return NoContent();


        }
    }
}
