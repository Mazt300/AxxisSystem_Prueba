using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AxxisSystem.Model.Modelo;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AxxisSystem.Model
{
    public class AxxisSystemDbContext : DbContext
    {
        public AxxisSystemDbContext() : base("conexion")
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Direccion_Contacto> Direccion_Contactos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
