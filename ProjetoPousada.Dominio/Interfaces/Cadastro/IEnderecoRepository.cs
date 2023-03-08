using ProjetoPousada.Dominio.Entidades.Cadastro;

namespace ProjetoPousada.Dominio.Interfaces.Cadastro
{
    public interface IEnderecoRepository
    {
        void Incluir(EnderecoEntity obj);
        void Atualizar(EnderecoEntity obj);
        EnderecoEntity ConsultarPorId(int id);
        void Excluir(int id);
        IEnumerable<EnderecoEntity> Listar();
    }
}
