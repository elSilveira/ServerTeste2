namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agenda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agenda", "idEmpresa", "dbo.Empresas");
            DropForeignKey("dbo.Agenda", "idCliente", "dbo.Clientes");
            DropIndex("dbo.Agenda", new[] { "idEmpresa" });
            AddColumn("dbo.Agenda", "idEmpresaCliente", c => c.Int(nullable: false));
            CreateIndex("dbo.Agenda", "idEmpresaCliente");
            AddForeignKey("dbo.Agenda", "idEmpresaCliente", "dbo.EmpresaCliente", "idEmpresaCliente", cascadeDelete: true);
            DropColumn("dbo.Agenda", "idEmpresa");
            DropColumn("dbo.Agenda", "idFuncionario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agenda", "idFuncionario", c => c.Int(nullable: false));
            AddColumn("dbo.Agenda", "idEmpresa", c => c.Int(nullable: false));
            DropForeignKey("dbo.Agenda", "idEmpresaCliente", "dbo.EmpresaCliente");
            DropIndex("dbo.Agenda", new[] { "idEmpresaCliente" });
            DropColumn("dbo.Agenda", "idEmpresaCliente");
            CreateIndex("dbo.Agenda", "idEmpresa");
            AddForeignKey("dbo.Agenda", "idCliente", "dbo.Clientes", "idCliente", cascadeDelete: true);
            AddForeignKey("dbo.Agenda", "idEmpresa", "dbo.Empresas", "idEmpresa", cascadeDelete: true);
        }
    }
}
