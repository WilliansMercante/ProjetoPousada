namespace ProjetoPousada.ViewModel.Cadastro
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoEndereco { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlAtivo { get; set; }

        public TipoEnderecoViewModel TipoEndereco { get; set; }
    }
}
