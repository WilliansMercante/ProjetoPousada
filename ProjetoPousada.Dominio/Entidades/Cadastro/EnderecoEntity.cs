namespace ProjetoPousada.Dominio.Entidades.Cadastro
{
    public class EnderecoEntity : Entidade
    {
        public int IdCliente { get; set; }
        public int IdTipoEndereco { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public DateTime DtCadastro { get; set; }
        public bool FlAtivo { get; set; }

        public TipoEnderecoEntity TipoEndereco { get; set; }

    }
}
