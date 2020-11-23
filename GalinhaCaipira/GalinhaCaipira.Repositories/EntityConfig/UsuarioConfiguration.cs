using GalinhaCaipira.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GalinhaCaipira.Repositories.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(h => h.UsuarioId);

            Property(p => p.Nome.PrimeiroNome).HasColumnName("Nome").IsRequired().HasColumnType("varchar").HasMaxLength(150);
            Property(p => p.Nome.Sobrenome).HasColumnName("Sobrenome").IsRequired().HasColumnType("varchar").HasMaxLength(150);

            Property(p => p.Email.Endereco)
                .HasColumnName("Email")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Email") { IsUnique = true }))
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

            Property(p => p.Senha.HashChave).HasColumnName("HashChave").IsRequired();
            Property(p => p.Senha.HashSalt).HasColumnName("HashSalt").IsRequired();
        }
    }
}