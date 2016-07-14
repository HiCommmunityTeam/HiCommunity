using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCommunityDataDefine
{
   public partial class HC_CategoryBaseInfo
    {
       public HC_CategoryBaseInfo()
       {
           Id = string.Empty;
           CategoryName = string.Empty;
       }

       public string Id { get; set; }

       public string CategoryName { get; set; }

    }
}
