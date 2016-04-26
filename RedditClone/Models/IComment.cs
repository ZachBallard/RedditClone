namespace RedditClone.Models
{
    public interface IVoteable
    {
        int DownVotes { get; set; }
        int UpVotes { get; set; }
        int TotalVotes { get; }
    }
}