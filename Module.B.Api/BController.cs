using Microsoft.AspNetCore.Mvc;

namespace Module.B.Api
{
    [Route("api/b")]
    public class BController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from B Module!");
        }
    }
}