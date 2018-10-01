namespace PlusArgent_v1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class plusargentv6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parcels", "PayDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parcels", "PayDay", c => c.DateTime(nullable: false));
        }
    }
}
