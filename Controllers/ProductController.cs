using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using net_core_api.Repositories;
using net_core_api.Attributes;
using net_core_api.DTO;
using net_core_api.Models;

namespace net_core_api.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var products = _productRepository.GetAll();
            var results = Mapper.Map<IEnumerable<ProductDTO>>(products); 

            return Ok(results);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(int id)
        {
            var item = _productRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            var productResult = Mapper.Map<ProductDTO>(item);             
            return Ok(productResult);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDTO item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var product = Mapper.Map<Product>(item); 
            _productRepository.Add(product);

            return CreatedAtRoute("GetProduct", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDTO item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var product = _productRepository.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            
            product.Name = item.Name;
            product.Price = item.Price;
            product.IsActive = item.IsActive;
            product.Description = item.Description;

            _productRepository.Update(product);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productRepository.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _productRepository.Remove(id);
            return new NoContentResult();
        }
    }
}        