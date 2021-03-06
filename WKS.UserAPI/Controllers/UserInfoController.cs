using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MS.Cloud.AspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WKS.UserAPI.IServices;

namespace WKS.UserAPI.Controllers
{

    /// <summary>
    /// 1. 拿用户信息，2.维护就诊人
    /// </summary>
    [ApiController]
    [Route("api/user")]
    public class UserInfoController : ControllerBase
    {
        private readonly ILogger<UserInfoController> _logger;
        private readonly IUserInfoService _userInfoService; 

        public UserInfoController(ILogger<UserInfoController> logger, IUserInfoService userInfoService)
        {
            _logger = logger;
            _userInfoService = userInfoService;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult> GetList()
        {
            var result = await _userInfoService.GetUserByPhone("test");
            return ApiResult.Ok(result);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiResult CreateUser()
        {
            return ApiResult.Ok();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ApiResult> SaveUser()
        {
            return ApiResult.Ok();
        }
    }
}
