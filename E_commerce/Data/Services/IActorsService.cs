using E_commerce.Models;

namespace E_commerce.Data.Services
{
    public interface IActorsService
    {
        //return all the actors
        Task<IEnumerable<Actor>> GetAll();
        //return single actor
        Task<Actor> GetByIdAsync(int id);
        //add Actor to data base 
        Task AddAsync(Actor actor);
        //Update Actor
        Task<Actor> UpdateAysnc(int id , Actor newactor);
        //delete actor 
        Task<Actor> DeleteAsync(int id);
    }
}
