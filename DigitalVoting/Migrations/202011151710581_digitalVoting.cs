namespace DigitalVoting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class digitalVoting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ballots", "Type_Id", "dbo.BallotTypes");
            DropIndex("dbo.Ballots", new[] { "Type_Id" });
            RenameColumn(table: "dbo.Ballots", name: "Type_Id", newName: "TypeId");
            AlterColumn("dbo.Ballots", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ballots", "TypeId");
            AddForeignKey("dbo.Ballots", "TypeId", "dbo.BallotTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ballots", "TypeId", "dbo.BallotTypes");
            DropIndex("dbo.Ballots", new[] { "TypeId" });
            AlterColumn("dbo.Ballots", "TypeId", c => c.Int());
            RenameColumn(table: "dbo.Ballots", name: "TypeId", newName: "Type_Id");
            CreateIndex("dbo.Ballots", "Type_Id");
            AddForeignKey("dbo.Ballots", "Type_Id", "dbo.BallotTypes", "Id");
        }
    }
}
