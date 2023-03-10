using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ProjetoPousada.Aplicacao.ProjetoPousada.Cadastro.Interfaces;
using ProjetoPousada.IU.Web.Controllers;

namespace ProjetoPousada.IU.Web.Areas.Cadastro.Controllers
{

    [Area("Cliente")]
    [Route("Cliente/[controller]")]
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
                indexVM.Cliente = new DadosClienteViewModel
                {
                    ListarSexo = new SelectList(_sexoApp.Listar(), "Id", "Sexo"),
                    Equipes = new SelectList(_equipeApp.ListarPorUnidade(IdUnidadeSelecionada), "Id", "NmEquipe"),
                    Diagnosticos = new SelectList(_diagnosticoApp.Listar(), "Id", "Diagnostico")
                };

                indexVM.Cliente.ClienteUnidade.IdUnidade = IdUnidadeSelecionada;
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message, TipoMensagem.Erro);
            }

            return View(indexVM);
        }

        [Route("ConsultarPorCNS/{cns}")]
        [HttpPost]
        public JsonResult ConsultarPorCNS(string cns)
        {
            try
            {
                var mensagem = string.Empty;
                var oClienteVM = _clienteApp.ConsultarPorCNS(cns);
                var oClienteUnidadeVM = _clienteUnidadeApp.ConsultarPorCnsUnidade(cns, IdUnidadeSelecionada);

                if (oClienteVM == null)
                {
                    mensagem = "Cliente não localizado, por favor preencha o cadastro";
                }
                else
                {
                    mensagem = "Cliente localizado!";
                }

                var dadosCliente = new { cliente = oClienteVM, clienteUnidade = oClienteUnidadeVM };

                return Json(new { FlSucesso = true, mensagem, dadosCliente });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [Route("ConsultarProfissionaisPorEquipe/{idEquipe}")]
        [HttpPost]
        public JsonResult ConsultarProfissionaisPorEquipe(int idEquipe)
        {
            try
            {
                var lstMedicoVM = _profissionalApp.ListarMedicosPorEquipeUnidade(idEquipe, IdUnidadeSelecionada);
                var lstEnfermeiroVM = _profissionalApp.ListarEnfermeirosPorEquipeUnidade(idEquipe, IdUnidadeSelecionada);

                return Json(new { FlSucesso = true, Medicos = lstMedicoVM, Enfermeiros = lstEnfermeiroVM });
            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }

        [Route("Cadastro")]
        [HttpPost]
        public JsonResult Cadastro(DadosClienteViewModel dadosClienteVM)
        {
            int idCliente;
            int idClienteUnidade;

            try
            {
                dadosClienteVM.ClienteUnidade.CnsCliente = dadosClienteVM.Cliente.Cns;
                dadosClienteVM.ClienteUnidade.IdUnidade = IdUnidadeSelecionada;

                if (dadosClienteVM.Cliente.Id.Equals(0))
                {
                    idCliente = _clienteApp.Incluir(dadosClienteVM.Cliente);
                }
                else
                {
                    idCliente = dadosClienteVM.Cliente.Id;
                    _clienteApp.Atualizar(dadosClienteVM.Cliente);
                }

                if (dadosClienteVM.ClienteUnidade.Id.Equals(0))
                {
                    idClienteUnidade = _clienteUnidadeApp.Incluir(dadosClienteVM.ClienteUnidade);
                }
                else
                {
                    idClienteUnidade = dadosClienteVM.ClienteUnidade.Id;
                    _clienteUnidadeApp.Atualizar(dadosClienteVM.ClienteUnidade);
                }

                return Json(new { FlSucesso = true, Mensagem = "Dados inseridos com sucesso!", IdCliente = idCliente, IdClienteUnidade = idClienteUnidade });

            }
            catch (Exception ex)
            {
                return Json(new { FlSucesso = false, Mensagem = ex.Message });
            }
        }
    }









    public class CLienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
