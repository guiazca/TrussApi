using System;
using Microsoft.EntityFrameworkCore;
using TrussApi.DataBaseContext.Interfaces;
using TrussApi.Models;

namespace TrussApi.DataBaseContext.Repo
{
	public class ProductRepo : IProductRepo
	{
        private readonly TrussContext _dbContext;
		public ProductRepo(TrussContext trussContext)
		{
            _dbContext = trussContext;
		}

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product, int id)
        {
            ProductModel productById = await GetProductById(id);

            if (productById == null)
            {
                throw new Exception($"Usuario para o Id: {id} não foi encontrado");
            }

            productById.Name = product.Name;
            productById.price = product.price;
            productById.linha = product.linha;
            productById.subLinha = product.subLinha;

            _dbContext.Products.Update(productById);
            await _dbContext.SaveChangesAsync();

            return productById;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            ProductModel productById = await GetProductById(id);

            if (productById == null)
            {
                throw new Exception($"Usuario para o Id: {id} não foi encontrado");
            }

            _dbContext.Products.Remove(productById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}

