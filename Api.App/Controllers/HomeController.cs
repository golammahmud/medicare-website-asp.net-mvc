using view.modelApp;
using Data.App.repository;
using Microsoft.AspNetCore.Mvc;
using Data.App.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        private readonly IBannerRepository bannerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IBannerRepository _bannerRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.bannerRepository = _bannerRepository;
            this._webHostEnvironment = webHostEnvironment;
        }
        // GET: HomeController
        [HttpGet]
        public IEnumerable<BannerView> Get()
        {
            try
            {

                var model = bannerRepository.GetAllBanners().Select(banner => new BannerView
                {
                    Id = banner.Id,
                    Title = banner.Title,
                    Content=banner.Content,
                    BannerCoverImage=banner.CoverImageUrl,
                    createdAt    = banner.createdAt
                });
                return model;
            }
            catch (Exception)
            {
                return (IEnumerable<BannerView>)StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BannerView>> GetBanner(int id)
        {
            try
            {
                BannerView model= new BannerView();

                Banner  banner=await bannerRepository.GetBanner(id);
                {
                    model.Id=banner.Id;
                    model.Title = banner.Title;
                    model.Content=banner.Content;
                    model.BannerCoverImage=banner.CoverImageUrl;
                    model.createdAt =(DateTime) banner.createdAt;
                }
                return Ok(model);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        // POST api/<HomeController>
        [HttpPost]
        public async Task<ActionResult<BannerView>> Post( BannerView banner)
        {
            try
            {
                if (banner == null)
                    return BadRequest();
                if(banner.CoverPhoto != null)
                {
                    string folder = "/UploadImages/BannerImages";
                    banner.BannerCoverImage =await UploadImage(folder, banner.CoverPhoto);
                }
                await bannerRepository.AddBanner( new Banner
                {
                    Id=banner.Id,
                    Title=banner.Title,
                    Content = banner.Content,
                    CoverImageUrl=banner.BannerCoverImage,
                    createdAt = (DateTime)banner.createdAt,
                });
                return Ok(banner);



            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new employee record");
            }
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BannerView>> Put(int id, BannerView banner)
        {
            try
            {
                //if (id != banner.Id)
                //    return BadRequest("banner ID mismatch");

                //var bannerToUpdate = await bannerRepository.GetBanner(id);

                //if (bannerToUpdate == null)
                //    return NotFound($"Banner with Id = {id} not found");
                //var result= await bannerRepository.UpdateBanner(bannerToUpdate);

                //return Ok(result);
             
                await bannerRepository.UpdateBanner(new Banner
                {
                    Id = (int)banner.Id,
                    Title = banner.Title,
                    Content = banner.Content,
                    CoverImageUrl= banner.BannerCoverImage,
                    createdAt =(DateTime) banner.createdAt,
                   

                });

                return Ok(banner);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( int id, BannerView model)
        {
            try
            {
                
                var data=await bannerRepository.GetBanner(model.Id);
                if (data != null)
                    return BadRequest();
                bannerRepository.DeleteBanner(data);
                return Ok();
               
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status400BadRequest , "Error updating data");
            }
        }

        private async Task<string> UploadImage(string folderpath, IFormFile file)
        {
            try
            {
                folderpath += Guid.NewGuid().ToString() + "_"+ file.FileName;
                string serverFloder = Path.Combine(_webHostEnvironment.WebRootPath, folderpath);
                await file.CopyToAsync(new FileStream(serverFloder, FileMode.Create));
                return "/" + folderpath;


            }catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
