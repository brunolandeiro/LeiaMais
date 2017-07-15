namespace LeiaMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comentario : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Livroes", t => t.LivroId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: false)
                .Index(t => t.LivroId)
                .Index(t => t.UsuarioId);
            
            AddColumn("dbo.Usuarios", "ComentarioId", c => c.Int(nullable: false));
            AddColumn("dbo.Livroes", "ComentarioId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Comentarios", "LivroId", "dbo.Livroes");
            DropIndex("dbo.Comentarios", new[] { "UsuarioId" });
            DropIndex("dbo.Comentarios", new[] { "LivroId" });
            DropColumn("dbo.Livroes", "ComentarioId");
            DropColumn("dbo.Usuarios", "ComentarioId");
            DropTable("dbo.Comentarios");
        }
    }
}
