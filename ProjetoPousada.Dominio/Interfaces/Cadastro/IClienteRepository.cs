using ProjetoPousada.Dominio.Entidades.Cadastro;

namespace ProjetoPousada.Dominio.Interfaces.Cadastro
{
    public interface IClienteRepository
    {
        void Incluir(ClienteEntity obj);
        void Atualizar(ClienteEntity obj);
        ClienteEntity ConsultarPorId(int id);
        void Excluir(int id);
        IEnumerable<ClienteEntity> Listar();
        IEnumerable<ClienteEntity> ListarUltimos20();
        void Inativar(int id);
    }
}
