namespace LibraryOneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedReservationID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BranchBooks", "ReservationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BranchBooks", "ReservationID", c => c.Int());
        }
    }
}
