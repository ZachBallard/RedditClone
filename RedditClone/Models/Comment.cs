using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Humanizer;

namespace RedditClone.Models
{
    public class Comment : IVoteable
    {
        public int Id { get; set; }
        [Required]
        public string Author {get; set;}
        [Required]
        public DateTime PostTime { get; set; } = DateTime.Now;
        public string Body { get; set; }
        public int UpVotes { get; set; } = 0;
        [NotMapped]
        public string PrettyPostTime => PostTime.Humanize(false);
        [NotMapped]
        public int TotalVotes => UpVotes - DownVotes;

        public int DownVotes { get; set; } = 0;

        public virtual RedditPost RedditPost { get; set; } 
    }
}