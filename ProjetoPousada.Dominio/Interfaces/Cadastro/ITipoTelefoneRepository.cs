using ProjetoPousada.Dominio.Entidades.Cadastro;

namespace ProjetoPousada.Dominio.Interfaces.Cadastro
{
    public interface ITipoTelefoneRepository
    {
        IEnumerable<TipoTelefoneEntity> Listar();
    }
}
