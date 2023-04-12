using Microsoft.AspNetCore.Mvc;

using ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces;
using ProjetoPousada.Dominio.Helpers;
using ProjetoPousada.IU.Web.Controllers;
using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.IU.Web.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    [Route("Cliente/[controller]")]
    public class TelefoneController : BaseController
    {

        private readonly IClienteApp _clienteApp;
        private readonly ITelefoneApp _telefoneApp;
        private readonly IEnderecoApp _enderecoApp;
        private readonly ISexoApp _sexoApp;
        private readonly ITipoTelefoneApp _tipoTelefoneApp;
        private readonly ITipoEnderecoApp _tipoEnderecoApp;

        public TelefoneController
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
        public JsonResult Cadastro(TelefoneViewModel telefoneVM)
        {
            try
            {

                ExcecaoDominioHelper.Validar(telefoneVM.Numero == null || telefoneVM.DDD == null || telefoneVM.IdTipoTelefone == 0, "Telefone Inválido!");
                telefoneVM.Numero = RetiraCaracterHelper.RetiraCaracteres(telefoneVM.Numero);
                _telefoneApp.Incluir(telefoneVM);

                return Json(new { FlSucesso = true, Mensagem = "Telefone inserido com sucesso" });

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

                ExcecaoDominioHelper.Validar(idCLiente == 0, "Sem parâmetro");
                var lstEnderecoVM = _telefoneApp.ListarPorCliente(idCLiente);

                return Json(new { FlSucesso = true, LstEndereco = lstEnderecoVM });

            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }
    }

}
