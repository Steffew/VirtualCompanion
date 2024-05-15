using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VirtualCompanion.Core.Interfaces;
using VirtualCompanion.Models;

namespace VirtualCompanion.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPetRepository _petRepository;

        public HomeController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public IActionResult Index()
        {
            var pets = _petRepository.GetAllPets();
            return View(pets);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
