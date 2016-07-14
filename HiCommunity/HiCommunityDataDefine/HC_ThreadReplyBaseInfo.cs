using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCommunityDataDefine
{
    public partial class HC_ThreadReplyBaseInfo
    {
        public HC_ThreadReplyBaseInfo()
        {
            Id = string.Empty;
            ReplyUID = string.Empty;
            TimeMark = DateTime.Now;
            ReplyText = string.Empty;
            ReplyAudio = string.Empty;
            ReplyImage = string.Empty;
            ReplyToUID = string.Empty;
            ThreadID = string.Empty;
        }

        public string Id { get; set; }

        public string ReplyUID { get; set; }

        public DateTime TimeMark { get; set; }

        public string ReplyText { get; set; }

        public string ReplyAudio { get; set; }

        public string ReplyImage { get; set; }

        public string ReplyToUID { get; set; }

        public string ThreadID { get; set; }
    }
}
