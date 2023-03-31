using AutoMapper;

using ProjetoPousada.Aplicacao.Mapper;
using ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces;
using ProjetoPousada.Dominio.Interfaces.Cadastro;
using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro
{

    public sealed class SexoApp : ISexoApp
    {
        private readonly ISexoRepository _sexoRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();

        public SexoApp
        (
             ISexoRepository sexoRepository
        )
        {
            _sexoRepository = sexoRepository;
        }

        public IEnumerable<SexoViewModel> Listar()
        {
            var lstSexoEntity = _sexoRepository.Listar();
            var lstSexoViewModel = _mapper.Map<IEnumerable<SexoViewModel>>(lstSexoEntity);
            return lstSexoViewModel;
        }
    }
}
