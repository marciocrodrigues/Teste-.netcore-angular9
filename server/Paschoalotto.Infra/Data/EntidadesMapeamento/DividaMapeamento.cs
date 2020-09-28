using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paschoalotto.Domain.Entities;

namespace Paschoalotto.Infra.Data
{
    public class DividaMapeamento : IEntityTypeConfiguration<Divida>
    {
        public void Configure(EntityTypeBuilder<Divida> builder)
        {
            builder.ToTable("Divida");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ValorOriginal).IsRequired().HasColumnType("numeric(18,2)");
            builder.Property(x => x.DataVencimento).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.DocumentoDevedor).IsRequired().HasMaxLength(14).HasColumnType("varchar(14)");
            builder.Property(x => x.UsuarioId).IsRequired();
        }
    }
}