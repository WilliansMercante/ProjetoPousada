using ProjetoPousada.Dominio.Entidades.Cadastro;
using ProjetoPousada.Dominio.Interfaces.Cadastro;
using ProjetoPousada.Infra.Contexts;

namespace ProjetoPousada.Infra.Repositories.Cadastro
{
    public sealed class TipoEnderecoRepository : RepositoryBase<TipoEnderecoEntity, ProjetoPousadaContext>, ITipoEnderecoRepository
    {
        public TipoEnderecoRepository(ProjetoPousadaContext context) : base(context)
        {
        }
    }
}
