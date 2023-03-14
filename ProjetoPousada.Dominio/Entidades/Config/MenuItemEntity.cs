namespace ProjetoPousada.Dominio.Entidades.Config
{
	public class MenuItemEntity : Entidade
	{
		public int? IdMenuItemSuperior { get; set; }
		public string NmItem { get; set; }
		public string NmController { get; set; }
		public string NmAction { get; set; }
		public string ClassIcon { get; set; }
		public bool FlStatus { get; set; }
		public string NmArea { get; set; }
		public string LnkRedirecionamento { get; set; }
		public bool FlRedirecionamentoExterno { get; set; }
		public bool FlAbrirModal { get; set; }
		public string IdControleModal { get; set; }
		public bool FlHeader { get; set; }

		public virtual ICollection<MenuItemEntity> SubItens { get; set; }
	}
}
