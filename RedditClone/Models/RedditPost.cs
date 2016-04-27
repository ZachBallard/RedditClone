using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Humanizer;

namespace RedditClone.Models
{
    public class RedditPost : IVoteable
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }
        [Required]
        public DateTime PostTime { get; set; } = DateTime.Now;
       
        public int UpVotes { get; set; } = 0;
        public int DownVotes { get; set; } = 0;

        [NotMapped]
        public string PrettyPostTime => PostTime.Humanize(false);

        [NotMapped]
        public int TotalVotes => UpVotes - DownVotes;

        public string ImageUrl { get; set; }
        public string Body { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}