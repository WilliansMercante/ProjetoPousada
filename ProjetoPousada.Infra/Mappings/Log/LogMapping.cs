using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjetoPousada.Dominio.Entidades.Log;

namespace ProjetoPousada.Infra.Mappings.Log
{
    internal sealed class LogMapping : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable("TB_LOG", "historico");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_LOG");
            builder.Property(p => p.IdUsuario).HasColumnName("ID_USUARIO");
            builder.Property(p => p.Escopo).HasColumnName("ESCOPO");
            builder.Property(p => p.IdRegistro).HasColumnName("ID_REGISTRO");
            builder.Property(p => p.TipoOperacao).HasColumnName("TP_OPERACAO");
            builder.Property(p => p.DtCadastro).HasColumnName("DT_CADASTRO");
            builder.Property(p => p.ValoresAntigos).HasColumnName("VALORES_ANTIGOS");
            builder.Property(p => p.ValoresNovos).HasColumnName("VALORES_NOVOS");
            builder.Property(p => p.PropriedadesAlteradas).HasColumnName("PROPRIEDADES_ALTERADAS");
        }
    }
}
