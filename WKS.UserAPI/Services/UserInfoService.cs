using System.Threading.Tasks;
using WKS.UserAPI.Data.Entities;
using WKS.UserAPI.IServices;

namespace WKS.UserAPI.Services
{
    public class UserInfoService : IUserInfoService
    {
        public async Task<UserInfo> GetUserByPhone(string phone)
        {
            return await Task.Run(() =>
            {
                UserInfo userInfo = new UserInfo() { Name = "test",OpenId ="lb" };
                return userInfo;
            });
        }
    }
}
