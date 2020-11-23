namespace GalinhaCaipira.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Granja",
                c => new
                    {
                        GranjaId = c.Int(nullable: false, identity: true),
                        NomeFantasia = c.String(nullable: false, maxLength: 300, unicode: false),
                        UsuarioId = c.Int(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataInclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GranjaId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Sobrenome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        HashChave = c.Binary(nullable: false),
                        HashSalt = c.Binary(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataInclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Granja", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Usuario", new[] { "Email" });
            DropIndex("dbo.Granja", new[] { "UsuarioId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Granja");
        }
    }
}
