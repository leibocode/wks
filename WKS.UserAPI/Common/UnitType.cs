using System.Collections.Generic;
using System.Linq; 

namespace WKS.UserAPI.Common
{
    public abstract class UnitType
    {
        private Dictionary<string, string> list = new Dictionary<string, string>()
        {
            { "米", "m" },
            { "千米","km" }
        };


        public bool IsUnitExits(string unitName)
        {
            return (list.Keys.Contains(unitName) || list.Values.Contains(unitName));
        }

        public string GetUnitByKey(string key)
        {
            return list.GetValueOrDefault(key);
        }
       
    }

    public class UnitModel
    {
        public string UnitName { get; set; }
        //public int  1000{ get; set; }
    }
}
