using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using ProjetoPousada.Aplicacao.Config.Interfaces;
using ProjetoPousada.IU.Web.ViewModels;

using System.Security.Claims;

namespace ProjetoPousada.IU.Web.Controllers
{
    public class AutenticarController : BaseController
    {
        private readonly IUsuarioApp _usuarioApp;
        private readonly IMenuApp _menuApp;

        public AutenticarController(
            IUsuarioApp usuarioApp,
            IMenuApp menuApp
        )
        {
            _usuarioApp = usuarioApp;
            _menuApp = menuApp;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel login)
        {
            try
            {
                var oUsuarioVM = _usuarioApp.Autenticar(login.Cpf, login.Senha);

                var lstItensMenuPrincipalVM = _menuApp.ListarPorGrupo(oUsuarioVM.Grupo.Id);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, oUsuarioVM.Cpf),
                    new Claim(ClaimTypes.Email, oUsuarioVM.EmailPrincipal ?? string.Empty),
                    new Claim("Usuario", JsonConvert.SerializeObject(oUsuarioVM)),
                    new Claim("ItensMenuPrincipal", JsonConvert.SerializeObject(lstItensMenuPrincipalVM))
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = login.FlRelembrar,
                    IssuedUtc = DateTime.Now,
                    ExpiresUtc = DateTime.Now.AddHours(24),
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);


                if (oUsuarioVM.FlPrimeiroAcesso)
                    return RedirectToAction("Index", "PrimeiroAcesso", new { area = "Login" });
                else
                {
                    return RedirectToAction("Index", "Home", new { area = string.Empty });
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
                return View(login);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Autenticar", new { area = "Login" });
        }
    }
}
