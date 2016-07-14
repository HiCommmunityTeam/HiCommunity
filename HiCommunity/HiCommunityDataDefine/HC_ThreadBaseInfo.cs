using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCommunityDataDefine
{
    public partial class HC_ThreadBaseInfo
    {
        public HC_ThreadBaseInfo()
        {
            Id = string.Empty;
            ThreadTitle = string.Empty;
            ThreadContent = string.Empty;
            ThreadAudio = string.Empty;
            ThreadImage = string.Empty;
            TimeMark = DateTime.Now;
            TagID = string.Empty;
            CategoryID = string.Empty;
            UserID = string.Empty;
            PraiseUsers = string.Empty;
            PraiseCount = 0;
            ReplyCount = 0;
        }

        public string Id { get; set; }

        public string ThreadTitle { get; set; }

        public string ThreadContent { get; set; }

        public string ThreadAudio { get; set; }

        public string ThreadImage { get; set; }

        public DateTime TimeMark { get; set; }

        public string TagID { get; set; }

        public string CategoryID { get; set; }

        public string UserID { get; set; }

        public string PraiseUsers { get; set; }

        public int PraiseCount { get; set; }

        public int ReplyCount { get; set; }
    }
}
