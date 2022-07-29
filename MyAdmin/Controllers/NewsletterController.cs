using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyAdmin.Controllers
{
    public class NewsletterController : Controller
    {
        // GET: NewsletterController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NewsletterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsletterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsletterController/Create
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

        // GET: NewsletterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsletterController/Edit/5
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

        // GET: NewsletterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsletterController/Delete/5
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
