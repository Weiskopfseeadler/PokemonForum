using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ForumPokemon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonForum.Data;
using PokemonForum.Models;


namespace PokemonForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FanArts()
        {
            //ViewData["Message"] = "Your application description page.";

            var images = _context.Images.Where(a => a.isAvatar == false).ToList();

            var viewModel = new FanArtViewModel()
            {
                Imagelist = images
            };

            return View(viewModel);
        }
        public IActionResult Forum()
        {
            ViewData["Message"] = "Your contact page.";

            var viewModel = new ForumViewModel()
            {
                threadList = _context.Threads.Where(a => a.ThreadID > 0).ToList()
            };
            return View();
        }

        public IActionResult ForumThread(long ID)
        {
            ViewData["Message"] = "Your contact page.";
          
            var viewModel = new ForumThreadViewModel()
            {
                thredID = Convert.ToString(ID),
                articlesList = _context.Threads.Find(ID).Articles.ToList()

            };
            return View();
        }

        [HttpPost]
        public IActionResult ForumThread(ForumThreadViewModel viewModel)
        {
            ViewData["Message"] = "Your contact page.";
            
            var newArticle = new Article(); 
            newArticle.Text = viewModel.text;
            newArticle.Thread = _context.Threads.Find(viewModel.thredID);
            newArticle.Time = DateTime.Now;
                        
            _context.Articles.Add(newArticle);
            _context.SaveChanges();

            // var viewModel = new ForumThreadViewModel()
            // {
            //     thread = _context.Threads.Find(ID)
            // };


            return View();
        }


        /*[HttpPost]
        public IActionResult Forum(long id, Article article)
        {
            var existingArea = _context.Threads.Find(id);
            existingArea.Title = area.Name;
            existingArea.AssigneesNeeded = area.AssigneesNeeded;
            _context.Areas.Update(existingArea);
            _context.SaveChanges();
        }*/


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

