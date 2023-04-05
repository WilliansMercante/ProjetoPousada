using ProjetoPousada.Dominio.Entidades.Cadastro;

namespace ProjetoPousada.Dominio.Interfaces.Cadastro
{
    public interface ITipoEnderecoRepository
    {
        IEnumerable<TipoEnderecoEntity> Listar();
    }
}
