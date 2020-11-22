namespace DigitalVoting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDbNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Voters", newName: "Candidates");
            DropForeignKey("dbo.Ballots", "Candidate_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Ballots", new[] { "Candidate_Id" });
            DropColumn("dbo.Ballots", "CandidateId");
            RenameColumn(table: "dbo.Ballots", name: "Candidate_Id", newName: "CandidateId");
            AlterColumn("dbo.Ballots", "CandidateId", c => c.Int(nullable: true));
            CreateIndex("dbo.Ballots", "CandidateId");
            AddForeignKey("dbo.Ballots", "CandidateId", "dbo.Candidates", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ballots", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.Ballots", new[] { "CandidateId" });
            AlterColumn("dbo.Ballots", "CandidateId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Ballots", name: "CandidateId", newName: "Candidate_Id");
            AddColumn("dbo.Ballots", "CandidateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ballots", "Candidate_Id");
            AddForeignKey("dbo.Ballots", "Candidate_Id", "dbo.AspNetUsers", "Id");
            RenameTable(name: "dbo.Candidates", newName: "Voters");
        }
    }
}
