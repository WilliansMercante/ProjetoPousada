using AutoMapper;

using ProjetoPousada.Aplicacao.Mapper;
using ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces;
using ProjetoPousada.Dominio.Interfaces.Cadastro;
using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro
{
    public sealed class TipoTelefoneApp : ITipoTelefoneApp
    {
        private readonly ITipoTelefoneRepository _tipoTelefoneRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        public TipoTelefoneApp
        (
            ITipoTelefoneRepository tipoTelefoneRepository

        )
        {
            _tipoTelefoneRepository = tipoTelefoneRepository;

        }

        public IEnumerable<TipoTelefoneViewModel> Listar()
        {
            var lstTipoTelefoneEntity = _tipoTelefoneRepository.Listar();
            var lstTipoTelefoneViewModel = _mapper.Map<IEnumerable<TipoTelefoneViewModel>>(lstTipoTelefoneEntity);
            return lstTipoTelefoneViewModel;
        }
    }
}
