using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VirtualCompanion.Core.Interfaces;
using VirtualCompanion.Models;

namespace VirtualCompanion.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetRepository _petRepository;

        public PetsController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public IActionResult Index()
        {
            var petsData = _petRepository.GetAll(ownerId: 1); // OwnerId is hard-coded for now, login system not implemented (yet).
            var petViewModels = petsData.Select(pet => new PetViewModel
            {
                OwnerId = pet.OwnerId,
                Name = pet.Name,
                Health = pet.Health,
                Experience = pet.Experience,
                Energy = pet.Energy,
                Mood = pet.Mood,
                Hunger = pet.Hunger,
                Hygiene = pet.Hygiene
            }).ToList();

            var model = new PetListViewModel
            {
                Pets = petViewModels
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
