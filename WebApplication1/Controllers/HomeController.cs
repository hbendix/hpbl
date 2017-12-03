using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IImageService imageService;
        private IBlogService blogService;
        public HomeController(IImageService imageService,
            IBlogService blogService)
        {
            this.imageService = imageService;
            this.blogService = blogService;
        }
        public IActionResult Index()
        {
            return View(ViewBag);
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /* FEED ------------------------------------------------------------------- FEED*/
        [Route("/home/feed")]
        public IActionResult Feed()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetFeed()
        {
            return Json(imageService.GetAllImages());
        }
        /* BLOG ------------------------------------------------------------------- BLOG*/
        [Route("/home/blog")]
        public IActionResult Blog()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetBlogFeed()
        {
            return Json(blogService.GetBlogFeed());
        }
        /* ABOUT ------------------------------------------------------------------- ABOUT*/
        [Route("/home/about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
