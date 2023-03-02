using ProjetoPousada.Dominio.Entidades.Config;

namespace ProjetoPousada.Dominio.Interfaces.Config.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioEntity Autenticar(string cpf, string senha, int idSistema);
        GrupoEntity ObterGrupo(int idUsuario, int idSistema, string token);
    }
}
