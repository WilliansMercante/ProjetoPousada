using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjetoPousada.Dominio.Entidades.Cadastro;

namespace ProjetoPousada.Infra.Mappings.Cadastro
{
    internal sealed class EnderecoMapping : IEntityTypeConfiguration<EnderecoEntity>
    {
        public void Configure(EntityTypeBuilder<EnderecoEntity> builder)
        {
            builder.ToTable("TB_ENDERECO", "cadastro");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_ENDERECO");
            builder.Property(p => p.IdCliente).HasColumnName("ID_CLIENTE");
            builder.Property(p => p.IdTipoEndereco).HasColumnName("ID_TIPO_ENDERECO");
            builder.Property(p => p.Rua).HasColumnName("NM_LOGRADOURO");
            builder.Property(p => p.Numero).HasColumnName("NR_LOGRADORO");
            builder.Property(p => p.Cep).HasColumnName("NR_CEP");
            builder.Property(p => p.Bairro).HasColumnName("NM_BAIRRO");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
            builder.Property(p => p.FlAtivo).HasColumnName("FL_ATIVO");

            builder.HasOne(p => p.TipoEndereco).WithMany().HasForeignKey(p => p.IdTipoEndereco);
        }
    }
}
