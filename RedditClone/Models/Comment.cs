using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedditClone.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Author {get; set;}
        [Required]
        public DateTime PostTime { get; set; } = DateTime.Now;
        public string Body { get; set; }
        public int UpVotes { get; set; } = 0;
        public int DownVotes { get; set; } = 0;

        public virtual RedditPost RedditPost { get; set; } 
    }
}