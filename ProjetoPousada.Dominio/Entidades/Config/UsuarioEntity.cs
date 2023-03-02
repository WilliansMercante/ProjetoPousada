namespace ProjetoPousada.Dominio.Entidades.Config
{
    public class UsuarioEntity : Entidade
    {
        public string NmUsuario { get; set; }
        public string EmailPrincipal { get; set; }
        public string EmailSecundario { get; set; }
        public string Cpf { get; set; }
        public string Token { get; set; }
        public bool FlPrimeiroAcesso { get; set; }
        public int Cnes { get; set; }

    }
}
