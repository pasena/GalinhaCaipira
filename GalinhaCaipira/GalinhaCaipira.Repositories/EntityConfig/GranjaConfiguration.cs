using GalinhaCaipira.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalinhaCaipira.Repositories.EntityConfig
{
    public class GranjaConfiguration : EntityTypeConfiguration<Granja>
    {
        public GranjaConfiguration()
        {
            HasKey(h => h.GranjaId);

            Property(p => p.NomeFantasia.Nome).HasColumnName("NomeFantasia").HasMaxLength(300).IsRequired();
        }
    }
}
