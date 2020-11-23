using GalinhaCaipira.Domain.Entities;
using GalinhaCaipira.Repositories.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalinhaCaipira.Repositories.Context
{
    public class BDGalinhaCaipiraContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Granja> Granjas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(w => w.Name == w.ReflectedType.Name + "Id").Configure(c => c.IsKey());
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new GranjaConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity.GetType().GetProperty("DataInclusao") != null)
                        entry.Property("DataInclusao").CurrentValue = DateTime.Now;

                    if (entry.Entity.GetType().GetProperty("DataAtualizacao") != null)
                        entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity.GetType().GetProperty("DataInclusao") != null)
                        entry.Property("DataInclusao").IsModified = false;

                    if (entry.Entity.GetType().GetProperty("DataAtualizacao") != null)
                        entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
