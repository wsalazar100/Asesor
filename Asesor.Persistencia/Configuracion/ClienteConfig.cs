using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Asesor.Dominio.Entidades;

namespace Asesor.Persistencia.Configuracion
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
           builder.Property(prop => prop.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            builder.OwnsOne(c => c.Identificacion, id =>
            {
                id.Property(i => i.Valor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Identificacion");
            });
            builder.OwnsOne(c => c.Correo, correo =>
            {
                correo.Property(c => c.Valor)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Correo");
            });
            builder.Property(prop => prop.Telefono)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(prop => prop.Direccion)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
