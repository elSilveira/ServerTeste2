namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agenda2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agenda", "idCliente", "dbo.Clientes");
            DropIndex("dbo.Agenda", new[] { "idCliente" });
            DropColumn("dbo.Agenda", "idCliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agenda", "idCliente", c => c.Int(nullable: false));
            CreateIndex("dbo.Agenda", "idCliente");
            AddForeignKey("dbo.Agenda", "idCliente", "dbo.Clientes", "idCliente", cascadeDelete: true);
        }
    }
}
