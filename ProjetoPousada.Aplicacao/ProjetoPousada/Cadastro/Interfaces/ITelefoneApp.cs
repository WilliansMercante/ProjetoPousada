using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces
{
    public interface ITelefoneApp
    {
        void Incluir(TelefoneViewModel obj);
        void Atualizar(TelefoneViewModel obj);
        TelefoneViewModel ConsultarPorId(int id);
        IEnumerable<TelefoneViewModel> Listar();
        IEnumerable<TelefoneViewModel> ListarPorCliente(int IdCliente);
        void Inativar(int id);
    }
}
