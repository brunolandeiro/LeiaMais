namespace LeiaMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voltasemContato : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contatoes", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "Contato_Id", "dbo.Contatoes");
            DropForeignKey("dbo.Contatoes", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Contatoes", new[] { "UsuarioId" });
            DropIndex("dbo.Contatoes", new[] { "Usuario_Id" });
            DropIndex("dbo.Usuarios", new[] { "Contato_Id" });
            DropColumn("dbo.Usuarios", "Contato_Id");
            DropTable("dbo.Contatoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Usuarios", "Contato_Id", c => c.Int());
            CreateIndex("dbo.Usuarios", "Contato_Id");
            CreateIndex("dbo.Contatoes", "Usuario_Id");
            CreateIndex("dbo.Contatoes", "UsuarioId");
            AddForeignKey("dbo.Contatoes", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Usuarios", "Contato_Id", "dbo.Contatoes", "Id");
            AddForeignKey("dbo.Contatoes", "Usuario_Id", "dbo.Usuarios", "Id");
        }
    }
}
