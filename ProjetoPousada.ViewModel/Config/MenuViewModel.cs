namespace ProjetoPousada.ViewModel.Config
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public int? IdMenuItemSuperior { get; set; }
        public string NmItem { get; set; }
        public string NmArea { get; set; }
        public string NmController { get; set; }
        public string NmAction { get; set; }
        public string ClassIcon { get; set; }
        public bool FlStatus { get; set; }
        public bool FlRedirecionamentoExterno { get; set; }
        public string LnkRedirecionamento { get; set; }

        public List<MenuViewModel> SubItens { get; set; } = new List<MenuViewModel>();
    }
}
