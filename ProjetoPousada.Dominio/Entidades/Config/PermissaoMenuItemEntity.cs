namespace ProjetoPousada.Dominio.Entidades.Config
{
    public class PermissaoMenuItemEntity : Entidade
    {
        public int IdMenuItem { get; set; }
        public int IdGrupo { get; set; }

        public virtual MenuItemEntity MenuItem { get; set; }
    }
}
