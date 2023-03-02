using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjetoPousada.Dominio.Entidades.Config;

namespace ProjetoPousada.Infra.Mappings.Config
{
    internal sealed class ParametroMapping : IEntityTypeConfiguration<ParametroEntity>
    {
        public void Configure(EntityTypeBuilder<ParametroEntity> builder)
        {
            builder.ToTable("TB_PARAMETRO", "config");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_PARAMETRO");
            builder.Property(p => p.DsParametro).HasColumnName("DS_PARAMETRO");
            builder.Property(p => p.Observacao).HasColumnName("DS_OBSERVACAO");
        }
    }
}
