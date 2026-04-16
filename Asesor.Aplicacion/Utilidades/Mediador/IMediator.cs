using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.Utilidades.Mediador
{
    public  interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }


}
