using BookStorewebApi.Models;
using BookStorewebApi.Services.IServices;
using BookStorewebApi.SharedViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStorewebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        [HttpGet]
        [Route("GetBooksInCategory/{id}")]
        public IActionResult GetBooksInCategory(int id)
        {
            return Ok(_categoryService.GetBooksInCategory(id));
        }

        [Authorize]
        [HttpPost]
        [Route("AddCategory")]
        public IActionResult AddCategory([FromBody]AddCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var res = _categoryService.AddCategory(model);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + res.CategoryId, res);
            }
            return BadRequest("Invalid Data");
        }

        // DELETE api/<CategoryController>/5
        [Authorize]
        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category != null)
            {
                _categoryService.DeleteCategory(category);
                return Ok("deletd Suceess");
            }
            return NotFound($"Book with id: {id} is not found");
        }

        [Authorize]
        [HttpPost]
        [Route("EditCategory")]
        public IActionResult EditCategory(Category category)
        {
            var ExistingCategory = _categoryService.GetCategory(category.CategoryId);
            if (ExistingCategory != null)
            {
                var res = _categoryService.EditCategory(category);
                return Ok(res);
            }
            return NotFound($"Book with id: {category.CategoryId} is not found");
        }
    }
}
