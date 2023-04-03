using System.Text.RegularExpressions;

namespace ProjetoPousada.Dominio.Helpers
{
    public static class RetiraCaracterHelper
    {
        public static string RetiraCaracteres(string texto)
        {
            var textoLimpo = Regex.Replace(texto, "[^0-9]", string.Empty);
            return textoLimpo;
        }
    }
}
