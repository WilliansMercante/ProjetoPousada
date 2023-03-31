using ProjetoPousada.Dominio.Entidades.Cadastro;

namespace ProjetoPousada.Dominio.Interfaces.Cadastro
{
    public interface ISexoRepository
    {
        IEnumerable<SexoEntity> Listar();

    }
}
