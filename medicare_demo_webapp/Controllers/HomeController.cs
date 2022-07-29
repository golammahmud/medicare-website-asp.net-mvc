using client.medicareApp.Services;
using Data.App.Models;
using Data.App.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using view.modelApp;

namespace client.medicareApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBannerRepository _bannerrepository;

        public HomeController(IBannerRepository bannerrepository)
        {
            this._bannerrepository = bannerrepository;
        }
        // GET: HomeController
        [HttpGet()]
        public ActionResult Index()
        {
            IEnumerable<BannerView> bannerlist = _bannerrepository.GetAllBanners().Select(banner => new BannerView
            {
                Id = banner.Id,
                Title = banner.Title,
                Content = banner.Content,
                DateTime=banner.DateTime,
            });
            return View("Index", bannerlist);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
