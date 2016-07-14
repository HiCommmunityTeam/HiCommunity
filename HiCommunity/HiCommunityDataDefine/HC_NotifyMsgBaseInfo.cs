using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCommunityDataDefine
{
   public partial class HC_NotifyMsgBaseInfo
    {
       public HC_NotifyMsgBaseInfo()
       {
           Id = string.Empty;
           UserID = string.Empty;
           MsgType = string.Empty;
           MsgConect = string.Empty;
           MsgStatus = 0;
           TimeMark = DateTime.Now;
       }

       public string Id { get; set; }

       public string UserID { get; set; }

       public string MsgType { get; set; }

       public string MsgConect { get; set; }

       public int MsgStatus { get; set; }

       public DateTime TimeMark { get; set; }

    }
}
