namespace ProjetoPousada.Dominio.Interfaces
{
    public interface IUnitOfWork<TContext> where TContext : class
    {
        void Commit();
    }
}
