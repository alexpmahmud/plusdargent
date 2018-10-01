namespace PlusArgent_v1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class plusargentv7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "DateEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "DateEnd", c => c.DateTime());
        }
    }
}
