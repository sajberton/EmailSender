using EmailSender.Models;
using EmailSender.Services;
using EmailSender.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EmailSender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IQueueService _queueService;

        public SendEmailController(IQueueService queueService)
        {
            _queueService = queueService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] SendEmailRequestModel model)
        {
            try
            {
                var res = await _queueService.QueueSendEmailJobAsync(model.ClientId, model.TemplateId, model.ToEmail);
                if (res)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
