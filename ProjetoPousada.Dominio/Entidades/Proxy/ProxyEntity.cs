namespace ProjetoPousada.Dominio.Entidades.Proxy
{
    public class ProxyEntity
    {
        public bool Habilitado { get; set; }
        public string Host { get; set; }
        public int Porta { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string Dominio { get; set; }
    }
}
