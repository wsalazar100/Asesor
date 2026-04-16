using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.Contratos.Persistencia
{
    public interface IUnidadTrabajo
    {
      Task Persistir();
      Task Reversar();
    }
}
