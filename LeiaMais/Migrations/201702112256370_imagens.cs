namespace LeiaMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagens : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livroes", "url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Livroes", "url");
        }
    }
}
