using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyAdmin.Controllers
{
    public class CustomerSupportController : Controller
    {
        // GET: CustomerSupportController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerSupportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerSupportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerSupportController/Create
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

        // GET: CustomerSupportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerSupportController/Edit/5
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

        // GET: CustomerSupportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerSupportController/Delete/5
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
