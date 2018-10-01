namespace PlusArgent_v1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlusArgent_v4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        IdAccount = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        Type = c.Int(nullable: false),
                        DateDue = c.Int(),
                        IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAccount)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 10),
                        Photo = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        IdBook = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Repeat = c.String(nullable: false, maxLength: 2),
                        Type = c.String(nullable: false, maxLength: 1),
                        IdCategory = c.Int(nullable: false),
                        IdAccount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdBook)
                .ForeignKey("dbo.Accounts", t => t.IdAccount)
                .ForeignKey("dbo.Categories", t => t.IdCategory)
                .Index(t => t.IdCategory)
                .Index(t => t.IdAccount);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdCategory = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 255),
                        Type = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCategory)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Parcels",
                c => new
                    {
                        IdParcel = c.Int(nullable: false, identity: true),
                        ParcelNumber = c.Int(nullable: false),
                        PayDay = c.DateTime(nullable: false),
                        IdBook = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdParcel)
                .ForeignKey("dbo.Books", t => t.IdBook)
                .Index(t => t.IdBook);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        IdTransaction = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        IdAccount = c.Int(nullable: false),
                        IdBook = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTransaction)
                .ForeignKey("dbo.Accounts", t => t.IdAccount)
                .ForeignKey("dbo.Books", t => t.IdBook)
                .Index(t => t.IdAccount)
                .Index(t => t.IdBook);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "IdBook", "dbo.Books");
            DropForeignKey("dbo.Transactions", "IdAccount", "dbo.Accounts");
            DropForeignKey("dbo.Parcels", "IdBook", "dbo.Books");
            DropForeignKey("dbo.Books", "IdCategory", "dbo.Categories");
            DropForeignKey("dbo.Categories", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Books", "IdAccount", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "IdUser", "dbo.Users");
            DropIndex("dbo.Transactions", new[] { "IdBook" });
            DropIndex("dbo.Transactions", new[] { "IdAccount" });
            DropIndex("dbo.Parcels", new[] { "IdBook" });
            DropIndex("dbo.Categories", new[] { "IdUser" });
            DropIndex("dbo.Books", new[] { "IdAccount" });
            DropIndex("dbo.Books", new[] { "IdCategory" });
            DropIndex("dbo.Accounts", new[] { "IdUser" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Parcels");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Users");
            DropTable("dbo.Accounts");
        }
    }
}
