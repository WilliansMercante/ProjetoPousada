using ProjetoPousada.Dominio.Entidades.Config;
using ProjetoPousada.Dominio.Helpers;
using ProjetoPousada.Dominio.Interfaces.Config;
using ProjetoPousada.Dominio.Services.Interfaces;

namespace ProjetoPousada.Dominio.Services
{
    public sealed class AutenticarService : IAutenticarService
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        public AutenticarService
        (
            IUsuarioRepository usuarioRepository
        )
        {
            _UsuarioRepository = usuarioRepository;
        }

        public UsuarioEntity Autenticar(string cpf, string senha)
        {
            ExcecaoDominioHelper.Validar(string.IsNullOrEmpty(cpf), "Informe o Nº de CPF");
            ExcecaoDominioHelper.Validar(string.IsNullOrEmpty(senha), "Informe a Senha");

            return _UsuarioRepository.Autenticar(cpf, senha);
        }
    }
}
