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
    public sealed class ClienteApp : IClienteApp
    {
        private readonly IClienteRepository _ClienteRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IUnitOfWork<ProjetoPousadaContext> _unitOfWork;
        public ClienteApp
        (
            IClienteRepository clienteRepository,
            IUnitOfWork<ProjetoPousadaContext> unitOfWork
        )
        {
            _ClienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(ClienteViewModel oClienteViewModel)
        {
            var oClienteEntity = _mapper.Map<ClienteEntity>(oClienteViewModel);
            _ClienteRepository.Atualizar(oClienteEntity);
            _unitOfWork.Commit();
        }

        public ClienteViewModel ConsultarPorId(int id)
        {
            var oClienteEntity = _ClienteRepository.ConsultarPorId(id);
            var oClienteViewModel = _mapper.Map<ClienteViewModel>(oClienteEntity);
            return oClienteViewModel;
        }

        public void Inativar(int id)
        {
            _ClienteRepository.Inativar(id);
            _unitOfWork.Commit();
        }

        public void Incluir(ClienteViewModel enderecoVM)
        {
            var oClienteEntity = _mapper.Map<ClienteEntity>(enderecoVM);
            _ClienteRepository.Incluir(oClienteEntity);
            _unitOfWork.Commit();
        }

        public IEnumerable<ClienteViewModel> Listar()
        {
            var lstClienteEntity = _ClienteRepository.Listar();
            var lstClienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(lstClienteEntity);
            return lstClienteViewModel;
        }
        public IEnumerable<ClienteViewModel> ListarUltimos20()
        {
            var lstClienteEntity = _ClienteRepository.ListarUltimos20();
            var lstClienteViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(lstClienteEntity);
            return lstClienteViewModel;
        }
    }
}
