namespace RedditClone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RedditPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        PostTime = c.DateTime(nullable: false),
                        UpVotes = c.Int(nullable: false),
                        DownVotes = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        PostTime = c.DateTime(nullable: false),
                        Body = c.String(),
                        UpVotes = c.Int(nullable: false),
                        DownVotes = c.Int(nullable: false),
                        ParentComment_Id = c.Int(),
                        RedditPost_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.ParentComment_Id)
                .ForeignKey("dbo.RedditPosts", t => t.RedditPost_Id)
                .Index(t => t.ParentComment_Id)
                .Index(t => t.RedditPost_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "RedditPost_Id", "dbo.RedditPosts");
            DropForeignKey("dbo.Comments", "ParentComment_Id", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "RedditPost_Id" });
            DropIndex("dbo.Comments", new[] { "ParentComment_Id" });
            DropTable("dbo.Comments");
            DropTable("dbo.RedditPosts");
        }
    }
}
