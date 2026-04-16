using Asesor.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asesor.Persistencia
{
    public class AsesorDBContext : DbContext
    {
        public AsesorDBContext(DbContextOptions<AsesorDBContext> options) : base(options)
        {

        }

        protected AsesorDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AsesorDBContext).Assembly);

        }
        public DbSet<Cliente> Clientes { get; set; }





    }
}
