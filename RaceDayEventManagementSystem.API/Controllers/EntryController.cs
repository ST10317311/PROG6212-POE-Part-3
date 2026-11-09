using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayEventManagementSystem.API.Data;

namespace RaceDayEventManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public EntryController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEntries()
        {
            var entries = dbContext.EntryModel.ToList();
            return Ok(entries);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEntryById(Guid id)
        {
            var entry = dbContext.EntryModel.Find(id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }
    }
}
