using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Posts
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public DateTime DateTimePost { get; set; }
        public string Description { get; set; }
        public int LikesForPost { get; set; }
        public List<Comments> CommentsForPosts { get; set; }

    }
}
