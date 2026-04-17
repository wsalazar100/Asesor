using System.ComponentModel.DataAnnotations;

namespace Asesor.API.DTOs.Cliente
{
    public class ActualizaClienteDTO
    {
        [Required]
        public required string Nombre { get; set; } = null!;

        [Required]
        public required string Identificacion { get; set; } = null!;

        [Required]
        public required string Correo { get; set; } = null!;

        [Required]
        public required string Telefono { get; set; } = null!;

        [Required]
        public required string Direccion { get; set; } = null!;
    }
}
