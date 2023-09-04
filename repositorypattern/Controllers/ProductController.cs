using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using repositorypattern.Model;
using repositorypattern.Repository;

namespace repositorypattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Repository Pattern
    public class productController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public productController(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;   
        }

        [HttpGet] 
        public IActionResult GetAll()
        {
            var products = _productRepository.GetAll();
            var productmodel = _mapper.Map<List<Viewproductmodel>>(products);

            return Ok(productmodel);
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
        public IActionResult Add(Viewproductmodel product)
        {
            var map = _mapper.Map<Product>(product);
            map.Price = 3000;  
           _productRepository.Add(map);    
            return Ok(map);
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
