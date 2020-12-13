namespace DigitalVoting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropsatModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Combinations", "CandidateId", c => c.String(maxLength: 128));
            AddColumn("dbo.Combinations", "Ballot_Id", c => c.Int());
            CreateIndex("dbo.Combinations", "CandidateId");
            CreateIndex("dbo.Combinations", "Ballot_Id");
            AddForeignKey("dbo.Combinations", "CandidateId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Combinations", "Ballot_Id", "dbo.Ballots", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Combinations", "Ballot_Id", "dbo.Ballots");
            DropForeignKey("dbo.Combinations", "CandidateId", "dbo.AspNetUsers");
            DropIndex("dbo.Combinations", new[] { "Ballot_Id" });
            DropIndex("dbo.Combinations", new[] { "CandidateId" });
            DropColumn("dbo.Combinations", "Ballot_Id");
            DropColumn("dbo.Combinations", "CandidateId");
        }
    }
}
