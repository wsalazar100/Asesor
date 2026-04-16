using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Asesor.Aplicacion.Excepciones
{
    public class ExcepcionValidacion: Exception
    {
        public List<string> ErroresValidacion { get; } = [];
        public ExcepcionValidacion(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                ErroresValidacion.Add(error.ErrorMessage);
            }

        }
    }
}
