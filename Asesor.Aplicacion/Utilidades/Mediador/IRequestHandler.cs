using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Aplicacion.Utilidades.Mediador
{
    public  interface IRequestHandler<TRequest,TResponse> where TRequest : IRequest<TResponse>
   { 
        Task<TResponse> Handle(TRequest request);
    }

    // no retorna nada
    public interface IRequestHandler<TRequest> where TRequest : IRequest
    {
        Task Handle(TRequest request);
    }



}
