using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedditClone.Models
{
    public class RedditPost
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime PostTime { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public string ImageUrl { get; set; }
        public string Body { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}