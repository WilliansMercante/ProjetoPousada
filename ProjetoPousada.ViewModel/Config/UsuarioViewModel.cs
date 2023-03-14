namespace ProjetoPousada.ViewModel.Config
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public int Cnes { get; set; }
        public DateTime DtNascimento { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool Ativo { get; set; }

        public GrupoViewModel Grupo { get; set; }
    }
}
