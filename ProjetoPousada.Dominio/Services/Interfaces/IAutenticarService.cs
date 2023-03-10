using ProjetoPousada.Dominio.Entidades.Config;

namespace ProjetoPousada.Dominio.Services.Interfaces
{
    public interface IAutenticarService
    {
        UsuarioEntity Autenticar(string cpf, string senha);
    }
}
