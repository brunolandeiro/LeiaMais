namespace LeiaMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contato : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.UsuarioContatoes",
                c => new
                    {
                        ContatoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UsuarioId })
                .ForeignKey("dbo.Contatoes", t => t.ContatoId, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: false)
                .Index(t => t.ContatoId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contatoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioContatoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.UsuarioContatoes", "ContatoId", "dbo.Contatoes");
            DropIndex("dbo.UsuarioContatoes", new[] { "UsuarioId" });
            DropIndex("dbo.UsuarioContatoes", new[] { "ContatoId" });
            DropIndex("dbo.Contatoes", new[] { "UsuarioId" });
            DropTable("dbo.UsuarioContatoes");
            DropTable("dbo.Contatoes");
        }
    }
}
