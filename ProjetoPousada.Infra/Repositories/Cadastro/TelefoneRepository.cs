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

        public void Inativar(int id)
        {
            var oTelefoneEntity = _context.Telefone.FirstOrDefault(p => p.Id.Equals(id));
            oTelefoneEntity.FlAtivo = false;
            Atualizar(oTelefoneEntity);
        }

        public IEnumerable<EnderecoEntity> ListarPorCliente(int IdCliente)
        {
            var lstEnderecoEntity = _context.Endereco.Where(p => p.IdCliente.Equals(IdCliente));
            return lstEnderecoEntity;
        }

    }
}
