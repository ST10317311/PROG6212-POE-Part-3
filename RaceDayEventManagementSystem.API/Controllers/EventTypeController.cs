using Microsoft.AspNetCore.Mvc;
using RaceDayEventManagementSystem.API.Data;

namespace RaceDayEventManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public EventTypeController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEventTypes()
        {
            var eventTypes = dbContext.EventTypeModel.ToList();
            return Ok(eventTypes);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEventTypeById(Guid id)
        {
            var eventType = dbContext.EventTypeModel.Find(id);
            if (eventType == null)
            {
                return NotFound();
            }
            return Ok(eventType);
        }
    }
}
