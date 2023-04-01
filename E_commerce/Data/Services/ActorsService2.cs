using E_commerce.Data.Base;
using E_commerce.Models;

namespace E_commerce.Data.Services
{
    public class ActorsService2 : EntityBaseRepository<Actor>, IActorsService2
    {
        public ActorsService2(AppDbContext context) : base(context) { }
    }
}
