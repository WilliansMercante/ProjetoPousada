using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjetoPousada.Dominio.Entidades.Cadastro;

namespace ProjetoPousada.Infra.Mappings.Cadastro
{
    internal sealed class TipoEnderecoMapping : IEntityTypeConfiguration<TipoEnderecoEntity>
    {
        public void Configure(EntityTypeBuilder<TipoEnderecoEntity> builder)
        {
            builder.ToTable("TB_TIPO_ENDERECO", "cadastro");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_TIPO_ENDERECO");
            builder.Property(p => p.Tipo).HasColumnName("DS_TIPO_ENDERECO");
            builder.Property(p => p.FlAtivo).HasColumnName("FL_ATIVO");
        }
    }
}
