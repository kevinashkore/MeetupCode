namespace LibraryOneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BranchBooks", "ReservationID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BranchBooks", "ReservationID");
        }
    }
}
