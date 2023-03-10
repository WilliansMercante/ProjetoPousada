using AutoMapper;

using ProjetoPousada.Aplicacao.Config.Interfaces;
using ProjetoPousada.Aplicacao.Mapper;
using ProjetoPousada.Dominio.Entidades.Config;
using ProjetoPousada.Dominio.Helpers;
using ProjetoPousada.Dominio.Services.Interfaces;
using ProjetoPousada.ViewModel.Config;

namespace ProjetoPousada.Aplicacao.Config
{
    public class UsuarioApp : IUsuarioApp
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IAutenticarService _autenticarService;

        public UsuarioApp
        (
            IAutenticarService autenticarService
        )
        {
            _autenticarService = autenticarService;
        }

        public UsuarioViewModel Autenticar(string cpf, string senha)
        {
            try
            {
                var oUsuarioEntity = _autenticarService.Autenticar(cpf, senha);
                ExcecaoDominioHelper.Validar(oUsuarioEntity == null, "Usuário e/ou senha inválidos");
                var oUsuarioVM = _mapper.Map<UsuarioEntity, UsuarioViewModel>(oUsuarioEntity);

                return oUsuarioVM;
            }
            catch
            {
                throw;
            }
        }
    }
}
