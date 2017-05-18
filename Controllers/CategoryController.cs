using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using net_core_api.Models;
using Microsoft.AspNetCore.Mvc;
using net_core_api.Repositories;
using net_core_api.Attributes;
using net_core_api.DTO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDTO category)
        {
            if (category.Name == "test")
            {
                ModelState.AddModelError("Name", "The provided description should be different from the name.");
            }

            if (!ModelState.IsValid)
            {   
                return BadRequest(ModelState);                
            }

            var model = Mapper.Map<Category>(category); 
            
            try
            {
                var result = await _categoryRepository.Add(model);
            }
            catch (DbUpdateException)
            {            
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return Created("Create", model.Key); 

        }
    }
}