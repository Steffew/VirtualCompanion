using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VirtualCompanion.Core.Exceptions;
using VirtualCompanion.Core.Interfaces.Service;
using VirtualCompanion.Models;

namespace VirtualCompanion.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetService _petService;

        public PetsController(IPetService PetService)
        {
            _petService = PetService;
        }

        public IActionResult Index()
        {
            try
            {
                var petsData = _petService.GetAllPets(ownerId: 1); // OwnerId is hard - coded for now, login system not implemented(yet).
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
            catch (PetException ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("Pets/{id}")]
        public IActionResult Pet(int id)
        {
            try
            {
                var pet = _petService.GetPet(id);
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
            catch (PetException ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("Pets/Sell/{id}")]
        public IActionResult Sell(int id)
        {
            try
            {
                var pet = _petService.GetPet(id);
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
            catch (PetException ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("Pets/ConfirmSell/{id}")]
        public IActionResult ConfirmSell(int id)
        {

            try
            {
                bool result = _petService.DeletePet(id);
                if (result)
                {
                    TempData["Message"] = "Pet successfully sold.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Error selling pet.";
                    return RedirectToAction("Pet", new { id = id });
                }
            }
            catch (PetException ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
