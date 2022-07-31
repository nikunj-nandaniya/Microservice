using Web.Models;
using Web.Services.IServices;
using Web.Common;

namespace Web.Services
{
    public class ProductService : BaseService, IProductService
    {

        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;    
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
           return await this.SendAsync<T>( new ApiRequest 
            {
                ApiType = APIBase.ApiType.POST,
                Url= APIBase.ProductAPIBase + "/api/products",
                Data = productDto,
                AccessToken = ""            
            });
        }

        public async Task<T> DeleteProdtcByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = APIBase.ApiType.DELETE,
                Url = APIBase.ProductAPIBase + "/api/products/" + id,                
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = APIBase.ApiType.GET,
                Url = APIBase.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }

        public async Task<T> GetProdtcByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = APIBase.ApiType.GET,
                Url = APIBase.ProductAPIBase + "/api/products/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = APIBase.ApiType.PUT,
                Url = APIBase.ProductAPIBase + "/api/products",
                Data = productDto,
                AccessToken = ""
            });
        }
    }
}
