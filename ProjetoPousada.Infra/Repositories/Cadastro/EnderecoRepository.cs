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

        public void Inativar(int id)
        {
            var enderecoDM = _context.Endereco.FirstOrDefault(p => p.Id.Equals(id));
            enderecoDM.FlAtivo = false;
            Atualizar(enderecoDM);
        }

        public IEnumerable<EnderecoEntity> ListarPorCliente(int IdCliente)
        {
            var lstEnderecoEntity = _context.Endereco.Where(p => p.IdCliente.Equals(IdCliente));
            return lstEnderecoEntity;
        }
    }
}
