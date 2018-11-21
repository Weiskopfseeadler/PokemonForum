using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ForumPokemon.Models;
using Microsoft.AspNetCore.Mvc;
using PokemonForum.Data;
using PokemonForum.Models;


namespace PokemonForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context){
            _context = context;
        }

        public static List<Image> Imagelist{get;set;}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FanArts()
        {
            ViewData["Message"] = "Your application description page.";
            var img = new Image();
            img.Path = @"wwwroot\images\Poke\bg-08.jpg" ;
            var viewModel = new FanArtViewModel(){ 
                Imagelist = new List<Image>(){img}
            };
            return View(viewModel);
        }

        public IActionResult Forum()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

