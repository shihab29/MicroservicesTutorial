using Mango.Web.Models;
using Mango.Web.Services.IServices;
using static Mango.Web.SD;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClient;

        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Url = SD.ProductAPIBase + "/api/ProductAPI",
                Data = productDto,
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/ProductAPI/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetProductById<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = SD.ProductAPIBase + "/api/ProductAPI/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetProducts<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = SD.ProductAPIBase + "/api/ProductAPI",
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.PUT,
                Url = SD.ProductAPIBase + "/api/ProductAPI",
                Data = productDto,
                AccessToken = ""
            });
        }
    }
}
