using E_commerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;
        public ProducersController(AppDbContext context)
        {
            _context = context;
        }
        //get tadata with async await 
        public async  Task<IActionResult> Index()
        {
            var allProducers= await  _context.Producers.ToListAsync();
            return View(allProducers);
        }
    }
}
