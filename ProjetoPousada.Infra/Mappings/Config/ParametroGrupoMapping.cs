using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjetoPousada.Dominio.Entidades.Config;

namespace ProjetoPousada.Infra.Mappings.Config
{
    internal sealed class ParametroGrupoMapping : IEntityTypeConfiguration<ParametroGrupoEntity>
    {
        public void Configure(EntityTypeBuilder<ParametroGrupoEntity> builder)
        {
            builder.ToTable("TB_PARAMETRO_GRUPO", "config");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_PARAMETRO_GRUPO");
            builder.Property(p => p.IdParametro).HasColumnName("ID_PARAMETRO");
            builder.Property(p => p.IdGrupo).HasColumnName("ID_GRUPO");

            builder.HasOne(p => p.Parametro)
                .WithMany()
                .HasForeignKey(p => p.IdParametro);
        }
    }
}
