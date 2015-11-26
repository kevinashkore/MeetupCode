namespace LibraryOneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.BranchBooks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        BranchID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.BranchID);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        BranchBookID = c.Int(nullable: false),
                        DateReserved = c.DateTime(nullable: false),
                        PatronID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchBookID)
                .ForeignKey("dbo.BranchBooks", t => t.BranchBookID)
                .ForeignKey("dbo.Patrons", t => t.PatronID, cascadeDelete: true)
                .Index(t => t.BranchBookID)
                .Index(t => t.PatronID);
            
            CreateTable(
                "dbo.Patrons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Checkouts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateCheckedOut = c.DateTime(nullable: false),
                        BranchBookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BranchBooks", t => t.BranchBookID, cascadeDelete: true)
                .Index(t => t.BranchBookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checkouts", "BranchBookID", "dbo.BranchBooks");
            DropForeignKey("dbo.Reservations", "PatronID", "dbo.Patrons");
            DropForeignKey("dbo.Reservations", "BranchBookID", "dbo.BranchBooks");
            DropForeignKey("dbo.BranchBooks", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.BranchBooks", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Checkouts", new[] { "BranchBookID" });
            DropIndex("dbo.Reservations", new[] { "PatronID" });
            DropIndex("dbo.Reservations", new[] { "BranchBookID" });
            DropIndex("dbo.BranchBooks", new[] { "BranchID" });
            DropIndex("dbo.BranchBooks", new[] { "BookID" });
            DropIndex("dbo.Books", new[] { "AuthorID" });
            DropTable("dbo.Checkouts");
            DropTable("dbo.Patrons");
            DropTable("dbo.Reservations");
            DropTable("dbo.Branches");
            DropTable("dbo.BranchBooks");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
