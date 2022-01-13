using ExamenNetDeveloperCRUD.Domain;
using ExamenNetDeveloperCRUD.Services;
using ExamenNetDeveloperCRUD.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenNetDeveloperCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.GetAllProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _productService.GetProductById(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            try
            {
                var validator = new ProductValidator();
                var result = validator.Validate(product);
                if (result.IsValid)
                {
                    await _productService.CreateProductAsync(product);
                    return Ok();
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, result.Errors[0].ErrorMessage);
                }
                
            }
            catch (Exception ex)
            {

               return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
            

        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
        {
            try
            {

                var dbProduct = await _productService.GetProductById(id);
                if (await TryUpdateModelAsync<Product>(dbProduct))
                {
                    await _productService.UpdateProductAsync(dbProduct);                    
                }
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                var dbProduct = await _productService.GetProductById(id);
                if (dbProduct != null)
                {
                    await _productService.DeleteProductAsync(dbProduct);
                }
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
