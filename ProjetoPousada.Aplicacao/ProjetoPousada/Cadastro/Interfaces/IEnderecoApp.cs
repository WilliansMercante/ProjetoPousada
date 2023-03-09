using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces
{
    public interface IEnderecoApp
    {
        void Incluir(EnderecoViewModel obj);
        void Atualizar(EnderecoViewModel obj);
        EnderecoViewModel ConsultarPorId(int id);
        IEnumerable<EnderecoViewModel> Listar();
        IEnumerable<EnderecoViewModel> ListarPorCliente(int IdCliente);
        void Inativar(int id);
    }
}
