using Microsoft.AspNetCore.Mvc.Rendering;

using ProjetoPousada.ViewModel.Cadastro;

namespace ProjetoPousada.IU.Web.Areas.Cadastro.ViewModels.Cliente
{
    public class CadastroViewModel
    {
        public ClienteViewModel Cliente { get; set; }
        public SexoViewModel Sexo { get; set; }
        public List<SelectListItem> Sexos { get; set; } = new List<SelectListItem>();

        public EnderecoViewModel Endereco { get; set; }
        public TelefoneViewModel Telefone { get; set; }
        public TipoEnderecoViewModel TipoEndereco { get; set; }
        public TipoTelefoneViewModel TipoTelefone { get; set; }
        public List<SelectListItem> LstTiposEndereco { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> LstTiposTelefone { get; set; } = new List<SelectListItem>();
    }
}
