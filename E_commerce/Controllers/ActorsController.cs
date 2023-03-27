using E_commerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Controllers
{
    public class ActorsController : Controller
    {
        //n3ayet ll appdbcontext bech najem na9ra ou nsajel data 
        private readonly AppDbContext _context;
        public ActorsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //data variable fih list of actors n3adeha ll view bech najem na9rahom fih
            var data =await _context.Actors.ToListAsync();
            //traja3li view comme resulatat
            return View(data);
        }
    }
}
