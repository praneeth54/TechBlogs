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
        public Posts()
        {
            this.Comments = new HashSet<Comments>();
            this.Tags = new HashSet<Tags>();
            this.users = new HashSet<Users>();
        }

        [Key]
        public int PostId { get; set; }
        public string PostName { get; set; }
        public DateTime PostDate { get; set; }
        public string PostDescription { get; set; }
        public int? userid { get; set; }
        public int? likepost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tags> Tags { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users> users { get; set; }
        public virtual Users user { get; set; }

        //public int? tagid { get; set; }
        //


        //public int LikesForPost { get; set; }
        //public List<Comments> CommentsForPosts { get; set; }

    }
}
