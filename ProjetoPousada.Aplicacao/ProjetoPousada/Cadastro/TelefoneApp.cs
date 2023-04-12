using AutoMapper;

using ProjetoPousada.Aplicacao.Mapper;
using ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces;
using ProjetoPousada.Dominio.Entidades.Cadastro;
using ProjetoPousada.Dominio.Interfaces;
using ProjetoPousada.Dominio.Interfaces.Cadastro;
using ProjetoPousada.Infra.Contexts;
using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro
{
    public sealed class TelefoneApp : ITelefoneApp
    {
        private readonly ITelefoneRepository _TelefoneRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IUnitOfWork<ProjetoPousadaContext> _unitOfWork;
        public TelefoneApp
        (
            ITelefoneRepository telefoneRepository,
            IUnitOfWork<ProjetoPousadaContext> unitOfWork
        )
        {
            _TelefoneRepository = telefoneRepository;
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(TelefoneViewModel oTelefoneViewModel)
        {
            var oTelefoneEntity = _mapper.Map<TelefoneEntity>(oTelefoneViewModel);
            _TelefoneRepository.Atualizar(oTelefoneEntity);
            _unitOfWork.Commit();
        }

        public TelefoneViewModel ConsultarPorId(int id)
        {
            var oTelefoneEntity = _TelefoneRepository.ConsultarPorId(id);
            var oTelefoneViewModel = _mapper.Map<TelefoneViewModel>(oTelefoneEntity);
            return oTelefoneViewModel;
        }

        public void Inativar(int id)
        {
            _TelefoneRepository.Inativar(id);
            _unitOfWork.Commit();
        }

        public void Incluir(TelefoneViewModel enderecoVM)
        {
            var oTelefoneEntity = _mapper.Map<TelefoneEntity>(enderecoVM);
            oTelefoneEntity.FlAtivo = true;
            oTelefoneEntity.DtCadastro = DateTime.Now;
            _TelefoneRepository.Incluir(oTelefoneEntity);
            _unitOfWork.Commit();
        }

        public IEnumerable<TelefoneViewModel> Listar()
        {
            var lstTelefoneEntity = _TelefoneRepository.Listar();
            var lstTelefoneViewModel = _mapper.Map<IEnumerable<TelefoneViewModel>>(lstTelefoneEntity);
            return lstTelefoneViewModel;
        }

        public IEnumerable<TelefoneViewModel> ListarPorCliente(int IdCliente)
        {
            var lstTelefoneEntity = _TelefoneRepository.ListarPorCliente(IdCliente);
            var lstTelefoneViewModel = _mapper.Map<IEnumerable<TelefoneViewModel>>(lstTelefoneEntity);
            return lstTelefoneViewModel;
        }
    }

}
