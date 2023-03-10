namespace ProjetoPousada.Dominio.Helpers
{
    public sealed class ExcecaoDominioHelper : Exception
    {
        public ExcecaoDominioHelper(string mensagem) : base(mensagem) { }

        public static void Validar(bool regraInvalida, string mensagem)
        {
            if (regraInvalida)
                throw new ExcecaoDominioHelper(mensagem);
        }
    }
}
