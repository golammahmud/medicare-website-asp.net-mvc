using Data.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.App.repository
{
    public class AboutRepository
    {
        public interface IAboutRepository
        {
            IQueryable<About> GetAllAbouts();
            Task<About> GetById(int id);

            Task<About> InsertAbout(About about);

            Task<About> UpdateAbout(About about);

            Task<About> DeleteAbout(About abouts);
        }
        public class AboutsRepository : IAboutRepository
        {
            private readonly AppDbContext _appDbContext;
            public AboutsRepository(AppDbContext appDbContext)
            {
                this._appDbContext = appDbContext;
            }

           

            public IQueryable<About> GetAllAbouts()
            {
                try
                {
                    IQueryable<About> data = _appDbContext.About.AsQueryable();
                    return data;
                }
                catch
                {
                   throw new NullReferenceException(nameof(GetAllAbouts));
                }
            }

            public async Task<About>  GetById(int id)
            {
                return await _appDbContext.About.FirstOrDefaultAsync(g => g.Id == id);
            }

            public async Task<About> InsertAbout(About about)
            {
                if(about == null)
                    throw new ArgumentNullException(nameof(about));
                var result= await _appDbContext.About.AddAsync(about);  
                _appDbContext.SaveChanges();
                return result.Entity;
            }

            public async Task<About> UpdateAbout(About about)
            {
                if(about == null)
                    throw new ArgumentNullException(nameof(About));
               var result= _appDbContext.About.Update(about);
               await _appDbContext.SaveChangesAsync(true);
                return result.Entity;
            }
            public async Task<About> DeleteAbout(About about)
            {
                try
                {
                    var data=await _appDbContext.About.FindAsync(about.Id);
                    if(data != null)
                    {
                        var result =  _appDbContext.About.Remove(data);
                        await _appDbContext.SaveChangesAsync(true);
                        return result.Entity;
                    }
                    return null;
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
}
