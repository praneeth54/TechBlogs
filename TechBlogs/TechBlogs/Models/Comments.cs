using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlogs.Models
{
   public class Comments
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public DateTime CommentDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
}
