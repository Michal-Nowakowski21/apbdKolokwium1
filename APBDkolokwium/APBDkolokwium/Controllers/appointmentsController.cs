using APBDkolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBDkolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class appointmentsController : ControllerBase
    {
        private readonly IDbService _dbservice;

        public appointmentsController(IDbService idbservice)
        {
            _dbservice = idbservice;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id )
        {
            try
            {
                var appointment = await _dbservice.getAppointment(id);
                return Ok(appointment);
            }
            catch
            {
                return NotFound();
            }
         
            
        }
    }
}
