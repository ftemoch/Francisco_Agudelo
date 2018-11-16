namespace Clase12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creacionBD1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Salario", c => c.Single(nullable: false));
            AddColumn("dbo.Clientes", "estaactivo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "estaactivo");
            DropColumn("dbo.Clientes", "Salario");
        }
    }
}
