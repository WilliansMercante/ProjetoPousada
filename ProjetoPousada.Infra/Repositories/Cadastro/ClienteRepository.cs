using ProjetoPousada.Dominio.Entidades.Cadastro;
using ProjetoPousada.Dominio.Interfaces.Cadastro;
using ProjetoPousada.Infra.Contexts;

namespace ProjetoPousada.Infra.Repositories.Cadastro
{
    public sealed class ClienteRepository : RepositoryBase<ClienteEntity, ProjetoPousadaContext>, IClienteRepository
    {
        public ClienteRepository(ProjetoPousadaContext context) : base(context)
        {
        }

    }
}
