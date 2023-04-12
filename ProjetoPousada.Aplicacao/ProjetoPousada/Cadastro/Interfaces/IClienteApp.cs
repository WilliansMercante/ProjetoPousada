using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces
{
    public interface IClienteApp
    {
        int Incluir(ClienteViewModel obj);
        void Atualizar(ClienteViewModel obj);
        ClienteViewModel ConsultarPorId(int id);
        ClienteViewModel ConsultarPorCPF(string cpf);
        IEnumerable<ClienteViewModel> Listar();
        IEnumerable<ClienteViewModel> ListarUltimos20Ativos();
        IEnumerable<ClienteViewModel> ListarUltimos20();
        IEnumerable<ClienteViewModel> Consultar(string nome, string cpf, DateTime? dtNascimento);
        void Inativar(int id);
    }
}
