using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces
{
    public interface IClienteApp
    {
        void Incluir(ClienteViewModel obj);
        void Atualizar(ClienteViewModel obj);
        ClienteViewModel ConsultarPorId(int id);
        IEnumerable<ClienteViewModel> Listar();
        IEnumerable<ClienteViewModel> ListarUltimos20Ativos();
        IEnumerable<ClienteViewModel> Consultar(string nome, string cpf, DateTime dtNascimento);
        void Inativar(int id);
    }
}
