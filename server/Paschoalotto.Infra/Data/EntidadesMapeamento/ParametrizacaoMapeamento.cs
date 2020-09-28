using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paschoalotto.Domain.Entities;

namespace Paschoalotto.Infra.Data.EntidadesMapeamento
{
    public class ParametrizacaoMapeamento : IEntityTypeConfiguration<Parametrizacao>
    {
        public void Configure(EntityTypeBuilder<Parametrizacao> builder)
        {
            builder.ToTable("Parametrizacao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MaximoParcelas).IsRequired().HasColumnType("smallint");
            builder.Property(x => x.TipoJuros).IsRequired().HasMaxLength(1).HasColumnType("char(1)");
            builder.Property(x => x.PorcertagemJuros).IsRequired().HasColumnType("numeric(8,4)");
            builder.Property(x => x.PorcentagemComissao).IsRequired().HasColumnType("numeric(8,4)");

        }
    }
}