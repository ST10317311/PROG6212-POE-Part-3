using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayEventManagementSystem.API.Data;

namespace RaceDayEventManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = dbContext.CategoryModel.ToList();
            return Ok(categories);
        }

        //[HttpGet("{id}")] - I dont know what this means. But it was also auto-suggested.
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetCategoryById(Guid id)
        {
            //var category = dbContext.CategoryModel.FirstOrDefault(c => c.categoryID == id);
            //This is an auto-suggested line of code.

            var category = dbContext.CategoryModel.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
