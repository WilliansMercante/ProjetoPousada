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

        public void Inativar(int id)
        {
            var oClienteEntity = _context.Cliente.FirstOrDefault(p => p.Id.Equals(id));
            oClienteEntity.FlAtivo = false;
            Atualizar(oClienteEntity);
        }

        public IEnumerable<ClienteEntity> ListarUltimos20()
        {
            var lstClienteEntity = _context.Cliente.OrderByDescending(p => p.DtCadastro).Take(20);
            return lstClienteEntity;
        }
    }
}
