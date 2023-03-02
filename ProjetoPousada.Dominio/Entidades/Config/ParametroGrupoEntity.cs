namespace ProjetoPousada.Dominio.Entidades.Config
{
    public class ParametroGrupoEntity : Entidade
    {
        public int IdParametro { get; set; }
        public int IdGrupo { get; set; }
        public int? IdUnidade { get; set; }

        public virtual ParametroEntity Parametro { get; set; }
    }
}
