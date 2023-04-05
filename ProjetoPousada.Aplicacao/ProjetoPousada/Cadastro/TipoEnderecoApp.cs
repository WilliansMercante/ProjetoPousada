using AutoMapper;

using ProjetoPousada.Aplicacao.Mapper;
using ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces;
using ProjetoPousada.Dominio.Interfaces.Cadastro;
using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro
{
    public sealed class TipoEnderecoApp : ITipoEnderecoApp
    {
        private readonly ITipoEnderecoRepository _tipoEnderecoRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        public TipoEnderecoApp
        (
            ITipoEnderecoRepository tipoEnderecoRepository

        )
        {
            _tipoEnderecoRepository = tipoEnderecoRepository;

        }

        public IEnumerable<TipoEnderecoViewModel> Listar()
        {
            var lstTipoEnderecoEntity = _tipoEnderecoRepository.Listar();
            var lstTipoEnderecoViewModel = _mapper.Map<IEnumerable<TipoEnderecoViewModel>>(lstTipoEnderecoEntity);
            return lstTipoEnderecoViewModel;
        }
    }
}
