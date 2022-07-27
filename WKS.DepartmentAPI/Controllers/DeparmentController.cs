using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MS.Cloud.AspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WKS.DepartmentAPI.Controllers
{
    [Route("api/deparment")]
    public class DeparmentController:BaseController
    {
        
        public async Task<ApiResult> GetList()
        {
            return ApiResult.Ok();
        }
    }
}
