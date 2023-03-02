using Microsoft.EntityFrameworkCore;

using ProjetoPousada.Dominio.Interfaces;
using ProjetoPousada.Infra.Contexts;

namespace ProjetoPousada.Infra
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.Log();
            _context.SaveChanges();
        }
    }
}
