using Microsoft.AspNetCore.Mvc;
using ProductService.Model;

namespace ProductService.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class ProductController : ControllerBase
        {
            // Sample static data for demo
            private static List<Product> Products = new List<Product> { new Product { Name = "Laptop" }, new Product { Name = "Phone" }, new Product { Name = "Tablet" } };

            // Get all products
            [HttpGet]
            public IActionResult GetProducts()
            {
                return Ok(Products);
            }

            // Get a specific product by name
            [HttpGet("{name}")]
            public IActionResult GetProduct(string name)
            {
                var product = Products.Find(p => p.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
                if (product == null)
                    return NotFound("Product not found.");
                return Ok(product);
            }

            // Add a new product
            [HttpPost]
            public IActionResult AddProduct([FromBody] Product product)
            {
                Products.Add(product);
                return Ok();
            }
        }
       
}
