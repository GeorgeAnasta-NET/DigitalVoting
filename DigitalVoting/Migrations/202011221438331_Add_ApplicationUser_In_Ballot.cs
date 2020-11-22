namespace DigitalVoting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ApplicationUser_In_Ballot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ballots", "CandidateId", c => c.Int(nullable: false));
            AddColumn("dbo.Ballots", "Candidate_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Ballots", "Candidate_Id");
            AddForeignKey("dbo.Ballots", "Candidate_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ballots", "Candidate_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Ballots", new[] { "Candidate_Id" });
            DropColumn("dbo.Ballots", "Candidate_Id");
            DropColumn("dbo.Ballots", "CandidateId");
        }
    }
}
