﻿using Services.ProductAPI.Models.Dto;
using Services.ProductAPI.DbContexts;
using AutoMapper;
using Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;    
        private readonly IMapper _mapper;   

        public ProductRepository(AppDbContext db, Mapper mapper)
        {
            _db = db;
            _mapper = mapper;   
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto,Product>(productDto);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            { 
                _db.Products.Add(product);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

                if (product == null)
                {
                    return false;
                }

                _db.Products.Remove(product);
                _db.SaveChanges();

                return true;
            
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> lstproducts =  await _db.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(lstproducts);
        }
    }
}
