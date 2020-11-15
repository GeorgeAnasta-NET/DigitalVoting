namespace DigitalVoting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateCreatedatBallot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ballots", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ballots", "DateCreated");
        }
    }
}
