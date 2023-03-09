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
    public sealed class EnderecoApp : IEnderecoApp
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper = MapperConfig.RegisterMappers();
        private readonly IUnitOfWork<ProjetoPousadaContext> _unitOfWork;
        public EnderecoApp
        (
            IEnderecoRepository enderecoRepository,
            IUnitOfWork<ProjetoPousadaContext> unitOfWork
        )
        {
            _enderecoRepository = enderecoRepository;
            _unitOfWork = unitOfWork;
        }

        public void Atualizar(EnderecoViewModel oEnderecoViewModel)
        {
            var oEnderecoEntity = _mapper.Map<EnderecoEntity>(oEnderecoViewModel);
            _enderecoRepository.Atualizar(oEnderecoEntity);
            _unitOfWork.Commit();
        }

        public EnderecoViewModel ConsultarPorId(int id)
        {
            var oEnderecoEntity = _enderecoRepository.ConsultarPorId(id);
            var oEnderecoViewModel = _mapper.Map<EnderecoViewModel>(oEnderecoEntity);
            return oEnderecoViewModel;
        }

        public void Inativar(int id)
        {
            _enderecoRepository.Inativar(id);
            _unitOfWork.Commit();
        }

        public void Incluir(EnderecoViewModel oEnderecoViewModel)
        {
            var oEnderecoEntity = _mapper.Map<EnderecoEntity>(oEnderecoViewModel);
            _enderecoRepository.Incluir(oEnderecoEntity);
            _unitOfWork.Commit();
        }

        public IEnumerable<EnderecoViewModel> Listar()
        {
            var lstEnderecoEntity = _enderecoRepository.Listar();
            var lstEnderecoViewModel = _mapper.Map<IEnumerable<EnderecoViewModel>>(lstEnderecoEntity);
            return lstEnderecoViewModel;
        }

        public IEnumerable<EnderecoViewModel> ListarPorCliente(int IdCliente)
        {
            var lstEnderecoEntity = _enderecoRepository.ListarPorCliente(IdCliente);
            var lstEnderecoViewModel = _mapper.Map<IEnumerable<EnderecoViewModel>>(lstEnderecoEntity);
            return lstEnderecoViewModel;
        }
    }
}
