namespace ServerTeste2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cliser2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClienteServico", "idEmpresaCliente", c => c.Int(nullable: false));
            CreateIndex("dbo.ClienteServico", "idEmpresaCliente");
            AddForeignKey("dbo.ClienteServico", "idEmpresaCliente", "dbo.EmpresaCliente", "idEmpresaCliente", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClienteServico", "idEmpresaCliente", "dbo.EmpresaCliente");
            DropIndex("dbo.ClienteServico", new[] { "idEmpresaCliente" });
            DropColumn("dbo.ClienteServico", "idEmpresaCliente");
        }
    }
}
