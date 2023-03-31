using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces;
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

        public ClienteController
        (
            IClienteApp clienteApp,
            ITelefoneApp telefoneApp,
            IEnderecoApp enderecoApp,
            ISexoApp sexoApp

        )
        {
            _clienteApp = clienteApp;
            _telefoneApp = telefoneApp;
            _enderecoApp = enderecoApp;
            _sexoApp = sexoApp;
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
        [Route("Cadastro")]
        public PartialViewResult Cadastro()
        {
            CadastroViewModel CadastroVM = new CadastroViewModel();

            try
            {
                CadastroVM.Sexos = new SelectList(_sexoApp.Listar(), "Id", "Sexo").ToList();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return PartialView("_Cadastro", CadastroVM);
        }

    }
}
