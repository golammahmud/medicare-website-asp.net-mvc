using view.modelApp;

namespace client.medicareApp.Services
{
    public interface IBannerService
    {
        Task<List<BannerView>> GetAll();
        Task<BannerView> Get(long Id);
        Task<BannerView> Add(BannerView model);
        Task<BannerView> Update(BannerView model);
        Task<bool> Remove(long Id);
    }
    public class BannerServices : IBannerService
    {
        private readonly  HttpClient http;

        public BannerServices(HttpClient _http)
        {
            this.http = _http;
        }
        public async Task<BannerView> Add(BannerView model)
        {
            try
            {
                var response = await http.PostAsJsonAsync("api/Home",model);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadFromJsonAsync<BannerView>();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BannerView> Get(long Id)
        {
            try
            {
                var response = await http.GetFromJsonAsync<BannerView>("api/Home/" + Id);
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BannerView>> GetAll()
        {
            try
            {
                return await http.GetFromJsonAsync<List<BannerView>>("api/Home");
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Remove(long Id)
        {
            try
            {
                var response = await http.DeleteAsync("api/Home/" + Id);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BannerView> Update(BannerView model)
        {
            try
            {
                if (model == null)
                    return null;
                var response = await http.PutAsJsonAsync("api/Home" + model.Id, model);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadFromJsonAsync<BannerView>();
                }
                else
                {
                    return null;
                }
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
