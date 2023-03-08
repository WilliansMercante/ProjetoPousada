using ProjetoPousada.Dominio.Entidades.Cadastro;
using ProjetoPousada.Dominio.Interfaces.Cadastro;
using ProjetoPousada.Infra.Contexts;

namespace ProjetoPousada.Infra.Repositories.Cadastro
{
    public sealed class EnderecoRepository : RepositoryBase<EnderecoEntity, ProjetoPousadaContext>, IEnderecoRepository
    {
        public EnderecoRepository(ProjetoPousadaContext context) : base(context)
        {
        }

    }
}
