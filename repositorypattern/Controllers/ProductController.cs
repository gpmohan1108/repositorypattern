using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repositorypattern.Model;
using repositorypattern.Repository;

namespace repositorypattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public productController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet] 
        public IActionResult GetAll()
        {
            var products = _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productRepository.Add(product);    
            return Ok(product);
        }

        [HttpPut]
        public IActionResult Update(Product product) { 
            _productRepository.Update(product); 
            return Ok(product);
        
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _productRepository.Delete(id);
            return Ok();
        }
    }
}
