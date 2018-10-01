namespace PlusArgent_v1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlusArgent_v5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "RepeatPeriod", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "DateEnd", c => c.DateTime());
            DropColumn("dbo.Books", "Repeat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Repeat", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Books", "DateEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "RepeatPeriod");
        }
    }
}
