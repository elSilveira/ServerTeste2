namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cscontrol : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClienteServico", "idEmpresaCliente", "dbo.EmpresaCliente");
            DropIndex("dbo.ClienteServico", new[] { "idEmpresaCliente" });
            AddColumn("dbo.ClienteServico", "idEmpresaClienteServico", c => c.Int(nullable: false));
            CreateIndex("dbo.ClienteServico", "idEmpresaClienteServico");
            AddForeignKey("dbo.ClienteServico", "idEmpresaClienteServico", "dbo.EmpresaClienteServico", "idEmpresaClienteServico", cascadeDelete: true);
            DropColumn("dbo.ClienteServico", "idEmpresaCliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClienteServico", "idEmpresaCliente", c => c.Int(nullable: false));
            DropForeignKey("dbo.ClienteServico", "idEmpresaClienteServico", "dbo.EmpresaClienteServico");
            DropIndex("dbo.ClienteServico", new[] { "idEmpresaClienteServico" });
            DropColumn("dbo.ClienteServico", "idEmpresaClienteServico");
            CreateIndex("dbo.ClienteServico", "idEmpresaCliente");
            AddForeignKey("dbo.ClienteServico", "idEmpresaCliente", "dbo.EmpresaCliente", "idEmpresaCliente", cascadeDelete: true);
        }
    }
}
