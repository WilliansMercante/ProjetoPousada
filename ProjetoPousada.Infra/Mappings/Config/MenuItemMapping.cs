using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjetoPousada.Dominio.Entidades.Config;

namespace ProjetoPousada.Infra.Mappings.Config
{
    internal sealed class MenuItemMapping : IEntityTypeConfiguration<MenuItemEntity>
    {
        public void Configure(EntityTypeBuilder<MenuItemEntity> builder)
        {
            builder.ToTable("TB_MENU_ITEM", "config");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID_MENU_ITEM");
            builder.Property(p => p.IdMenuItemSuperior).HasColumnName("ID_MENU_ITEM_SUPERIOR");
            builder.Property(p => p.NmItem).HasColumnName("NM_ITEM");
            builder.Property(p => p.NmArea).HasColumnName("NM_AREA");
            builder.Property(p => p.NmController).HasColumnName("NM_CONTROLLER");
            builder.Property(p => p.NmAction).HasColumnName("NM_ACTION");
            builder.Property(p => p.ClassIcon).HasColumnName("CLASS_ICON");
            builder.Property(p => p.FlStatus).HasColumnName("FL_STATUS");
            builder.Property(p => p.FlRedirecionamentoExterno).HasColumnName("FL_REDIRECIONAMENTO_EXTERNO");
            builder.Property(p => p.LnkRedirecionamento).HasColumnName("LNK_REDIRECIONAMENTO");

            builder.HasMany(p => p.SubItens)
                .WithOne()
                .HasForeignKey(p => p.IdMenuItemSuperior);
        }
    }
}
