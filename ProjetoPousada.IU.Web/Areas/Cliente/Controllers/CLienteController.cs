using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces;
using ProjetoPousada.Dominio.Helpers;
using ProjetoPousada.IU.Web.Areas.Cadastro.ViewModels.Cliente;
using ProjetoPousada.IU.Web.Controllers;
using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.IU.Web.Areas.Cadastro.Controllers
{
    [Area("Cliente")]
    [Route("Cliente/[controller]")]
    public class ClienteController : BaseController
    {
        private readonly IClienteApp _clienteApp;
        private readonly ITelefoneApp _telefoneApp;
        private readonly IEnderecoApp _enderecoApp;
        private readonly ISexoApp _sexoApp;
        private readonly ITipoTelefoneApp _tipoTelefoneApp;
        private readonly ITipoEnderecoApp _tipoEnderecoApp;

        public ClienteController
        (
            IClienteApp clienteApp,
            ITelefoneApp telefoneApp,
            IEnderecoApp enderecoApp,
            ISexoApp sexoApp,
            ITipoTelefoneApp tipoTelefoneApp,
            ITipoEnderecoApp tipoEnderecoApp

        )
        {
            _clienteApp = clienteApp;
            _telefoneApp = telefoneApp;
            _enderecoApp = enderecoApp;
            _sexoApp = sexoApp;
            _tipoTelefoneApp = tipoTelefoneApp;
            _tipoEnderecoApp = tipoEnderecoApp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IndexViewModel indexVM = new IndexViewModel();

            try
            {
                indexVM.Clientes = _clienteApp.ListarUltimos20();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View(indexVM);
        }

        [HttpGet]
        [Route("Pesquisar")]
        public JsonResult Pesquisar(string nome, string cpf, DateTime? dtNascimento)
        {
            IEnumerable<ClienteViewModel> lstClientesVM = new List<ClienteViewModel>();

            try
            {
                lstClientesVM = _clienteApp.Consultar(nome, cpf, dtNascimento);
            }
            catch (Exception ex)
            {
                return Json(new { flSucesso = false, mensagem = ex.Message });
            }

            return Json(new { flSucesso = true, lstClientes = lstClientesVM });
        }


        [HttpGet]
        [Route("PesquisarCPF/{cpf}")]
        public JsonResult PesquisarCPF(string cpf)
        {
            try
            {
                ClienteViewModel oClienteVM = _clienteApp.ConsultarPorCPF(cpf);
                return Json(new { flSucesso = true, oCliente = oClienteVM });
            }
            catch (Exception ex)
            {
                return Json(new { flSucesso = false, mensagem = ex.Message });
            }
        }

        [HttpGet]
        [Route("Cadastro")]
        public IActionResult Cadastro()
        {
            CadastroViewModel cadastroVM = new CadastroViewModel();

            try
            {
                cadastroVM.Sexos = new SelectList(_sexoApp.Listar(), "Id", "Sexo").ToList();
                cadastroVM.LstTiposEndereco = new SelectList(_tipoEnderecoApp.Listar(), "Id", "Tipo").ToList();
                cadastroVM.LstTiposTelefone = new SelectList(_tipoTelefoneApp.Listar(), "Id", "Tipo").ToList();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View("Cadastro", cadastroVM);
        }

        [Route("Cadastro")]
        [HttpPost]
        public JsonResult Cadastro(ClienteViewModel clienteVM)
        {

            try
            {

                if (clienteVM.Id > 0)
                {
                    _clienteApp.Atualizar(clienteVM);
                    return Json(new { FlSucesso = true, Mensagem = "Dados alterados com sucesso!", IdCliente = clienteVM.Id });
                }

                else
                {
                    clienteVM.Id = _clienteApp.Incluir(clienteVM);
                    return Json(new { FlSucesso = true, Mensagem = "Dados inseridos com sucesso, por favor continue o cadastro!", IdCliente = clienteVM.Id });
                }

            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [Route("Editar/{id}")]
        [HttpGet]
        public IActionResult Editar(int id)
        {
            CadastroViewModel cadastroVM = new CadastroViewModel();

            try
            {
                cadastroVM.Cliente = _clienteApp.ConsultarPorId(id);
                cadastroVM.Sexos = new SelectList(_sexoApp.Listar(), "Id", "Sexo").ToList();
                cadastroVM.LstTiposEndereco = new SelectList(_tipoEnderecoApp.Listar(), "Id", "Tipo").ToList();
                cadastroVM.LstTiposTelefone = new SelectList(_tipoTelefoneApp.Listar(), "Id", "Tipo").ToList();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View("Cadastro", cadastroVM);
        }

    }
}
