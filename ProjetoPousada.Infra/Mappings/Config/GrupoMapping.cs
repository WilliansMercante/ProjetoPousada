using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjetoPousada.Dominio.Entidades.Config;

namespace ProjetoPousada.Infra.Mappings.Config
{
	internal sealed class GrupoMapping : IEntityTypeConfiguration<GrupoEntity>
	{
		public void Configure(EntityTypeBuilder<GrupoEntity> builder)
		{
			builder.ToTable("TB_GRUPO", "config");

			builder.HasKey(p => p.Id);

			builder.Property(p => p.Id).HasColumnName("ID_GRUPO");
			builder.Property(p => p.DsGrupo).HasColumnName("DS_GRUPO");
			builder.Property(p => p.FlAtivo).HasColumnName("FL_ATIVO");
		}
	}
}
