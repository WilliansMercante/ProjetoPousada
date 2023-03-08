using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjetoPousada.Dominio.Entidades.Cadastro;

namespace ProjetoPousada.Infra.Mappings.Cadastro
{
    internal sealed class TipoTelefoneMapping : IEntityTypeConfiguration<TipoTelefoneEntity>
    {
        public void Configure(EntityTypeBuilder<TipoTelefoneEntity> builder)
        {
            builder.ToTable("TB_TIPO_TELEFONE", "cadastro");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_TIPO_TELEFONE");
            builder.Property(p => p.TipoTelefone).HasColumnName("DS_TELEFONE");
            builder.Property(p => p.FlAtivo).HasColumnName("FL_ATIVO");
        }
    }
}
