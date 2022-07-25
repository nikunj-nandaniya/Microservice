using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ProductAPI.Models.Dto;
using Services.ProductAPI.Repository;

namespace Services.ProductAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private ResponseDto _responseDTO;
        private readonly IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _responseDTO = new ResponseDto();
        }

        [HttpGet]
        public async Task<object>Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _responseDTO.Result = productDtos;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>(){ex.ToString()};
            }

            return _responseDTO;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);
                _responseDTO.Result = productDto;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDTO;
        }


        [HttpPost]        
        public async Task<object>AddProduct(ProductDto productDto)
        {
            try
            {
                ProductDto _productDto = await _productRepository.CreateUpdateProduct(productDto);
                _responseDTO.Result = _productDto;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDTO;
        }

        [HttpPut]
        public async Task<object> UpdateProduct(ProductDto productDto)
        {
            try
            {
                ProductDto _productDto = await _productRepository.CreateUpdateProduct(productDto);
                _responseDTO.Result = _productDto;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDTO;
        }

        [HttpDelete]
        public async Task<object> DeleteProduct(int id)
        {
            try
            {
                bool _isSuccess = await _productRepository.DeleteProduct(id);
                _responseDTO.Result = _isSuccess;
            }
            catch (Exception ex)
            {
                _responseDTO.IsSuccess = false;
                _responseDTO.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _responseDTO;
        }
    }
}
