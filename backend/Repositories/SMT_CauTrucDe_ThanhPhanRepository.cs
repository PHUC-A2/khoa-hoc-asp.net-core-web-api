using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class SMT_CauTrucDe_ThanhPhanRepository
    {
        private readonly ApplicationDbContext _context;

        public SMT_CauTrucDe_ThanhPhanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<SMT_CauTrucDe_ThanhPhan> Query()
        {
            return _context.Set<SMT_CauTrucDe_ThanhPhan>().AsQueryable();
        }

        public async Task<SMT_CauTrucDe_ThanhPhan?> GetById(long id)
        {
            return await _context.Set<SMT_CauTrucDe_ThanhPhan>()
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task Add(SMT_CauTrucDe_ThanhPhan entity)
        {
            _context.Set<SMT_CauTrucDe_ThanhPhan>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SMT_CauTrucDe_ThanhPhan entity)
        {
            _context.Set<SMT_CauTrucDe_ThanhPhan>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}