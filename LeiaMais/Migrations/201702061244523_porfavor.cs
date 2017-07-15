namespace LeiaMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class porfavor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuarioContatoes", "ContatoId", "dbo.Contatoes");
            DropForeignKey("dbo.UsuarioContatoes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Contatoes", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Contatoes", new[] { "UsuarioId" });
            DropIndex("dbo.UsuarioContatoes", new[] { "ContatoId" });
            DropIndex("dbo.UsuarioContatoes", new[] { "UsuarioId" });
            DropTable("dbo.Contatoes");
            DropTable("dbo.UsuarioContatoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsuarioContatoes",
                c => new
                    {
                        ContatoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ContatoId, t.UsuarioId });
            
            CreateTable(
                "dbo.Contatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UsuarioContatoes", "UsuarioId");
            CreateIndex("dbo.UsuarioContatoes", "ContatoId");
            CreateIndex("dbo.Contatoes", "UsuarioId");
            AddForeignKey("dbo.Contatoes", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsuarioContatoes", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UsuarioContatoes", "ContatoId", "dbo.Contatoes", "Id", cascadeDelete: true);
        }
    }
}
