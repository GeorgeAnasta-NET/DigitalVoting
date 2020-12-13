namespace DigitalVoting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCandidatesInBallot1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Ballots", new[] { "Candidate_Id" });
            DropColumn("dbo.Ballots", "CandidateId");
            RenameColumn(table: "dbo.Ballots", name: "Candidate_Id", newName: "CandidateId");
            AlterColumn("dbo.Ballots", "CandidateId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Ballots", "CandidateId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ballots", new[] { "CandidateId" });
            AlterColumn("dbo.Ballots", "CandidateId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Ballots", name: "CandidateId", newName: "Candidate_Id");
            AddColumn("dbo.Ballots", "CandidateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ballots", "Candidate_Id");
        }
    }
}
