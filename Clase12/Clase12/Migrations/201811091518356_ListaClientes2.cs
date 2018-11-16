namespace Clase12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListaClientes2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "genero_Id", "dbo.Generoes");
            DropIndex("dbo.Movies", new[] { "genero_Id" });
            DropTable("dbo.Generoes");
            DropTable("dbo.Movies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Nombre = c.String(),
                        Idgenero = c.Byte(nullable: false),
                        genero_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Nombre = c.String(),
                        Coartada = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Movies", "genero_Id");
            AddForeignKey("dbo.Movies", "genero_Id", "dbo.Generoes", "Id");
        }
    }
}
