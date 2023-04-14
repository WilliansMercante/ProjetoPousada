using AutoMapper;

using ProjetoPousada.Aplicacao.Config.Interfaces;
using ProjetoPousada.Aplicacao.Mapper;
using ProjetoPousada.Dominio.Entidades.Config;
using ProjetoPousada.Dominio.Helpers;
using ProjetoPousada.Dominio.Interfaces;
using ProjetoPousada.Dominio.Interfaces.Config;
using ProjetoPousada.Dominio.Services.Interfaces;
using ProjetoPousada.Infra.Contexts;
using ProjetoPousada.ViewModel.Config;

namespace ProjetoPousada.Aplicacao.Config
{
    public class UsuarioApp : IUsuarioApp
    {
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IAutenticarService _autenticarService;
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly IUnitOfWork<ProjetoPousadaContext> _unitOfWork;

        public UsuarioApp
        (
            IAutenticarService autenticarService,
            IUsuarioRepository usuarioRepository,
            IUnitOfWork<ProjetoPousadaContext> unitOfWork
        )
        {
            _autenticarService = autenticarService;
            _UsuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }     

        public void Incluir(UsuarioViewModel usuarioVM)
        {
            var usuarioEntity = _mapper.Map<UsuarioEntity>(usuarioVM);
            _UsuarioRepository.Incluir(usuarioEntity);
            _unitOfWork.Commit();
        }

        public IEnumerable<UsuarioViewModel> Listar()
        {
            var lstUsuarioEntity = _UsuarioRepository.Listar();
            var lstUsuarioViewModel = _mapper.Map<IEnumerable<UsuarioViewModel>>(lstUsuarioEntity);
            return lstUsuarioViewModel;
        }

        public UsuarioViewModel ConsultarPorId(int Id)
        {
            var oUsuarioEntity = _UsuarioRepository.ConsultarPorId(Id);
            var oUsuarioViewModel = _mapper.Map<UsuarioViewModel>(oUsuarioEntity);
            return oUsuarioViewModel;
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
