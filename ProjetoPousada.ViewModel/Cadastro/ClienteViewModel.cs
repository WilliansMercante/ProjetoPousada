namespace ProjetoPousada.ViewModel.Cadastro
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public string CPF { get; set; }
        public string Rg { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlAtivo { get; set; }

        public ICollection<EnderecoViewModel> Enderecos { get; set; }
        public ICollection<TelefoneViewModel> Telefones { get; set; }
    }
}
