using E_commerce.Models;

namespace E_commerce.Data.Base
{
public interface IEntityBaseRepository<T> where T : class,IEntityBase, new()
{
    //return all the actors
    Task<IEnumerable<T>> GetAll();
    //return single actor
    Task<T> GetByIdAsync(int id);
    //add Actor to data base 
    Task AddAsync(T entity);
    //Update Actor
    Task UpdateAysnc(int id, T entity);
    //delete actor 
    Task DeleteAsync(int id);
}
}
