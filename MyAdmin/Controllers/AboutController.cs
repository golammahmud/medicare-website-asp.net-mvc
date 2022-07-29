using Data.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using view.modelApp.ViewModel;
using static Data.App.repository.AboutRepository;

namespace MyAdmin.Controllers
{
    public class AboutController : Controller
    {

        private readonly IAboutRepository aboutRepository;
        private readonly IWebHostEnvironment webHostEnvironment;



        public AboutController(IAboutRepository _aboutRepository , IWebHostEnvironment _webHostEnvironment)
        {
            this.aboutRepository = _aboutRepository;
            this.webHostEnvironment = _webHostEnvironment;
        }
        // GET: AboutController
        [HttpGet]
        public  ActionResult Index()
        {
            IQueryable<AboutView> data = aboutRepository.GetAllAbouts().Select(x => new AboutView
            {
                Id = x.Id,
                Content = x.Content,
                AboutViewImage = x.AboutDataImage,
                createdAt=(DateTime)x.createdAt
            });
            return View(data);
        }

        // GET: AboutController/Details/5
        [HttpGet]
        public async Task<IActionResult>  Details(int id)
        {
            if (id == 0)
                return NotFound();
            try
            {
                AboutView viewdata = new AboutView();
                About about =await aboutRepository.GetById(id);
                if (about == null)
                    return NotFound(id);
                MappedGetModel(viewdata, about);

                return View(viewdata);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: AboutController/Create
        [HttpGet]
        public ActionResult Create(int? id)
        {
            return View();
        }

        // POST: AboutController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Create(AboutView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        string ImageFileName = UploadedFile(model);
                        About about = new About
                        {
                            Id=model.Id,
                            Content=model.Content,
                            AboutDataImage= ImageFileName,
                            createdAt=model.createdAt
                        };
                       
                        await aboutRepository.InsertAbout(about);
                        return RedirectToAction(nameof(Index));
                    }catch 
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, "invalid post request");
                    }
                }              
            }
            catch
            {
                return BadRequest("invalid data");
            }
            return View(model);
        }

        // GET: AboutController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if(id == 0)
                return BadRequest();
            AboutView Viewdata = new AboutView();
            About data =await aboutRepository.GetById(id);
            if (data == null)
            {
                return BadRequest(id + "not found ");
            }                         
            MappedGetModel(Viewdata,data );

            return View(Viewdata);
        }

        // POST: AboutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AboutView model)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var data =await aboutRepository.GetById(id);
                    if (data == null)
                        return BadRequest(id + "invalid edit");
                    {
                        data.Content = model.Content;
                        data.createdAt = model.createdAt;
                    }
                    if(model.ImgFile != null || model.ImgFile.Length<0)
                    {
                        if (model.AboutViewImage != null)
                        {
                            string iUploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads/About");
                            string filepath = Path.Combine(iUploadsFolder, model.AboutViewImage);
                            System.IO.File.Delete(filepath);
                        }
                        data.AboutDataImage=UploadedFile(model);
                    }

                     await  aboutRepository.UpdateAbout(data);
                    return RedirectToAction(nameof(Index));
                }
                return View();

            }
            catch
            {
                return View();
            }
           
        }

        // GET: AboutController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest($"{id} not found");
            AboutView viewmodel=new AboutView();
            var data=await aboutRepository.GetById(id);
            if(data == null)
                return NotFound();
            MappedGetModel(viewmodel, data);
            return View(viewmodel);
        }

        // POST: AboutController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AboutView model)
        {
           
                var deleteData = await aboutRepository.GetById(id);
                if(deleteData != null)
                {
                   

                    if(model.AboutViewImage != null)
                    {
                    var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploads\\About");
                    string filename = Path.Combine(CurrentImage, model.AboutViewImage);

                        if (System.IO.File.Exists(filename))
                            {
                                System.IO.File.Delete(filename);
                            }
                    }                   
                    await aboutRepository.DeleteAbout(deleteData);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Delete));

                



           

        }

        private void MappedGetModel(AboutView aboutView ,About about)
        {          
            {
                aboutView.Id = about.Id;
                aboutView.Content=about.Content;
                aboutView.AboutViewImage=about.AboutDataImage;
                about.createdAt=about.createdAt;
            }        
        }
        //    private string UploadFiles(AboutView model)
        //    {
        //        string UniqueName = "";
        //        if (model.ImgFile != null)
        //        {
        //            string UploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads/About");
        //            string fileName = Guid.NewGuid().ToString() + "-"+model.ImgFile.FileName ;
        //            string filePath=Path.Combine(UploadsFolder,fileName);
        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                model.ImgFile.CopyTo(fileStream);
        //            }              
        //        }
        //        return UniqueName;
        //    }

        private string UploadedFile(AboutView model)
        {
            string uniquFileName = "";
            if (model.ImgFile != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads/About");
                uniquFileName = Guid.NewGuid().ToString() + "-" + model.ImgFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniquFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImgFile.CopyTo(fileStream);
                }
            }
            return uniquFileName;
        }
    }

}
