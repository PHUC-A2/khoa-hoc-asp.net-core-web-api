using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class SMT_CauTrucDe_ThanhPhan_SubRepository
    {
        private readonly ApplicationDbContext _context;

        public SMT_CauTrucDe_ThanhPhan_SubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<SMT_CauTrucDe_ThanhPhan_Sub> Query()
        {
            return _context.Set<SMT_CauTrucDe_ThanhPhan_Sub>().AsQueryable();
        }

        public async Task<SMT_CauTrucDe_ThanhPhan_Sub?> GetById(long id)
        {
            return await _context.Set<SMT_CauTrucDe_ThanhPhan_Sub>()
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task Add(SMT_CauTrucDe_ThanhPhan_Sub entity)
        {
            _context.Set<SMT_CauTrucDe_ThanhPhan_Sub>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(SMT_CauTrucDe_ThanhPhan_Sub entity)
        {
            _context.Set<SMT_CauTrucDe_ThanhPhan_Sub>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}