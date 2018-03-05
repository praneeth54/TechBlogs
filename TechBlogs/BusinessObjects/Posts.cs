using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Table("Posts")]
    public class Posts
    {
        [Key]
        public int PostId { get; set; }
        public string PostName { get; set; }
        public DateTime PostDate { get; set; }
        public string PostDescription { get; set; }
        public int? userid { get; set; }
        public int? tagid { get; set; }
        public int? likepost { get; set; }


        //public int LikesForPost { get; set; }
        //public List<Comments> CommentsForPosts { get; set; }

    }
}
