using Application;
using Application.Guest.DTO;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly ILogger<GuestController> _logger;
        private readonly IGuestManager _guestManager;

        public GuestController(ILogger<GuestController> logger, IGuestManager guestManager)
        {
            _logger = logger;
            _guestManager = guestManager;
        }

        [HttpPost]
        public async Task<ActionResult<GuestDTO>> Post(GuestDTO guestDTO)
        {
            var request = new CreateGuestRequest { Data = guestDTO };
            var res = await _guestManager.CreateGuest(request);

            if (res.Success)
                return Ok(res.Data);

            if (res.ErrorCode == ErrorCodes.NOT_FOUND)
                return NotFound(res);

            _logger.LogError("Response with unknow ErrorCode returned", res);
            return BadRequest(res);
        }
    }
}
