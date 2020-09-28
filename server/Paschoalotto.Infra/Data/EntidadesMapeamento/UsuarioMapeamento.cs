using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paschoalotto.Domain.Entities;
using System.Collections.Generic;

namespace Paschoalotto.Infra.Data.EntidadesMapeamento
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Codigo).IsRequired().HasMaxLength(10).HasColumnType("varchar(10)");
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(10).HasColumnType("varchar(10)");
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255).HasColumnType("varchar(255)");
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(11).HasColumnType("varchar(11)");
            builder.HasMany(x => x.Dividas)
                .WithOne(d => d.Usuario)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new List<Usuario>()
            {
                new Usuario("123456", "12345678909", "administrador", "00000000000" ),
                new Usuario("123456", "12345678910", "administrador2", "00000000000" ),
            });
        }
    }
}