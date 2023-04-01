using E_commerce.Data.Services;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class Actors2Controller : Controller
    {
        //nasna3 instance ml interface de service Actors
        private readonly IActorsService2 _service;
        // nzid el instance ll constructor
        public Actors2Controller(IActorsService2 context)
        {
            _service = context;
        }
        // Get request with lini /Actors
        public async Task<IActionResult> Index()
        {
            //data variable fih list of actors n3adeha ll view bech najem na9rahom fih
            var data = await _service.GetAll();
            //traja3li view comme resulatat
            return View(data);
        }
        // Get : /Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // ma3neha el url rahou mta3 post
        [HttpPost]
        // 3malna bind data 5ater fl model 3adna id eli heya mahich bech tjina ml formulaire
        public async Task<IActionResult> Create([Bind("FullName,Bio,ProfilePictureURL")] Actor actor)
        {
            //verifier si les donnees sont corrects
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            //nnab3th el data el Add methode fl ActorsServices
            await _service.AddAsync(actor);

            //traja3ni ll mathode Index eli bech thezni el page Index mta3 Actor
            return RedirectToAction(nameof(Index));
        }
        //Get : Actors/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var ActorsDetails = await _service.GetByIdAsync(id);
            if (ActorsDetails == null)
            {
                return View("NotFound");
            }
            return View(ActorsDetails);
        }

        //Get : Actors/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var ActorsDetails = await _service.GetByIdAsync(id);
            if (ActorsDetails == null)
            {
                return View("NotFound");
            }
            return View(ActorsDetails);
        }
        //post: na9ra menha  el data ely jeya 
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            //verifier si les donnees sont corrects
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            //nnab3th el data el Add methode fl ActorsServices
            await _service.UpdateAysnc(id, actor);

            //traja3ni ll mathode Index eli bech thezni el page Index mta3 Actor
            return RedirectToAction(nameof(Index));
        }

        //Get : Actors/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var ActorsDetails = await _service.GetByIdAsync(id);
            if (ActorsDetails == null)
            {
                return View("NotFound");
            }
            return View(ActorsDetails);
        }
        //post: delete 
        [HttpPost]
        public async Task<IActionResult> DeleteConformed(int id)
        {
            var ActorsDetails = await _service.GetByIdAsync(id);
            if (ActorsDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);

            //traja3ni ll mathode Index eli bech thezni el page Index mta3 Actor
            return RedirectToAction(nameof(Index));
        }
    }
}
