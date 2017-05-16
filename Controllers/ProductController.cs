using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using net_core_api.Repositories;
using net_core_api.Attributes;
using net_core_api.DTO;

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
    }
}        