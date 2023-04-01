using E_commerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;
        public MoviesController(AppDbContext context)
        {
            _context = context;
            
        }
        public async Task<IActionResult> Index()
        {
            // bech na9ra el movies lkol cinema 5ateer howa marbout 1 movie to many cinema
            var allMovies= await _context.Movies.Include(n=> n.Cinema).ToListAsync();
            return View(allMovies);
        }
    }
}
