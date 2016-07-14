using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCommunityDataDefine
{
   public partial class HC_ThreadTagBaseInfo
    {
       public HC_ThreadTagBaseInfo() 
       {
           Id = string.Empty;
           TypeName = string.Empty;
           TagName = string.Empty;
       }

       public string Id { get; set; }

       public string TypeName { get; set; }

       public string TagName { get; set; }
    }
}
