namespace ProjetoPousada.Dominio.Entidades.Config
{
	public class UsuarioEntity : Entidade
	{
        public int IdGrupo { get; set; }
        public string Nome { get; set; }
		public string Email { get; set; }
		public string Cpf { get; set; }
		public string Senha { get; set; }
		public DateTime DtNascimento { get; set; }
		public DateTime DtCadastro { get; set; }
		public bool Ativo { get; set; }

		public GrupoEntity Grupo { get; set; }
	}
}
