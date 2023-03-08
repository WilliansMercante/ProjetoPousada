namespace ProjetoPousada.ViewModel.Cadastro
{
    public class TelefoneViewModel
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoTelefone { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlAtivo { get; set; }

        public TipoTelefoneViewModel TipoTelefone { get; set; }
    }
}
