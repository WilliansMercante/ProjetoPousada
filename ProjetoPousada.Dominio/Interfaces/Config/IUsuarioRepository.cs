using ProjetoPousada.Dominio.Entidades.Config;

namespace ProjetoPousada.Dominio.Interfaces.Config
{
    public interface IUsuarioRepository
    {
        UsuarioEntity Autenticar(string cpf, string senha);
        UsuarioEntity ConsultarPorId(int Id);
        void Incluir(UsuarioEntity usuarioVM);
        IEnumerable<UsuarioEntity> Listar();
    }
}
