namespace LeiaMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeira : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Data = c.DateTime(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Livroes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Livroes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Livroes", new[] { "UsuarioId" });
            DropIndex("dbo.Livroes", new[] { "CategoriaId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Livroes");
            DropTable("dbo.Categorias");
        }
    }
}
