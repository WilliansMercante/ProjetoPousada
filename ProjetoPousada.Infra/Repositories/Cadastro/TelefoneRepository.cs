using ProjetoPousada.Dominio.Entidades.Cadastro;
using ProjetoPousada.Dominio.Interfaces.Cadastro;
using ProjetoPousada.Infra.Contexts;

namespace ProjetoPousada.Infra.Repositories.Cadastro
{
    public sealed class TelefoneRepository : RepositoryBase<TelefoneEntity, ProjetoPousadaContext>, ITelefoneRepository
    {
        public TelefoneRepository(ProjetoPousadaContext context) : base(context)
        {
        }

    }
}
