using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrussApi.DataBaseContext.Interfaces;
using TrussApi.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrussApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> SearchProduct()
        {
            List<ProductModel> products = await _productRepo.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("product/{id}")]
        public async Task<ActionResult<ProductModel>> SearchById(int id)
        {
            ProductModel product = await _productRepo.GetProductById(id);
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<ProductModel>> AddProduct([FromBody] ProductModel product)
        {
            ProductModel productModel = await _productRepo.CreateProduct(product);

            return Ok(productModel);
        }
        [HttpDelete("product/{id}")]
        public async Task<ActionResult<ProductModel>> DeleteProduct(int id)
        {
            bool isDeleted = await _productRepo.DeleteProduct(id);
            return Ok(isDeleted);
        }
        [HttpPut("product/{id}")]
        public async Task<ActionResult<ProductModel>> UpdateProduct([FromBody] ProductModel productModel, int id)
        {
            productModel.Id = id;
            ProductModel updatedProduct = await _productRepo.UpdateProduct(productModel, id);

            return Ok(updatedProduct);
        }
    }
}

