using SqlSugar;

namespace WKS.UserAPI.Data.Entities
{
    [SugarTable("userinfo")]
    public class UserInfo
    {
        public string Name { get; set; }

        public string OpenId { get; set; }
    }
}
