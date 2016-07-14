using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCommunityDataDefine
{
    public partial class HC_UserBaseInfo
    {
        public HC_UserBaseInfo()
        {
            Id = string.Empty;
            EMail = string.Empty;
            UserName = string.Empty;
            UserPassWord = string.Empty;
            Sex = string.Empty;
            CellPhone = string.Empty;
            RegisterDate = DateTime.Now;
            RegisterType = string.Empty;
            LastLoginDate = DateTime.Now;
            LoginType = string.Empty;
            LoginOpenID = string.Empty;
            WXUnionID = string.Empty;
            WxOpenID = string.Empty;
        }

        public string Id { get; set; }

        public string EMail { get; set; }

        public string UserName { get; set; }

        public string UserPassWord{ get; set; }

        public string Sex { get; set; }

        public string CellPhone { get; set; }

        public DateTime RegisterDate { get; set; }

        public string RegisterType { get; set; }

        public DateTime LastLoginDate { get; set; }

        public string LoginType { get; set; }

        public string LoginOpenID { get; set; }

        public string WXUnionID { get; set; }

        public string WxOpenID { get; set; }
    }
}
