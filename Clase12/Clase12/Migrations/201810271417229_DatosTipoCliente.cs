namespace Clase12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatosTipoCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoClientes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Nombre = c.String(),
                        costoSubscripcion = c.Short(nullable: false),
                        duracionSbcEnMeses = c.Byte(nullable: false),
                        porcDescuento = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clientes", "estaInscritoRevista", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clientes", "IdTipoCliente", c => c.Byte(nullable: false));
            AddColumn("dbo.Clientes", "tipoCliente_Id", c => c.Byte());
            AlterColumn("dbo.Clientes", "Nombre", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Clientes", "tipoCliente_Id");
            AddForeignKey("dbo.Clientes", "tipoCliente_Id", "dbo.TipoClientes", "Id");

            Sql("INSERT INTO TipoClientes(Id, costoSubscripcion, duracionSbcEnMeses, porcDescuento) VALUES(1,0,0,0)");
            Sql("INSERT INTO TipoClientes(Id, costoSubscripcion, duracionSbcEnMeses, porcDescuento) VALUES(2,30,1,10)");
            Sql("INSERT INTO TipoClientes(Id, costoSubscripcion, duracionSbcEnMeses, porcDescuento) VALUES(3,90,3,15)");
            Sql("INSERT INTO TipoClientes(Id, costoSubscripcion, duracionSbcEnMeses, porcDescuento) VALUES(4,300,12,20)");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "tipoCliente_Id", "dbo.TipoClientes");
            DropIndex("dbo.Clientes", new[] { "tipoCliente_Id" });
            AlterColumn("dbo.Clientes", "Nombre", c => c.String());
            DropColumn("dbo.Clientes", "tipoCliente_Id");
            DropColumn("dbo.Clientes", "IdTipoCliente");
            DropColumn("dbo.Clientes", "estaInscritoRevista");
            DropTable("dbo.TipoClientes");
        }
    }
}
