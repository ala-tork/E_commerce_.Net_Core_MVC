using E_commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace E_commerce.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        //na3mel instance ml appDbContext bech najem na7ki m3a db 
        protected AppDbContext _context;
        public EntityBaseRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
           
        

        public async Task DeleteAsync(int id)
        {
            var entity= await _context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()=>await _context.Set<T>().ToListAsync();

        

        public async Task<T> GetByIdAsync(int id)=> 
            await _context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
        

        public async Task UpdateAysnc(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
