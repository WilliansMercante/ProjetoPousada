using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using ProjetoPousada.Dominio.Entidades.Config;
using ProjetoPousada.Dominio.Entidades.Proxy;
using ProjetoPousada.Dominio.Interfaces.Config;
using ProjetoPousada.Infra.Contexts;
using ProjetoPousada.Infra.Extensions;

namespace ProjetoPousada.Infra.Repositories.Config
{

    public sealed class UsuarioRepository : RepositoryBase<UsuarioEntity, ConfiguracaoContext>, IUsuarioRepository
    {
        public UsuarioRepository(ConfiguracaoContext context) : base(context)
        {
        }

        public UsuarioEntity Autenticar(string cpf, string senha, int idSistema)
        {
            throw new NotImplementedException();
        }

        public GrupoEntity ObterGrupo(int idUsuario, int idSistema, string token)
        {
            throw new NotImplementedException();
        }
    }


}
