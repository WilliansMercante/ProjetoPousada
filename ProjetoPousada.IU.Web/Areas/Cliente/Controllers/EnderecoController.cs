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
    public class EnderecoController : BaseController
    {

        private readonly IClienteApp _clienteApp;
        private readonly ITelefoneApp _telefoneApp;
        private readonly IEnderecoApp _enderecoApp;
        private readonly ISexoApp _sexoApp;
        private readonly ITipoTelefoneApp _tipoTelefoneApp;
        private readonly ITipoEnderecoApp _tipoEnderecoApp;

        public EnderecoController
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



        [Route("Cadastro")]
        [HttpPost]
        public JsonResult Cadastro(EnderecoViewModel enderecoVM)
        {
            try
            {

                ExcecaoDominioHelper.Validar(enderecoVM.Rua == null || enderecoVM.Bairro == null || enderecoVM.Cep == null || enderecoVM.UF == null, "Endereco Inválido!");
                enderecoVM.Cep = RetiraCaracterHelper.RetiraCaracteres(enderecoVM.Cep);
                _enderecoApp.Incluir(enderecoVM);

                return Json(new { FlSucesso = true, Mensagem = "Endereço inserido com sucesso" });

            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }


        
        [HttpGet]
        [Route("ListarPorCliente/{idCliente}")]
        public JsonResult ListarPorCliente(int idCLiente)
        {
            try
            {

                ExcecaoDominioHelper.Validar(idCLiente == null, "Sem parâmetro");
                var lstEnderecoVM = _enderecoApp.ListarPorCliente(idCLiente);

                return Json(new { FlSucesso = true, LstEndereco = lstEnderecoVM });

            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }
    }
}
