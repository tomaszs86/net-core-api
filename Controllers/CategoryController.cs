using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using net_core_api.Repositories;
using net_core_api.Attributes;
using net_core_api.DTO;
using System.Threading.Tasks;
using api.net_core_api;

namespace net_core_api.Controllers
{
[Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            List<Category> categories = await _categoryRepository.GetAll();
            var results = Mapper.Map<List<CategoryDTO>>(categories); 

            return Ok(results);
        }
    }
}