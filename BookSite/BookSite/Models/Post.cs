using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSite
{
    public class Post
    {
        public virtual string creatorName { get; set; }
        public virtual string PostType { get; set; }
        public virtual int PostID { get; set; }

        public virtual string Title { get; set; }
        public virtual string Message { get; set; }
    }
}