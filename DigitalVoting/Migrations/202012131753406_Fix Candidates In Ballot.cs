namespace DigitalVoting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCandidatesInBallot : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Ballots", name: "Candidates_Id", newName: "Candidate_Id");
            RenameIndex(table: "dbo.Ballots", name: "IX_Candidates_Id", newName: "IX_Candidate_Id");
            AddColumn("dbo.Ballots", "CandidateId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ballots", "CandidateId");
            RenameIndex(table: "dbo.Ballots", name: "IX_Candidate_Id", newName: "IX_Candidates_Id");
            RenameColumn(table: "dbo.Ballots", name: "Candidate_Id", newName: "Candidates_Id");
        }
    }
}
