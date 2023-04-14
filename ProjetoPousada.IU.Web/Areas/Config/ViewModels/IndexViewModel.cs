using ProjetoPousada.ViewModel.Config;

namespace ProjetoPousada.IU.Web.Areas.Config.ViewModels
{
    public class IndexViewModel
    {
        public UsuarioViewModel Usuario { get; set; }
        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
    }
}
