using System;
using TrussApi.Models;

namespace TrussApi.DataBaseContext.Interfaces
{
	public interface IProductRepo
	{
		Task<List<ProductModel>> GetAllProducts();
		Task<ProductModel> GetProductById(int id);
		Task<ProductModel> CreateProduct(ProductModel product);
		Task<ProductModel> UpdateProduct(ProductModel product, int id);
        Task<bool> DeleteProduct(int id);
    }
}

