using Microsoft.AspNetCore.Mvc;

using ProjetoPousada.Aplicacao.Config.Interfaces;
using ProjetoPousada.IU.Web.Areas.Config.ViewModels;
using ProjetoPousada.IU.Web.Controllers;

namespace ProjetoPousada.IU.Web.Areas.Config.Controllers
{
    [Area("Config")]
    [Route("Config/[controller]")]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioApp _usuarioApp;

        public UsuarioController
        (
            IUsuarioApp usuarioApp
        )
        {
            _usuarioApp = usuarioApp;
        }

        [HttpGet]        
        public IActionResult Index()
        {
            IndexViewModel indexVM = new IndexViewModel();

            try
            {
                indexVM.Usuarios = _usuarioApp.Listar();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }
            return View(indexVM);
        }
    }
}
