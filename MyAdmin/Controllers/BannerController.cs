using Data.App.Models;
using Data.App.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using view.modelApp;

namespace MyAdmin.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBannerRepository bannerRepo;

        private readonly IWebHostEnvironment webHostEnvironment;

        public BannerController( IBannerRepository _bannerRepo, IWebHostEnvironment _iwebhostEnvironmrnt)
        {
            this.bannerRepo = _bannerRepo;
            this.webHostEnvironment = _iwebhostEnvironmrnt;          
        }
        // GET: AdminController

        [HttpGet]
        public ActionResult Index()
        {
           
            var result = bannerRepo.GetAllBanners().Select(banner => new BannerView
            {
                Id = banner.Id,
                Title = banner.Title,
                Content = banner.Content,
                BannerCoverImage=banner.CoverImageUrl,
                createdAt = banner.createdAt       });
            return View(result);
           
        }

        // GET: AdminController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
               
               
                if (id != null)
                {
                    BannerView bannerView = new BannerView();
                    Banner result = await bannerRepo.GetBanner(id);
                    if (result == null)
                    {
                        return NotFound($"{id} not Found");
                    }
                    MappedModel(result, bannerView);                 
                    //{
                    //    bannerView.Id = (int)result.Id;
                    //    bannerView.Title = result.Title;
                    //    bannerView.Content = result.Content;
                    //    bannerView.BannerCoverImage = result.CoverImageUrl;
                    //    bannerView.createdAt = result.createdAt;

                    //}

                    return View(bannerView);
                }

                return NotFound($"{id} not found");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: AdminController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BannerView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string uniqueFileName = UploadedFile(model);
                    Banner banner = new Banner
                    {
                        Id = model.Id,
                        Title = model.Title,
                        Content = model.Content,
                        CoverImageUrl = uniqueFileName,
                        createdAt = model.createdAt,

                    };
                    await bannerRepo.AddBanner(banner);
                    return RedirectToAction(nameof(Index));
                }
               

            }
            catch
            {
                return View();
            }
            return View(model);
        }

        // GET: AdminController/Edit/5
        [HttpGet]
        public async Task<IActionResult>  Edit(int id)
        {
            if (id == 0)
                return NotFound($"{id } data not nound for edit");           
            BannerView bannerView = new BannerView();
            Banner result = await bannerRepo.GetBanner(id);
            if (result == null)
            {
                return NotFound();
            }
            {
                bannerView.Title = result.Title;    
                bannerView.Content = result.Content;
                bannerView.BannerCoverImage = result.CoverImageUrl;
                bannerView.createdAt = result.createdAt;
            }
       
            return View(bannerView);              
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BannerView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dataBanner = await bannerRepo.GetBanner(model.Id);
                    if (dataBanner != null)
                    {
                        
                        dataBanner.Title = model.Title;
                        dataBanner.Content = model.Content;
                        //dataBanner.CoverImageUrl = model.BannerCoverImage;
                        dataBanner.createdAt = model.createdAt;
                            
                        

                        if (model.CoverPhoto != null)
                        {
                            if (model.BannerCoverImage != null)
                            {
                                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads/Banners");
                                string filePath = Path.Combine(uploadsFolder,model.BannerCoverImage );                              
                                System.IO.File.Delete(filePath);                               
                            }
                            dataBanner.CoverImageUrl = UploadedFile(model);
                        }
                       
                        await bannerRepo.UpdateBanner(dataBanner);
                        return RedirectToAction(nameof(Index));
                    }
                    
                }
                return View();

            }
            catch
            {
                return View();
            }
           
        }

        // GET: AdminController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)           
                return NotFound();
            BannerView bannerView = new BannerView();
            Banner result = await bannerRepo.GetBanner(id);

            MappedModel(result, bannerView);
            return View(bannerView);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id ,BannerView model)
        {
            try
            {
                var banner = await bannerRepo.GetBanner(id);
 
               
                var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads\\Banners", banner.CoverImageUrl);

                if (System.IO.File.Exists(CurrentImage))
                {
                    System.IO.File.Delete(CurrentImage);
                }
                bannerRepo.DeleteBanner(banner);
                return RedirectToAction(nameof(Index));
               
               
                
            }
            catch
            {
                return View();
            }
           
        }

        private string UploadedFile(BannerView model)
        {
            string uniquFileName = "";
            if(model.CoverPhoto != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads/Banners");
                uniquFileName = Guid.NewGuid().ToString() + "-" + model.CoverPhoto.FileName;
                string  filePath = Path.Combine(uploadsFolder, uniquFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create)) 
                {
                    model.CoverPhoto.CopyTo(fileStream);
                }
            }
            return uniquFileName;
        }

        
        private  void MappedModel(Banner datamodel, BannerView viewmodel)
        {
            
                {
                viewmodel.Id = (int)datamodel.Id;
                viewmodel.Title = datamodel.Title;
                viewmodel.Content = datamodel.Content;
                viewmodel.BannerCoverImage = datamodel.CoverImageUrl;
                viewmodel.createdAt = datamodel.createdAt;

                }

                
           
         
        }
    }
}
