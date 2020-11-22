namespace DigitalVoting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorFixesInModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                {
                    FollowerId = c.String(nullable: false, maxLength: 128),
                    FolloweeId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
                
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.NotificationId })
                .ForeignKey("dbo.Notifications", t => t.NotificationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.NotificationId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        OriginalDateTime = c.DateTime(),
                        OriginalVenue = c.String(),
                        Ballot_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ballots", t => t.Ballot_Id, cascadeDelete: true)
                .Index(t => t.Ballot_Id);
            
            AddColumn("dbo.Ballots", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ballots", "IsCanceled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Candidates", "Ballot_Id", c => c.Int());
            AddColumn("dbo.Candidates", "Candidates_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Candidates", "Ballot_Id1", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Candidates", "Ballot_Id");
            CreateIndex("dbo.Candidates", "Candidates_Id");
            CreateIndex("dbo.Candidates", "Ballot_Id1");
            AddForeignKey("dbo.Candidates", "Ballot_Id", "dbo.Ballots", "Id");
            AddForeignKey("dbo.Candidates", "Candidates_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Candidates", "Ballot_Id1", "dbo.Ballots", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "Ballot_Id1", "dbo.Ballots");
            DropForeignKey("dbo.Candidates", "Candidates_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserNotifications", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserNotifications", "NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "Ballot_Id", "dbo.Ballots");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Candidates", "Ballot_Id", "dbo.Ballots");
            DropIndex("dbo.Notifications", new[] { "Ballot_Id" });
            DropIndex("dbo.UserNotifications", new[] { "NotificationId" });
            DropIndex("dbo.UserNotifications", new[] { "UserId" });
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropIndex("dbo.Candidates", new[] { "Ballot_Id1" });
            DropIndex("dbo.Candidates", new[] { "Candidates_Id" });
            DropIndex("dbo.Candidates", new[] { "Ballot_Id" });
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.Candidates", "Ballot_Id1");
            DropColumn("dbo.Candidates", "Candidates_Id");
            DropColumn("dbo.Candidates", "Ballot_Id");
            DropColumn("dbo.Ballots", "IsCanceled");
            DropColumn("dbo.Ballots", "DateTime");
            DropTable("dbo.Notifications");
            DropTable("dbo.UserNotifications");
            DropTable("dbo.Followings");
        }
    }
}
