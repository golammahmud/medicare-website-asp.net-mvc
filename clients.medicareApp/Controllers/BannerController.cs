using Data.App.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using view.modelApp;

namespace clients.medicareApp.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerController(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        // GET: HomeController

        public IActionResult Index()
        {
            var result = _bannerRepository.GetAllBanners().Select(banner => new BannerView
            {
                Id = banner.Id,
                Title = banner.Title,
                Content = banner.Content,
                createdAt = banner.createdAt,
            });
            return View(result);
        }

        // GET: BannerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BannerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BannerController/Create
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

        // GET: BannerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BannerController/Edit/5
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

        // GET: BannerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BannerController/Delete/5
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
