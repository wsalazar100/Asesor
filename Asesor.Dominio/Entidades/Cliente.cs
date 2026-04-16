using Asesor.Dominio.Excepciones;
using Asesor.Dominio.ObjetosValor;
using System;
using System.Net.Mail;

namespace Asesor.Dominio.Entidades
{
    public class Cliente
    {
        public Guid Id { get; private set; }

        public string Nombre { get; private set; }  = null!;
        public Identificacion Identificacion { get; private set; } = null!;
        public CorreoElectronico Correo { get; private set; } = null!;

        public string Telefono { get; private set; } = null!;
        public string Direccion { get; private set; } = null!;

        private Cliente() { }
        public Cliente(string nombre, Identificacion identificacion, CorreoElectronico correo, string telefono, string direccion)
        {
            ValidarParametro(nombre, nameof(nombre));
            ValidarParametro(telefono, nameof(telefono));
            ValidarParametro(direccion, nameof(direccion));



            Id = Guid.NewGuid();
            Nombre = nombre.Trim();
            Identificacion = identificacion;
            Correo = correo;
            Telefono = telefono.Trim();
            Direccion = direccion.Trim();
        }

        private static void ValidarParametro(string pValor, string pNombre)
        {
            if (string.IsNullOrWhiteSpace(pValor))
            {
                throw new ExcepcionReglaNegocio($"El {pNombre} es obligatorio.");
            }
        }

    }
}
