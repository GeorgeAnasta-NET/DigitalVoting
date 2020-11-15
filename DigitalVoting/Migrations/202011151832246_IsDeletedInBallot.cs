namespace DigitalVoting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDeletedInBallot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ballots", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ballots", "IsDeleted");
        }
    }
}
