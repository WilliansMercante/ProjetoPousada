using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjetoPousada.Dominio.Entidades.Cadastro;

namespace ProjetoPousada.Infra.Mappings.Cadastro
{
    internal sealed class ClienteMapping : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("TB_CLIENTE", "cadastro");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_CLIENTE");
            builder.Property(p => p.Nome).HasColumnName("NM_CLIENTE");
            builder.Property(p => p.DtNascimento).HasColumnName("DT_NASCIMENTO");
            builder.Property(p => p.CPF).HasColumnName("NR_CPF");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
            builder.Property(p => p.Rg).HasColumnName("NR_RG");
            builder.Property(p => p.FlAtivo).HasColumnName("FL_ATIVO");
            builder.Property(p => p.IdSexo).HasColumnName("ID_SEXO");            

            builder.HasMany(p => p.Telefones).WithOne().HasForeignKey(p => p.IdCliente);
            builder.HasMany(p => p.Enderecos).WithOne().HasForeignKey(p => p.IdCliente);

            builder.HasOne(p => p.Sexo).WithMany().HasForeignKey(p => p.IdSexo);
        }
    }
}
