using Microsoft.EntityFrameworkCore;

using ProjetoPousada.Dominio.Entidades;
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

        public IEnumerable<ClienteEntity> Consultar(string nome, string cpf, DateTime dtNascimento)
        {

            var query = _context.Cliente.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.Nome.Contains(nome));
            }

            if (!string.IsNullOrEmpty(cpf))
            {
                query = query.Where(p => p.CPF == cpf);
            }

            if (dtNascimento != DateTime.MinValue)
            {
                query = query.Where(p => p.DtNascimento == dtNascimento);
            }

            var resultado = query.AsEnumerable();

            return resultado;
        }


        public void Inativar(int id)
        {
            var oClienteEntity = _context.Cliente.FirstOrDefault(p => p.Id.Equals(id));
            oClienteEntity.FlAtivo = false;
            Atualizar(oClienteEntity);
        }

        public IEnumerable<ClienteEntity> ListarUltimos20Ativos()
        {
            var lstClienteEntity = _context.Cliente.Where(p => p.FlAtivo).OrderByDescending(p => p.DtCadastro).Take(20);
            return lstClienteEntity;
        }


    }
}
