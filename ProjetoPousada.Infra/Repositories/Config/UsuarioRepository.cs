using Microsoft.EntityFrameworkCore;

using ProjetoPousada.Dominio.Entidades.Config;
using ProjetoPousada.Dominio.Interfaces.Config;
using ProjetoPousada.Infra.Contexts;

namespace ProjetoPousada.Infra.Repositories.Config
{
    public sealed class UsuarioRepository : RepositoryBase<UsuarioEntity, ConfiguracaoContext>, IUsuarioRepository
    {
        public UsuarioRepository(ConfiguracaoContext context) : base(context)
        {
        }

        public UsuarioEntity Autenticar(string cpf, string senha)
        {
            return _context.Usuario.Include(p => p.Grupo).FirstOrDefault(p => p.Cpf.Equals(cpf) && p.Senha.Equals(senha));
        }
    }
}
