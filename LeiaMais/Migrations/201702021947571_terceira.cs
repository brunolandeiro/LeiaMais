namespace LeiaMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class terceira : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Livroes", "Data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livroes", "Data", c => c.DateTime(nullable: false));
        }
    }
}
