using Data.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.App.repository
{
    public interface IBannerRepository
    {
        IEnumerable<Banner> GetAllBanners();
        Task<Banner> GetBanner(int bannerId);
        Task<Banner> AddBanner(Banner banner);
        Task<Banner> UpdateBanner(Banner banner);
        void DeleteBanner(Banner banner);
        
    }
    public class BannerRepository : IBannerRepository
    {
        private readonly AppDbContext _appDbContext;
        public BannerRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public IEnumerable<Banner> GetAllBanners()
        {
            try
            {
                return _appDbContext.Banner.ToList();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Banner>();
            }
        }

        public async Task<Banner> GetBanner(int bannerId)
        {
            //try
            //{
               
                return await _appDbContext.Banner.FirstOrDefaultAsync(f => f.Id == bannerId);

            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
        }
        public async Task<Banner> AddBanner(Banner banner)
        {
            try
            {
                if(banner != null)
                {
                    var result = await _appDbContext.Banner.AddAsync(banner);
                    await _appDbContext.SaveChangesAsync();
                    return result.Entity;
                }
                return null;                    

            }catch (Exception ex)
            {
                throw new ArgumentNullException(nameof(banner));
            }
        }

        public async Task<Banner> UpdateBanner(Banner banner)
        {
            try
            {
                var result = await _appDbContext.Banner.FirstOrDefaultAsync(s => s.Id == banner.Id);

                if (result != null)
                {
                    result.Id = banner.Id;
                    result.Title = banner.Title;
                    result.Content = banner.Content;
                    result.CoverImageUrl = banner.CoverImageUrl;
                    result.createdAt = banner.createdAt;
                    var data= _appDbContext.Banner.Update(result);
                    await _appDbContext.SaveChangesAsync();
                    return data.Entity;

                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return banner;
        }

        public  void DeleteBanner(Banner banner)
        {
            try
            {
                Banner book = _appDbContext.Banner.Find(banner.Id);
                _appDbContext.Banner.Remove(book);
                _appDbContext.SaveChanges();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _appDbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



    }
}
