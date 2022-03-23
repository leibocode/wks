﻿using Microsoft.AspNetCore.Mvc;

namespace WKS_API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController:ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        { 
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("执行");
            return Ok("test");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("test");
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok("test");
        }
    }
}
