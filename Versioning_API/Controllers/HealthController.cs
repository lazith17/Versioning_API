using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Versioning_API.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiVersionNeutral]
public class HealthController : ControllerBase
{
        //Get api/v1/Health
    [HttpGet]
    [Route("ping")]
    public IActionResult Ping()
    {
        return Ok("Everything Seems to be ok");
    }
}
