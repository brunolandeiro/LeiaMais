namespace LeiaMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class curtidaquant : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Curtidas", "Quantidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Curtidas", "Quantidade", c => c.Int(nullable: false));
        }
    }
}
