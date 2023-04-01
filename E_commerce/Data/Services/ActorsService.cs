using E_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Data.Services
{
    public class ActorsService : IActorsService 
    {
        // instance de AppDBContext
        protected readonly AppDbContext _context;
        // n7ot el instance fl construteur
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }
        public async  Task AddAsync (Actor actor)
        {

            await _context.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<Actor> DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
            return result;

        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var res =await _context.Actors.ToListAsync();
            return res;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(a=>a.Id == id);
            return result;
        }

        public async Task<Actor> UpdateAysnc(int id, Actor newactor)
        {
            _context.Update(newactor);
            await _context.SaveChangesAsync();
            return newactor;
        }
    }
}
