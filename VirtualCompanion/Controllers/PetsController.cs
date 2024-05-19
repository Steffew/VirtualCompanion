using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VirtualCompanion.Core.Interfaces;
using VirtualCompanion.Core.Services;
using VirtualCompanion.Models;

namespace VirtualCompanion.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        public IActionResult Index()
        {
            var petViewModels = _petService.GetAllPets(1); // OwnerId is still hardcoded for demonstration.
            return View(petViewModels);
        }

        [HttpGet]
        [Route("Pets/{id}")]
        public IActionResult Pet(int id)
        {
            var petViewModel = _petService.GetAllPets(id);
            if (petViewModel == null)
            {
                return NotFound();
            }
            return View(petViewModel);
        }

        [HttpGet]
        [Route("Pets/Sell/{id}")]
        public IActionResult Sell(int id)
        {
            var petViewModel = _petService.GetPet(id);
            if (petViewModel == null)
            {
                return NotFound();
            }
            return View("Sell", petViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}