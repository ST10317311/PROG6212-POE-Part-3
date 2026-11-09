using Microsoft.AspNetCore.Mvc;
using RaceDayEventManagementSystem.API.Data;

namespace RaceDayEventManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public ParticipantController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllParticipants()
        {
            var participants = dbContext.ParticipantModel.ToList();
            return Ok(participants);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetParticipantById(Guid id)
        {
            var participant = dbContext.ParticipantModel.Find(id);
            if (participant == null)
            {
                return NotFound();
            }
            return Ok(participant);
        }
    }
}