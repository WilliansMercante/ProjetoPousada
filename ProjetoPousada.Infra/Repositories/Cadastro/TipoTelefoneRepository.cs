using ProjetoPousada.Dominio.Entidades.Cadastro;
using ProjetoPousada.Dominio.Interfaces.Cadastro;
using ProjetoPousada.Infra.Contexts;

namespace ProjetoPousada.Infra.Repositories.Cadastro
{
    public sealed class TipoTelefoneRepository : RepositoryBase<TipoTelefoneEntity, ProjetoPousadaContext>, ITipoTelefoneRepository
    {
        public TipoTelefoneRepository(ProjetoPousadaContext context) : base(context)
        {
        }
    }
}
