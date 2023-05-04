using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Versioning_API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class ValuesController : ControllerBase
    {
        //Get api/v1/Users
        [HttpGet]
        [MapToApiVersion("1.0")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Version 1.0 - User 1", "Version 1.0 - User 2" };
        }

        [HttpGet]
        [MapToApiVersion("2.0")]

        public IEnumerable<string> Getv2()
        {
            return new string[] { "Version 2.0 - User 1", "User 2" };
        }
    }
}