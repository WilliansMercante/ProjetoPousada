using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces;
using ProjetoPousada.Dominio.Helpers;
using ProjetoPousada.IU.Web.Areas.Cadastro.ViewModels.Cliente;
using ProjetoPousada.IU.Web.Controllers;
using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.IU.Web.Areas.Cadastro.Controllers
{
    [Area("Cadastro")]
    [Route("Cadastro/[controller]")]
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
        [Route("Index")]
        public IActionResult Index()
        {
            IndexViewModel indexVM = new IndexViewModel();

            try
            {
                indexVM.Clientes = _clienteApp.ListarUltimos20Ativos();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View(indexVM);
        }

        [HttpPost]
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

        //[HttpPost]
        //[Route("Cadastro")]
        //public IActionResult Cadastro(CadastroViewModel cadastroVM)
        //{

        //    try
        //    {
        //        cadastroVM.Cliente.CPF = RetiraCaracterHelper.RetiraCaracteres(cadastroVM.Cliente.CPF);
        //        _clienteApp.Incluir(cadastroVM.Cliente);
        //        ExibirMensagem("Cliente Cadastrado!", TipoMensagem.Sucesso);
        //    }
        //    catch (Exception ex)
        //    {
        //        ExibirMensagem(ex.Message, TipoMensagem.Erro);
        //    }

        //    return RedirectToAction("Index");
        //}




        [Route("Cadastro")]
        [HttpPost]
        public JsonResult Cadastro(ClienteViewModel clienteVM)
        {
            try
            {
                clienteVM.CPF = RetiraCaracterHelper.RetiraCaracteres(clienteVM.CPF);
                ExcecaoDominioHelper.Validar(!VerificaCPFHelper.ValidaCPF(clienteVM.CPF), "CPF Inválido!");
                _clienteApp.Incluir(clienteVM);

                return Json(new { FlSucesso = true, Mensagem = "Dados inseridos com sucesso, por favor continue o cadastro!" });

            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }
    }
}
