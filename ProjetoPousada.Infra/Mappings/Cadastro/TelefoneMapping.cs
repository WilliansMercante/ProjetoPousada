using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjetoPousada.Dominio.Entidades.Cadastro;

namespace ProjetoPousada.Infra.Mappings.Cadastro
{
    internal sealed class TelefoneMapping : IEntityTypeConfiguration<TelefoneEntity>
    {
        public void Configure(EntityTypeBuilder<TelefoneEntity> builder)
        {
            builder.ToTable("TB_TELEFONE", "cadastro");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_TELEFONE");
            builder.Property(p => p.IdCliente).HasColumnName("ID_CLIENTE");
            builder.Property(p => p.TipoTelefone).HasColumnName("ID_TIPO_TELEFONE");
            builder.Property(p => p.DDD).HasColumnName("NR_DDD");
            builder.Property(p => p.Numero).HasColumnName("NR_TELEFONE");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
            builder.Property(p => p.FlAtivo).HasColumnName("FL_ATIVO");

            builder.HasOne(p => p.TipoTelefone).WithMany().HasForeignKey(p => p.IdTipoTelefone);
        }
    }
}
