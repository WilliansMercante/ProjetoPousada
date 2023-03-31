using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjetoPousada.Dominio.Entidades.Cadastro;

namespace ProjetoPousada.Infra.Mappings.Cadastro
{

    internal sealed class SexoMapping : IEntityTypeConfiguration<SexoEntity>
    {
        public void Configure(EntityTypeBuilder<SexoEntity> builder)
        {
            builder.ToTable("TB_SEXO", "cadastro");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_SEXO");
            builder.Property(p => p.Sexo).HasColumnName("DS_GENERO");
        }
    }
}
