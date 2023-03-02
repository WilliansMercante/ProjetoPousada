namespace ProjetoPousada.Dominio.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity ConsultarPorId(int id);
        void Incluir(List<TEntity> list);
        void Incluir(TEntity obj);
        void Atualizar(List<TEntity> list);
        void Atualizar(TEntity obj);
        IEnumerable<TEntity> Listar();
        void Excluir(int id);
    }
}
