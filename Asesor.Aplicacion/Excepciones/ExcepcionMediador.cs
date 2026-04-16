using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.Excepciones
{
    public class ExcepcionMediador : Exception
    {

        public ExcepcionMediador( string mensaje) : base(mensaje)
        {
            

        }
    }
}
