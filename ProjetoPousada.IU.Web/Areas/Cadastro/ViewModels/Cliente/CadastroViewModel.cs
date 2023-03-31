using Microsoft.AspNetCore.Mvc.Rendering;

using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.IU.Web.Areas.Cadastro.ViewModels.Cliente
{
    public class CadastroViewModel
    {
        public ClienteViewModel Cliente { get; set; }
        public SexoViewModel Sexo { get; set; }
        public List<SelectListItem> Sexos { get; set; } = new List<SelectListItem>();
    }
}
