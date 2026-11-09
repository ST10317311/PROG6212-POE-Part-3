using Microsoft.AspNetCore.Mvc;
using RaceDayEventManagementSystem.API.Data;

namespace RaceDayEventManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganiserController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public OrganiserController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllOrganisers()
        {
            var organisers = dbContext.OrganiserModel.ToList();
            return Ok(organisers);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetOrganiserById(Guid id)
        {
            var organiser = dbContext.OrganiserModel.Find(id);
            if (organiser == null)
            {
                return NotFound();
            }
            return Ok(organiser);
        }
    }
}