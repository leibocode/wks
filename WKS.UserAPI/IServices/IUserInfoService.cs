using System.Threading.Tasks;
using WKS.UserAPI.Data.Entities;
using MS.Cloud.Core.DependencyInjection;

namespace WKS.UserAPI.IServices
{
    public interface IUserInfoService:IScopedDependency
    {
        Task<UserInfo> GetUserByPhone(string phone);
    }
}
