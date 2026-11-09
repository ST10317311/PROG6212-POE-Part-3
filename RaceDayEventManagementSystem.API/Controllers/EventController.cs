using Microsoft.AspNetCore.Mvc;
using RaceDayEventManagementSystem.API.Data;

namespace RaceDayEventManagementSystem.API.Controllers
{

        [Route("api/[controller]")]
        [ApiController]

        public class EventController : ControllerBase
        {
            private readonly AppDbContext dbContext;
            public EventController(AppDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            [HttpGet]
            public IActionResult GetAllEvents()
            {
                var events = dbContext.EventModel.ToList();
                return Ok(events);
            }
            [HttpGet]
            [Route("{id:guid}")]
            public IActionResult GetEventById(Guid id)
            {
                var eventItem = dbContext.EventModel.Find(id);
                if (eventItem == null)
                {
                    return NotFound();
                }
                return Ok(eventItem);
            }
        }
}
