using Data.App.repository;
using Microsoft.AspNetCore.Mvc;
using MyAdmin.Models;
using System.Diagnostics;
using view.modelApp;

namespace MyAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IBannerRepository bannerRepo;

        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger ,IBannerRepository _bannerRepo, IWebHostEnvironment _iwebhostEnvironmrnt)
        {
            this.bannerRepo = _bannerRepo;
            this.webHostEnvironment = _iwebhostEnvironmrnt;
            this._logger = logger;
        }
     

        public IActionResult Index()
        {
            var data = bannerRepo.GetAllBanners().Select(banner => new BannerView
            {
                Id = banner.Id,
                Title = banner.Title,
                Content = banner.Content,
                BannerCoverImage = banner.CoverImageUrl,
                createdAt=banner.createdAt
            });
            var result = data.Count();   
            ViewBag.NumOfCount=result;
            return View("Index", data);
            
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