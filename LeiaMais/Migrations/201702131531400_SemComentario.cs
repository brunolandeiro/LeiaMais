namespace LeiaMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SemComentario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comentarios", "LivroId", "dbo.Livroes");
            DropForeignKey("dbo.Comentarios", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Comentarios", new[] { "LivroId" });
            DropIndex("dbo.Comentarios", new[] { "UsuarioId" });
            DropColumn("dbo.Usuarios", "ComentarioId");
            DropColumn("dbo.Livroes", "ComentarioId");
            DropTable("dbo.Comentarios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        LivroId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Livroes", "ComentarioId", c => c.Int(nullable: false));
            AddColumn("dbo.Usuarios", "ComentarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comentarios", "UsuarioId");
            CreateIndex("dbo.Comentarios", "LivroId");
            AddForeignKey("dbo.Comentarios", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comentarios", "LivroId", "dbo.Livroes", "Id", cascadeDelete: true);
        }
    }
}
