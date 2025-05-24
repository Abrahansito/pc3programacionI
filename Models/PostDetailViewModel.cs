using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace startup.Models
{
    public class PostDetailViewModel
    {
        public Post Post { get; set; }
        public User Author { get; set; }
        public List<Comment> Comments { get; set; }
        
    }
}