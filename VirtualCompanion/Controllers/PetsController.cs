using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VirtualCompanion.Core.Entities;
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
            var petsData = _petRepository.GetAll(ownerId: 1); // OwnerId is hard - coded for now, login system not implemented(yet).
            var petViewModels = petsData.Select(pet => new PetViewModel
            {
                Id = pet.Id,
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

        [HttpGet]
        [Route("Pets/{id}")]
        public IActionResult Pet(int id)
        {
            var pet = _petRepository.Get(id);
            if (pet == null)
            {
                return NotFound();
            }

            var petViewModel = new PetViewModel
            {
                Id = pet.Id,
                OwnerId = pet.OwnerId,
                Name = pet.Name,
                Health = pet.Health,
                Experience = pet.Experience,
                Energy = pet.Energy,
                Mood = pet.Mood,
                Hunger = pet.Hunger,
                Hygiene = pet.Hygiene
            };

            return View(petViewModel);
        }

        [HttpGet]
        [Route("Pets/Sell/{id}")]
        public IActionResult Sell(int id)
        {
            var pet = _petRepository.Get(id);
            if (pet == null)
            {
                return NotFound();
            }

            var petViewModel = new PetViewModel
            {
                Id = pet.Id,
                OwnerId = pet.OwnerId,
                Name = pet.Name,
                Health = pet.Health,
                Experience = pet.Experience,
                Energy = pet.Energy,
                Mood = pet.Mood,
                Hunger = pet.Hunger,
                Hygiene = pet.Hygiene
            };

            return View("Sell", petViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
