using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MS.Cloud.AspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WKS.UserAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserInfoController : ControllerBase
    {


        [HttpGet]
        public async Task<ApiResult> GetList()
        {
            return ApiResult.Ok("test");
        }
    }
}
