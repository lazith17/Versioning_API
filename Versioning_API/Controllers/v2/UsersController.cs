using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Versioning_API.Controllers.v2
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class UsersController : ControllerBase
    {
        //Get api/v1/Users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Version 2.0 - User 1", "Version 2.0 - User 2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"User {id.ToString()}";
        }
    }
}