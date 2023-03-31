using ProjetoPousada.Dominio.Entidades.Cadastro;
using ProjetoPousada.Dominio.Interfaces.Cadastro;
using ProjetoPousada.Infra.Contexts;

namespace ProjetoPousada.Infra.Repositories.Cadastro
{

    public sealed class SexoRepository : RepositoryBase<SexoEntity, ProjetoPousadaContext>, ISexoRepository
    {
        public SexoRepository(ProjetoPousadaContext context) : base(context)
        {
        }
    }
}
