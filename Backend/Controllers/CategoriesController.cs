using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.Service;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;


        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return _categoryService.GetAllCategories();
        }

        // GET: api/Categories/5
        [HttpGet("Get/{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update/{id}")]
        public IActionResult PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            try
            {
                _categoryService.UpdateCategory(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add")]
        public ActionResult<Category> PostCategory(Category category)
        {
            _categoryService.AddCategory(category);
            return CreatedAtAction("Get", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category =  _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.RemoveCategory(category);
            return NoContent();
        }

        // Async methods

        // GET: api/Categories
        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesAsync()
        {
            return _categoryService.GetAllCategories();
        }

        // GET: api/Categories/5
        [HttpGet("GetAsync/{id}")]
        public async Task<ActionResult<Category>> GetCategoryAsync(int id)
        {
            var category = _categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateAsync{id}")]
        public async Task<IActionResult> PutCategoryAsync(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            try
            {
                _categoryService.UpdateCategory(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddAsync")]
        public async Task<ActionResult<Category>> PostCategoryAsync(Category category)
        {
            _categoryService.AddCategory(category);
            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.RemoveCategory(category);
            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _categoryService.GetAllCategories().Any(e => e.Id == id);
        }
    }
}
