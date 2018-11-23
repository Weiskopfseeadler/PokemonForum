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

            var images = _context.Images.Where(a => !a.isAvatar).ToList();

            var viewModel = new FanArtViewModel()
            {
                Imagelist = images
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult FanArts(FanArtViewModel viewModel)
        {
            //ViewData["Message"] = "Your application description page.";

            var newImag = new Image();
            newImag.Name = viewModel.name;
            newImag.Path = viewModel.path;
            newImag.isAvatar = false;

            _context.Images.Add(newImag);
            _context.SaveChanges();

            var images = _context.Images.Where(a => !a.isAvatar).ToList();

            viewModel = new FanArtViewModel()
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
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Forum(ForumViewModel viewModel)
        {
            ViewData["Message"] = "Your contact page.";
            Thread newthread = new Thread()
            {
                Title = viewModel.name
            };
            _context.Threads.Add(newthread);
            _context.SaveChanges();

            viewModel = new ForumViewModel()
            {
                threadList = _context.Threads.Where(a => a.ThreadID > 0).ToList()
            };
            return View(viewModel);
        }

        public IActionResult ForumThread(long threadID)
        {
            ViewData["Message"] = "Your contact page.";


            var viewModel = new ForumThreadViewModel();

            viewModel.threadID = threadID;
            try
            {
                viewModel.articlesList = _context.Threads.Include(t => t.Articles).Where(t => t.ThreadID == threadID).FirstOrDefault().Articles.ToList();
            }
            catch (System.Exception)
            {
                List<Article> al = new List<Article>();
                al.Add(new Article
                {
                    Text = "no Article",
                    Thread = _context.Threads.Find(viewModel.threadID)
                });

                viewModel.articlesList = al;
            }


            return View(viewModel);
        }


        [HttpPost]
        public IActionResult ForumThread(ForumThreadViewModel viewModel)
        {
            ViewData["Message"] = "Your contact page.";

            var newArticle = new Article();
            newArticle.Text = viewModel.text;
            newArticle.Thread = _context.Threads.Find(viewModel.threadID);
            newArticle.Time = DateTime.Now;

            _context.Articles.Add(newArticle);
            _context.SaveChanges();

            var viewModel2 = new ForumThreadViewModel();

            viewModel2.threadID = viewModel.threadID;
            try
            {
                viewModel2.articlesList = _context.Threads.Find(viewModel.threadID).Articles.Where(a => a.Thread.ThreadID == viewModel.threadID).ToList();
            }
            catch (System.Exception)
            {
                List<Article> al = new List<Article>();
                al.Add(new Article
                {
                    Text = "no Article",
                    Thread = _context.Threads.Find(viewModel.threadID)
                });

                viewModel2.articlesList = al;
            }

            return View(viewModel2);
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

