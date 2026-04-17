using Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.CrearCliente;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.CasosUso.GestionCliente.Comandos.ActualizarCliente
{
    public class ValidadorComandoActualizarCliente: AbstractValidator<ComandoActualizarCliente>
    {

        public ValidadorComandoActualizarCliente()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").WithMessage("El nombre no debe contener números ni caracteres especiales");

            RuleFor(p => p.Identificacion)
                .NotEmpty().WithMessage("La identificación es requerida")
                .Must(identificacion => identificacion.Valor.Length == 10 && identificacion.Valor.All(char.IsDigit))
                .WithMessage("La identificación debe contener exactamente 10 dígitos numéricos");

            RuleFor(p => p.Correo)
               .NotEmpty().WithMessage("El correo electrónico es requerido")
               .Must(correo => correo.Valor.Contains("@"))
               .WithMessage("El correo electrónico debe contener el símbolo '@'");

            RuleFor(p => p.Telefono)
                .NotEmpty().WithMessage("El teléfono es requerido");

            RuleFor(p => p.Direccion)
                .NotEmpty().WithMessage("La dirección es requerida");

        }


    }
}
