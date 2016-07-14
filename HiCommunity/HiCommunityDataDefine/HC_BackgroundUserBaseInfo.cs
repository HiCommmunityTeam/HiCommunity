using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCommunityDataDefine
{
   public partial class HC_BackgroundUserBaseInfo
    {
       public HC_BackgroundUserBaseInfo()
       {
           Id = string.Empty;
           UserID = string.Empty;
           PurviewStr = string.Empty;
       }

       public string Id { get; set; }

       public string UserID { get; set; }

       public string PurviewStr { get; set; }

    }
}
