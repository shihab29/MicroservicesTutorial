using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private IProductRepository _productRepository { get; }
        protected ResponseDto _responseDto;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _responseDto = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                _responseDto.Result = await _productRepository.GetProducts();
                _responseDto.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<object> Get(int productId)
        {
            try
            {
                _responseDto.Result = await _productRepository.GetProductById(productId);
                _responseDto.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto product)
        {
            try
            {
                _responseDto.Result = await _productRepository.CreateUpdateProduct(product);
                _responseDto.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto product)
        {
            try
            {
                _responseDto.Result = await _productRepository.CreateUpdateProduct(product);
                _responseDto.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;
        }

        [HttpDelete]
        public async Task<object> Delete(int productId)
        {
            try
            {
                _responseDto.Result = await _productRepository.DeleteProduct(productId);
                _responseDto.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDto;
        }
    }
}
