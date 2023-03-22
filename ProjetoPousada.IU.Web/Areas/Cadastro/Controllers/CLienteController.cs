using Microsoft.AspNetCore.Mvc;

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

		public ClienteController
		(
			IClienteApp clienteApp,
			ITelefoneApp telefoneApp,
			 IEnderecoApp enderecoApp
		)
		{
			_clienteApp = clienteApp;
			_telefoneApp = telefoneApp;
			_enderecoApp = enderecoApp;
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
        [Route("Pesquisar/{nome}/{cpf}/{dtNascimento}/")]
        public JsonResult Pesquisar(string nome, string cpf, DateTime dtNascimento)
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
    }
}
