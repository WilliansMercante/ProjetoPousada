using ProjetoPousada.ViewModel.Config;

namespace ProjetoPousada.Aplicacao.Config.Interfaces
{
    public interface IUsuarioApp
    {
        UsuarioViewModel Autenticar(string cpf, string senha);
        UsuarioViewModel ConsultarPorId(int Id);
        void Incluir(UsuarioViewModel usuarioVM);
        IEnumerable<UsuarioViewModel> Listar();
    }
}
