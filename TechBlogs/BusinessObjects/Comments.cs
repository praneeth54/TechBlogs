using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Table("Comments")]
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public DateTime CommentDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
}
