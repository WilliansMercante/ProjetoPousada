using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjetoPousada.Dominio.Entidades.Config;

namespace ProjetoPousada.Infra.Mappings.Config
{
    internal sealed class UsuarioMapping : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("TB_USUARIO", "config");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_USUARIO");
            builder.Property(p => p.Nome).HasColumnName("NM_USUARIO");
            builder.Property(p => p.Cpf).HasColumnName("NR_CPF");
            builder.Property(p => p.DtNascimento).HasColumnName("DT_NASCIMENTO");
            builder.Property(p => p.Email).HasColumnName("DS_EMAIL");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
            builder.Property(p => p.Senha).HasColumnName("DS_SENHA");
            builder.Property(p => p.Ativo).HasColumnName("FL_ATIVO");
        }
    }
}
