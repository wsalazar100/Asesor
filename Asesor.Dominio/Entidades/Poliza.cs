using Asesor.Dominio.Enumerados;
using Asesor.Dominio.Excepciones;
using Asesor.Dominio.ObjetosValor;
using System;

namespace Asesor.Dominio.Entidades
{
    public class Poliza
    {
        public Guid Id { get; private set; }
        public Guid ClienteId { get; private set; }

        public String NumeroPoliza { get; private set; }
        public TipoPolizaEnum Tipo { get; private set; }
        
        public PeriodoVigencia PeriodoVigencia { get; private set; }
        public MontoPositivo MontoAsegurado { get; private set; }
        public EstadoPolizaEnum Estado { get; private set; }

  
        // Constructor público con validaciones
        public Poliza(Guid clienteId, TipoPolizaEnum tipo,PeriodoVigencia periodoVigencia, MontoPositivo montoAsegurado)
        {
 
            // Validar que la poliza pertenece a un cliente
            ValidarClienteIdNoNulo(clienteId);




        Id = Guid.NewGuid();
            ClienteId = clienteId;
            NumeroPoliza = Guid.NewGuid().ToString().Substring(0, 10).ToUpper(); // Genera un número de póliza único
            Tipo = tipo;
            PeriodoVigencia = periodoVigencia;
            MontoAsegurado = montoAsegurado;
            Estado = EstadoPolizaEnum.Activa;
        }


        // Valida que `clienteId` no sea `Guid.Empty`.
        // Lanza ExcepcionReglaNegocio si la condición no se cumple.
        private static void ValidarClienteIdNoNulo(Guid clienteId)
        {
            if (clienteId == Guid.Empty)
            {
                throw new ExcepcionReglaNegocio("La poliza debe pertenecer a un cliente");
            }
        }

        public void CancelarPoliza()
        {
            if (Estado != EstadoPolizaEnum.Activa)
            {
                throw new ExcepcionReglaNegocio("Solo se puede cancelar polizas activas");
            }
            Estado = EstadoPolizaEnum.Cancelada;
        }


    }
}
