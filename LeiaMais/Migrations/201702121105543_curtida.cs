namespace LeiaMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class curtida : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Curtidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        LivroId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Livroes", t => t.LivroId, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: false)
                .Index(t => t.UsuarioId)
                .Index(t => t.LivroId);
            
            AddColumn("dbo.Livroes", "CurtidaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Curtidas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Curtidas", "LivroId", "dbo.Livroes");
            DropIndex("dbo.Curtidas", new[] { "LivroId" });
            DropIndex("dbo.Curtidas", new[] { "UsuarioId" });
            DropColumn("dbo.Livroes", "CurtidaId");
            DropTable("dbo.Curtidas");
        }
    }
}
