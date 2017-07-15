namespace LeiaMais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioContato : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UsuarioContatoes");
            AddColumn("dbo.UsuarioContatoes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UsuarioContatoes", "Id");
            
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UsuarioContatoes");
            DropColumn("dbo.UsuarioContatoes", "Id");
            AddPrimaryKey("dbo.UsuarioContatoes", new[] { "ContatoId", "UsuarioId" });
        }
    }
}
