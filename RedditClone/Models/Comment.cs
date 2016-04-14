using System;
using System.Collections.Generic;

namespace RedditClone.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Author {get; set;}
        public DateTime PostTime { get; set; }
        public string Body { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }

        public virtual RedditPost RedditPost { get; set; } 
        public virtual ICollection<Comment> SubComments { get; set; } = new List<Comment>();
        public virtual Comment ParentComment { get; set; }
    }
}