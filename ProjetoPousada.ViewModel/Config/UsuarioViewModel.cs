namespace ProjetoPousada.ViewModel.Config
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string NmUsuario { get; set; }
        public string EmailPrincipal { get; set; }
        public string EmailSecundario { get; set; }
        public string Cpf { get; set; }
        public string Token { get; set; }
        public bool FlPrimeiroAcesso { get; set; }
        public int Cnes { get; set; }

        public GrupoViewModel Grupo { get; set; }
    }
}
