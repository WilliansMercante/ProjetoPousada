namespace ProjetoPousada.Dominio.Entidades.Log
{
    public class LogEntity : Entidade
    {
        public int IdUsuario { get; set; }
        public string Escopo { get; set; }
        public int IdRegistro { get; set; }
        public string TipoOperacao { get; set; }
        public DateTime DtCadastro { get; set; }
        public string ValoresAntigos { get; set; }
        public string ValoresNovos { get; set; }
        public string PropriedadesAlteradas { get; set; }
    }
}
