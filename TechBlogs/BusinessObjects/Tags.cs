using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [Table("Tags")]
    public class Tags
    {
        public Tags()
        {
            this.posts = new HashSet<Posts>();
        }

        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<Posts> posts { get; set; }
    }
}

