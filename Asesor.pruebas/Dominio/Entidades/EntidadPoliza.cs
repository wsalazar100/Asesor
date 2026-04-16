using Asesor.Dominio.Entidades;
using Asesor.Dominio.Enumerados;
using Asesor.Dominio.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.pruebas.Dominio.Entidades
{

    [TestClass]
    public class EntidadPoliza
    {
        private Guid _clienteId = Guid.NewGuid();
        private PeriodoVigencia _periodoVigencia = new PeriodoVigencia(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31));
        private MontoPositivo _montoAsegurado = new MontoPositivo(1000);

        [TestMethod]
        public void CrearPoliza_Valida_EstadoActiva()
        {
            // Arrange
            string numeroPoliza = Guid.NewGuid().ToString().Substring(0, 10).ToUpper();
            var nuevaPoliza = new Poliza( _clienteId, TipoPolizaEnum.Hogar, _periodoVigencia, _montoAsegurado);
            Assert.AreEqual(EstadoPolizaEnum.Activa, nuevaPoliza.Estado);
            Assert.AreEqual(_clienteId, nuevaPoliza.ClienteId);
            Assert.AreEqual(_periodoVigencia, nuevaPoliza.PeriodoVigencia);
            Assert.AreEqual(_montoAsegurado, nuevaPoliza.MontoAsegurado);
            Assert.AreNotEqual(Guid.Empty, nuevaPoliza.Id);


        }

    }
}
