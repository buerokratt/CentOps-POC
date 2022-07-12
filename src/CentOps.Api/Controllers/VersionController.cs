﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentOps.Api.Controllers
{
    [Route("version")]
    [ApiController]
    [AllowAnonymous]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVersion()
        {
            return Ok("Yes");
        }
    }
}
