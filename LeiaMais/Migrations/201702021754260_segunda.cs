namespace LeiaMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segunda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Livroes", "Autor", c => c.String());
            AddColumn("dbo.Livroes", "Descricao", c => c.String());
            AlterColumn("dbo.Categorias", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Livroes", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Livroes", "Nome", c => c.String());
            AlterColumn("dbo.Categorias", "Nome", c => c.String());
            DropColumn("dbo.Livroes", "Descricao");
            DropColumn("dbo.Livroes", "Autor");
        }
    }
}
