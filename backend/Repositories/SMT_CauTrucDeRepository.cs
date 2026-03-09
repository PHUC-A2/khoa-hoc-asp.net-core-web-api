using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class SMT_CauTrucDeRepository
    {
        private readonly ApplicationDbContext _context;

        public SMT_CauTrucDeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<SMT_CauTrucDe> Query()
        {
            return _context.SMT_CauTrucDes.AsQueryable();
        }

        public async Task<SMT_CauTrucDe?> GetById(long id)
        {
            return await _context.SMT_CauTrucDes
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task Add(SMT_CauTrucDe entity)
        {
            _context.SMT_CauTrucDes.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SMT_CauTrucDe entity)
        {
            _context.SMT_CauTrucDes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}