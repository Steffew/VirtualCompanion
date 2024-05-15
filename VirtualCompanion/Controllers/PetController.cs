using Microsoft.AspNetCore.Mvc;
using VirtualCompanion.Core.Interfaces;

namespace VirtualCompanion.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public IActionResult Index()
        {
            var pets = _petRepository.GetAllPets();
            return View(pets);
        }
    }
}
