using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ventas.Models;

namespace Ventas.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View(GetImageFiles());
        }
        public IActionResult Hombre()
        {
            return View(GetImageFiles("hombre")); // Filtra por "hombre"
        }

        public IActionResult Mujer()
        {
            return View(GetImageFiles("mujer")); // Filtra por "mujer"
        }

        public IActionResult Boy()
        {
            return View(GetImageFiles("boy")); // Filtra por "niño"
        }
        public IActionResult Privacy()
        {
            return View(); // Devuelve la vista Privacy
        }


        private List<string> GetImageFiles(string? categoryFilter = null)
        {
            string imagesPath = Path.Combine(_hostEnvironment.WebRootPath, "img");

            if (categoryFilter != null)
            {
                imagesPath = Path.Combine(imagesPath, categoryFilter); // Añade la subcarpeta
            }


            if (!Directory.Exists(imagesPath))
            {
                return new List<string>();
            }

            var imageFiles = Directory.GetFiles(imagesPath)
                .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".jpeg") || file.EndsWith(".gif"))
                .Select(Path.GetFileName)
                .ToList();//Importante el to list
            return imageFiles;
        }
    }
}
