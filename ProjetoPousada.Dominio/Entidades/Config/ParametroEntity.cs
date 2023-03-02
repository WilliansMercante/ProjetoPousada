using System.Text.Json;

namespace ProjetoPousada.Dominio.Entidades.Config
{
    public class ParametroEntity : Entidade
    {
        public string DsParametro { get; set; }
        public string Observacao { get; set; }
        public string Valor { get; set; }

        public bool UsuarioPermitido(int idUsuario)
        {
            bool permitido = false;

            if (!string.IsNullOrEmpty(Valor))
            {
                var lstUsuarios = JsonSerializer.Deserialize<List<int>>(Valor);
                permitido = lstUsuarios.Contains(idUsuario);
            }

            return permitido;
        }
    }
}
